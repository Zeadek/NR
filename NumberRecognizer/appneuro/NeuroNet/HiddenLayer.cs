using NumberRecognizer.NeuroNet;
using System.Diagnostics.Tracing;

namespace NumberRecognizer.NeuroNet
{
    class HiddenLayer : Layer
    {
        public HiddenLayer(int non, int nopn, NeuronType type, string nameLayer) : base(non, nopn, type, nameLayer)
        {
        }
        //прямой проход
        public override void Recognize(Network net, Layer nextLayer)
        {
            double[] hidden_out = new double[numOfNeurons];
            for (int i = 0; i < numOfNeurons; i++)
                hidden_out[i] = neurons[i].Output;

            nextLayer.Data = hidden_out;//передача выходного сигнала на вход след слоя
        }

        //Обратный проход
        public override double[] BackwardPass(double[] gr_sums)
        {
            double[] gr_sum = new double[numOfPrevNeurons];
            //цикл вычисления градиентной суммы j-го нейрона
            for (int j = 0; j < numOfPrevNeurons; j++)
            {
                double sum = 0;
                for (int k = 0; k < numOfNeurons; k++)
                    sum += neurons[k].Weights[j] * neurons[k].Derivative * gr_sums[k];//через градиентные суммы и производную

                gr_sum[j] = sum;
            }

            for (int i = 0; i < numOfNeurons; i++)//цикл коррекции синаптических весов
                for (int n = 0; n < numOfPrevNeurons + 1; n++)
                {
                    double deltaw;
                    if (n == 0)//если порог
                        deltaw = momentum * lastDeltaWeights[i, 0] + learningRate * neurons[i].Derivative * gr_sums[i];
                    else
                        deltaw = momentum * lastDeltaWeights[i, n] + learningRate * neurons[i].Inputs[n - 1] * neurons[i].Derivative * gr_sums[i];
                    lastDeltaWeights[i, n] = deltaw;
                    neurons[i].Weights[n] += deltaw; //коррекция весов
                }
            return gr_sum;
        }

    }
}
