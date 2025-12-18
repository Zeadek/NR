using System;
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
        private bool is_dropped_out = false; // флаг для указания, что нейрон отключен (dropout)

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
            get 
            { 
                // Если нейрон отключен (dropout), возвращаем 0
                if (is_dropped_out) 
                    return 0.0; 
                else 
                    // Масштабируем выход при отсутствии dropout для компенсации отключенных нейронов
                    // Это нужно для компенсации во время тестирования
                    return outputs; 
            }
        }

        public double Derivative
        {
            get => derivative;
        }
        
        // Метод для установки состояния dropout
        public void SetOutputToZero(bool isDropped)
        {
            is_dropped_out = isDropped;
        }
        
        // Метод для получения состояния dropout
        public bool IsDroppedOut()
        {
            return is_dropped_out;
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
            return 1.7159*Tanh((2.0/3.0)*x);
        }

        public double HyperbolicTangent_Derivativator(double x)
        {
            double inner = (2.0 / 3.0) * x;
            double tanhInner = Math.Tanh(inner);
            return 1.7159 * (2.0 / 3.0) * (1.0 - tanhInner * tanhInner);
        }
        
        // Экспоненциальная функция для выходного слоя
        public double Exp(double x)
        {
            return Math.Exp(x);
        }
    }
}
