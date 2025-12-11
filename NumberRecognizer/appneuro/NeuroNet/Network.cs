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
        //свойства
        public double[] Fact { get => fact; }
        //среднее значение энергии ошибки эпохи обучения
        public double[] E_error_avr { get => e_error_avr; set => e_error_avr = value; }
        //конструктор
        public Network() { }

        //прямой проход сети
        public void ForwardPass(Network net, double[] netInput)
        {
            net.hidden_layer1.Data = netInput;
            net.hidden_layer1.Recognize(null, net.hidden_layer2);
            net.hidden_layer2.Recognize(null, net.output_layer);
            net.output_layer.Recognize(net, null);
        }

        //непосредственное обучение
        public void Train(Network net)
        {
            net.input_layer = new InputLayer(NetworkMode.Train);
            int epoches = 15; //количество эпох обучения
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
                    ForwardPass(net, tmpTrain);//прямой проход обучающего образа

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
                    e_error_avr[k] = tmpSumError / errors.Length;//суммарное значение ошибки К-той эпохи


                    //обратный проход и коррекция весов !!!!!!!!
                    temp_gsums2 = net.output_layer.BackwardPass(errors);
                    temp_gsums1 = net.hidden_layer2.BackwardPass(temp_gsums2);
                    net.hidden_layer1.BackwardPass(temp_gsums1);
                }
                e_error_avr[k] /= net.input_layer.Trainset.GetLength(0);//среднее значение энергии ошибки одной эпохи

            }
            net.input_layer = null;//обнуление входнгого слоя

            //запись скорректированных весов в память
            net.hidden_layer1.WeightInitialize(MemoryMode.SET, nameof(hidden_layer1) + "_memory.csv");
            net.hidden_layer2.WeightInitialize(MemoryMode.SET, nameof(hidden_layer2) + "_memory.csv");
            net.output_layer.WeightInitialize(MemoryMode.SET, nameof(output_layer) + "_memory.csv");
        }
    }
}
