using System;
using System.IO;
using System.Windows.Forms;
using System.Linq;
using static System.Math;
using System.Data;
using System.Text;

namespace NumberRecognizer.NeuroNet
{
    abstract class Layer
    {
        protected string name;
        string pathDirWeights; //путь к каталогу с файлом с синаптическими весами
        string pathFileWeights; //путь к файлу с синаптическими весами
        protected int numOfNeurons;
        protected int numOfPrevNeurons;
        protected const double learningRate = 0.077;
        protected const double momentum = 0.070d;
        protected double[,] lastDeltaWeights;
        protected Neuron[] neurons;

        public Neuron[] Neurons { get { return neurons; } set { neurons = value; } }
        public double[] Data
        {
            set
            {
                for (int i = 0; i < numOfNeurons; i++)
                {
                    Neurons[i].Activator(value);
                }
            }
        }

        protected Layer(int non, int nopn, NeuronType type, string nameLayer)
        {
            numOfNeurons = non;
            numOfPrevNeurons = nopn;
            Neurons = new Neuron[numOfNeurons];
            name = nameLayer;
            pathDirWeights = AppDomain.CurrentDomain.BaseDirectory + "memory\\";
            pathFileWeights = pathDirWeights + name + "_memory.csv";

            lastDeltaWeights = new double[non, nopn + 1];
            double[,] Weights; //временный массив синаптических весов текущего слоя

            if (File.Exists(pathFileWeights))
                Weights = WeightInitialize(MemoryMode.GET, pathFileWeights);
            else
            {
                Directory.CreateDirectory(pathDirWeights);
                Weights = WeightInitialize(MemoryMode.INIT, pathFileWeights);
            }

            for (int i = 0; i < non; i++)
            {
                double[] tmpWeights = new double[nopn + 1];
                for (int j = 0; j < tmpWeights.Length; j++)
                {
                    tmpWeights[j] = Weights[i, j];
                }
                Neurons[i] = new Neuron(tmpWeights, type);
            }
        }

        //Метод работы с массивом синаптических весов
        public double[,] WeightInitialize(MemoryMode memoryMode, string path)
        {
            char[] delim = new char[] { ';', ' ' };
            string tmpStr;
            string[] tmpStrWeights;
            double[,] weights = new double[numOfNeurons, numOfPrevNeurons + 1];
            switch (memoryMode)
            {
                case MemoryMode.GET:
                    tmpStrWeights = File.ReadAllLines(path);
                    string[] memoryElement;
                    for (int i = 0; i < numOfNeurons; i++)
                    {
                        memoryElement = tmpStrWeights[i].Split(delim);
                        for (int j = 0; j < numOfPrevNeurons + 1; j++)
                        {
                            weights[i, j] = double.Parse(memoryElement[j].Replace(',', '.'), System.Globalization.CultureInfo.InvariantCulture);
                        }
                    }
                    break;
                case MemoryMode.INIT:
                    Console.WriteLine("ветка инит");
                    Random random = new Random();
                    double tmpRatio;
                    double tmpShift;
                    double[] tmpArr = new double[numOfPrevNeurons + 1];
                    double[] tmpArr2 = new double[numOfPrevNeurons + 1];
                    tmpStrWeights = new string[numOfNeurons];

                    for (int i = 0; i < numOfNeurons; i++)
                    {
                        for (int j = 0; j < numOfPrevNeurons + 1; j++)
                        {
                            weights[i, j] = random.NextDouble();
                        }
                    }
                    for (int i = 0; i < numOfNeurons; i++)
                    {
                        for (int j = 0; j < numOfPrevNeurons + 1; j++)
                        {
                            tmpArr[j] = weights[i, j];
                        }
                        tmpShift = tmpArr.Average();
                        for (int j = 0; j < numOfPrevNeurons + 1; j++)
                        {
                            weights[i, j] -= tmpShift;
                        }
                    }
                    for (int i = 0; i < numOfNeurons; i++)
                    {
                        for (int j = 0; j < numOfPrevNeurons + 1; j++)
                        {
                            tmpArr2[j] = weights[i, j] * weights[i, j];
                        }
                        tmpRatio = Math.Pow(tmpArr2.Average(), 1 / 2);
                        for (int j = 0; j < numOfPrevNeurons + 1; j++)
                        {
                            weights[i, j] /= tmpRatio;
                        }
                    }
                    tmpStr = "";
                    for (int i = 0; i < numOfNeurons; i++)
                    {
                        for (int j = 0; j < numOfPrevNeurons + 1; j++)
                        {
                            tmpStr += weights[i, j].ToString() + " ";
                        }
                        tmpStr += "\n";
                    }
                    Console.WriteLine(tmpStr);
                    File.AppendAllText(path, tmpStr);
                    break;
                case MemoryMode.SET:
                    StringBuilder weightsBuilder = new StringBuilder();

                    for (int i = 0; i < numOfNeurons; i++)
                    {
                        // Предполагаем, что у нейрона есть свойство Weights, содержащее массив весов
                        // Включаем bias-вес (последний вес в массиве)
                        for (int j = 0; j < numOfPrevNeurons + 1; j++)
                        {
                            // Добавляем вес с разделителем ";" и с точкой как десятичным разделителем
                            weightsBuilder.Append(neurons[i].Weights[j].ToString(System.Globalization.CultureInfo.InvariantCulture));

                            if (j < numOfPrevNeurons) // После последнего веса не ставим разделитель
                                weightsBuilder.Append(";");
                        }

                        if (i < numOfNeurons - 1) // После последней строки не ставим перевод строки
                            weightsBuilder.AppendLine();
                    }

                    // Сохраняем в файл, перезаписывая предыдущие значения
                    File.WriteAllText(path, weightsBuilder.ToString());
                    break;
            }
            return weights;
        }
        abstract public void Recognize(Network net, Layer nextLayer);
        abstract public double[] BackwardPass(double[] stuff);
    }
}