namespace NumberRecognizer.NeuroNet
{
    class Network
    {
        //все слои сети
        private InputLayer input_layer = null;
        private HiddenLayer hidden_layer1 = new HiddenLayer(71, 15, NeuronType.Hidden, nameof(hidden_layer1));
        private HiddenLayer hidden_layer2 = new HiddenLayer(37, 71, NeuronType.Hidden, nameof(hidden_layer2));
        private OutputLayer output_layer = new OutputLayer(10, 37, NeuronType.Output, nameof(output_layer));

        private double[] fact = new double[10];//массив фактического выхода сети
        private double[] e_error_avr;//среднее значение энергии ошибки эпохи обучения
        private double dropout_rate = 0.5; // вероятность отключения нейрона (по умолчанию 50%)
        private bool[,] dropout_masks1; // маски дропаута для первого скрытого слоя
        private bool[,] dropout_masks2; // маски дропаута для второго скрытого слоя
        
        //свойства
        public double[] Fact { get => fact; }
        //среднее значение энергии ошибки эпохи обучения
        public double[] E_error_avr { get => e_error_avr; set => e_error_avr = value; }
        
        public double DropoutRate 
        { 
            get => dropout_rate; 
            set 
            { 
                if (value >= 0.0 && value <= 1.0) 
                    dropout_rate = value; 
            } 
        }
        
        //конструктор
        public Network() { }

        //прямой проход сети
        public void ForwardPass(Network net, double[] netInput, bool apply_dropout = true)
        {
            // Устанавливаем входные данные
            net.hidden_layer1.Data = netInput;
            
            if (apply_dropout)
            {
                // Применяем dropout только во время обучения
                ApplyDropoutToLayer(net.hidden_layer1, ref net.dropout_masks1, net.dropout_rate);
                net.hidden_layer1.Recognize(net, net.hidden_layer2); // передаем net для доступа к dropout_rate
                
                ApplyDropoutToLayer(net.hidden_layer2, ref net.dropout_masks2, net.dropout_rate);
                net.hidden_layer2.Recognize(net, net.output_layer); // передаем net для доступа к dropout_rate
            }
            else
            {
                // Без dropout для тестирования - все равно нужно сбросить состояния dropout
                ResetDropoutState(net.hidden_layer1);
                net.hidden_layer1.Recognize(net, net.hidden_layer2);
                
                ResetDropoutState(net.hidden_layer2);
                net.hidden_layer2.Recognize(net, net.output_layer);
            }
            
            // Для выходного слоя не применяем dropout, но передаем сеть для совместимости
            net.output_layer.Recognize(net, null);
            
            // Сбрасываем состояния dropout после завершения прямого прохода
            if (apply_dropout)
            {
                ResetDropoutState(net.hidden_layer1);
                ResetDropoutState(net.hidden_layer2);
            }
        }

        // Метод для применения dropout к слою
        private void ApplyDropoutToLayer(HiddenLayer layer, ref bool[,] dropout_mask, double dropout_rate)
        {
            Random rand = new Random();
            int num_samples = 1; // Для одного образца за раз
            
            // Инициализация маски dropout если нужно
            if (dropout_mask == null || dropout_mask.GetLength(0) != num_samples || dropout_mask.GetLength(1) != layer.Neurons.Length)
            {
                dropout_mask = new bool[num_samples, layer.Neurons.Length];
            }

            // Генерируем маску dropout для текущего образца
            for (int i = 0; i < layer.Neurons.Length; i++)
            {
                bool isActive = rand.NextDouble() > dropout_rate;
                dropout_mask[0, i] = isActive;

                // Устанавливаем состояние dropout для нейрона
                layer.Neurons[i].SetOutputToZero(!isActive); // Если !isActive, то нейрон отключен
            }
        }
        
        // Метод для сброса состояния dropout после обработки образца
        private void ResetDropoutState(HiddenLayer layer)
        {
            for (int i = 0; i < layer.Neurons.Length; i++)
            {
                layer.Neurons[i].SetOutputToZero(false); // Сбрасываем состояние dropout
            }
        }

        //непосредственное обучение
        public void Train(Network net)
        {
            net.input_layer = new InputLayer(NetworkMode.Train);
            int epoches = 10; //количество эпох обучения
            double tmpSumError;
            double[] errors;
            double[] temp_gsums1;
            double[] temp_gsums2;

            e_error_avr = new double[epoches];
            for (int k = 0; k < epoches; k++)//прохождение по эпохам
            {
                e_error_avr[k] = 0;
                net.input_layer.Shuffling_Array_Rows(net.input_layer.Trainset);
                for (int i = 0; i < net.input_layer.Trainset.GetLength(0); i++)
                {
                    double[] tmpTrain = new double[15];
                    for (int j = 0; j < tmpTrain.Length; j++)
                        tmpTrain[j] = net.input_layer.Trainset[i, j + 1];

                    //прямой проход
                    ForwardPass(net, tmpTrain, true);//прямой проход обучающего образа с dropout

                    //вычисление ошибки по итераци
                    tmpSumError = 0;//для каждого обучающего образа среднее значение ошибки этого образа обнуляется
                    errors = new double[net.fact.Length];//переопределение массива сигнала ошибки входного слоя
                    for (int x = 0; x < errors.Length; x++)
                    {
                        if (x == net.input_layer.Trainset[i, 0])//если номер выходного сигнала совпадает с желаемым
                            errors[x] = 1.0 - net.fact[x];
                        else
                            errors[x] = -net.fact[x];

                        tmpSumError += errors[x] * errors[x] / 2;
                    }
                    e_error_avr[k] += tmpSumError / errors.Length;//суммарное значение ошибки К-той эпохи


                    //обратный проход и коррекция весов !!!!!!!!
                    temp_gsums2 = net.output_layer.BackwardPass(errors);
                    temp_gsums1 = net.hidden_layer2.BackwardPass(temp_gsums2);
                    net.hidden_layer1.BackwardPass(temp_gsums1);
                }
                e_error_avr[k] /= net.input_layer.Trainset.GetLength(0);//среднее значение энергии ошибки одной эпохи

            }
            net.input_layer = null;//обнуление входнгого слоя

            //запись скорректированных весов в память
            net.hidden_layer1.WeightInitialize(MemoryMode.SET, "memory\\hidden_layer1_memory.csv");
            net.hidden_layer2.WeightInitialize(MemoryMode.SET, "memory\\hidden_layer2_memory.csv");
            net.output_layer.WeightInitialize(MemoryMode.SET, "memory\\output_layer_memory.csv");
        }
        public void Test(Network net)
        {
            net.input_layer = new InputLayer(NetworkMode.Test);
            int epoches = 3; //количество эпох обучения
            double tmpSumError;
            double[] errors;
            double[] temp_gsums1;
            double[] temp_gsums2;

            e_error_avr = new double[epoches];
            for (int k = 0; k < epoches; k++)//прохождение по эпохам
            {
                e_error_avr[k] = 0;
                net.input_layer.Shuffling_Array_Rows(net.input_layer.Testset);
                for (int i = 0; i < net.input_layer.Testset.GetLength(0); i++)
                {
                    double[] tmpTest = new double[15];
                    for (int j = 0; j < tmpTest.Length; j++)
                        tmpTest[j] = net.input_layer.Testset[i, j + 1];

                    //прямой проход
                    ForwardPass(net, tmpTest, false);//прямой проход тестового образа без dropout

                    //вычисление ошибки по итераци
                    tmpSumError = 0;//для каждого обучающего образа среднее значение ошибки этого образа обнуляется
                    errors = new double[net.fact.Length];//переопределение массива сигнала ошибки входного слоя
                    for (int x = 0; x < errors.Length; x++)
                    {
                        if (x == net.input_layer.Testset[i, 0])//если номер выходного сигнала совпадает с желаемым
                            errors[x] = 1.0 - net.fact[x];
                        else
                            errors[x] = -net.fact[x];

                        tmpSumError += errors[x] * errors[x] / 2;
                    }
                    e_error_avr[k] += tmpSumError / errors.Length;//суммарное значение ошибки К-той эпо хи

                }
                e_error_avr[k] /= net.input_layer.Testset.GetLength(0);//среднее значение энергии ошибки одной эпохи

            }
        }
    }
}
