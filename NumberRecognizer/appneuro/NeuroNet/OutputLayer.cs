namespace NumberRecognizer.NeuroNet
{
    class OutputLayer : Layer
    {
        public OutputLayer(int non, int nopn, NeuronType type, string nameLayer) : base(non, nopn, type, nameLayer)
        {
        }

        //прямой ход
        public override void Recognize(Network net, Layer nextLayer)
        {
            double e_sum = 0;
            for (int i = 0; i < neurons.Length; i++)
                e_sum += neurons[i].Output;

            for (int i = 0; i < neurons.Length; i++)
                net.Fact[i] = neurons[i].Output / e_sum;
        }

        //Обратный проход
        public override double[] BackwardPass(double[] errors)
        {
            double[] gr_sum = new double[numOfPrevNeurons + 1];
            //вычисление градиентных сумм выходного слоя
            for (int j = 0; j < numOfPrevNeurons + 1; j++)
            {
                double sum = 0;
                for (int k = 0; k < numOfNeurons; k++)
                    sum += neurons[k].Weights[j] * errors[k];

                gr_sum[j] = sum;
            }

            for (int i = 0; i < numOfNeurons; i++)//цикл коррекции синаптических весов
                for (int n = 0; n < numOfPrevNeurons + 1; n++)
                {
                    double deltaw;
                    if (n == 0)
                        deltaw = momentum * lastDeltaWeights[i, 0] + learningRate * errors[i];
                    else
                        deltaw = momentum * lastDeltaWeights[i, n] + learningRate * neurons[i].Inputs[n - 1] * errors[i];
                    lastDeltaWeights[i, n] = deltaw;
                    neurons[i].Weights[n] += deltaw; //коррекция весов
                }
            return gr_sum;
        }
    }
}
