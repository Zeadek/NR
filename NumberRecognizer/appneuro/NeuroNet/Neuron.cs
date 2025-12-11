using System.Runtime.Remoting.Lifetime;
using static System.Math;

namespace NumberRecognizer.NeuroNet
{
    class Neuron
    {
        private NeuronType type;
        private double[] weights;
        private double[] inputs;
        private double outputs;
        private double derivative;

        private double a = 0.01d;

        public double[] Weights
        {
            get => weights;
            set => weights = value;
        }

        public double[] Inputs
        {
            get => inputs;
            set => inputs = value;
        }

        public double Output
        {
            get => outputs;
        }

        public double Derivative
        {
            get => derivative;
        }

        public Neuron(double[] memoryWeights, NeuronType typeNeuron)
        {
            this.type = typeNeuron;
            this.weights = memoryWeights;
        }

        public void Activator(double[] i)
        {
            inputs = i;

            double sum = weights[0];

            for (int j = 0; j < inputs.Length; j++)
            {
                sum += inputs[j] * weights[j + 1];
            }

            switch (type)
            {
                case NeuronType.Hidden:
                    outputs = HyperbolicTangent(sum);
                    derivative = HyperbolicTangent_Derivativator(sum);
                    break;
                case NeuronType.Output:
                    outputs = Exp(sum);
                    break;
            }
        }

        public double HyperbolicTangent(double x)
        {
            return Tanh(x);
        }

        public double HyperbolicTangent_Derivativator(double x)
        {
            return 1 - Pow(Tanh(x), 2);
        }
    }
}
