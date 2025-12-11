using System;
using System.IO;

namespace NumberRecognizer.NeuroNet
{
    class InputLayer
    {
        //Поля
        private double[,] trainset;
        private double[,] testset;

        //Свойства
        public double[,] Trainset { get => trainset; }
        public double[,] Testset { get => testset; }

        //Конструктор
        public InputLayer(NetworkMode nm)
        {
            string path = AppDomain.CurrentDomain.BaseDirectory;
            string[] tmpArrStr;
            string[] tmpStr;

            switch (nm)
            {
                case NetworkMode.Train:
                    tmpArrStr = File.ReadAllLines(path + "train.txt");
                    trainset = new double[tmpArrStr.Length, 16];
                    for (int i = 0; i < tmpArrStr.Length; i++)
                    {
                        tmpStr = tmpArrStr[i].Split(' ');
                        for (int j = 0; j < 16; j++)
                        {
                            trainset[i, j] = double.Parse(tmpStr[j]);
                        }
                    }
                    Shuffling_Array_Rows(trainset);
                    break;
                case NetworkMode.Test:
                    tmpArrStr = File.ReadAllLines(path + "test.txt");
                    testset = new double[tmpArrStr.Length, 16];
                    for (int i = 0; i < tmpArrStr.Length; i++)
                    {
                        tmpStr = tmpArrStr[i].Split(' ');
                        for (int j = 0; j < 16; j++)
                        {
                            testset[i, j] = double.Parse(tmpStr[j]);
                        }
                    }
                    Shuffling_Array_Rows(testset);
                    break;
            }
        }
        public void Shuffling_Array_Rows(double[,] arr)
        {
            Random random = new Random();
            for (int i = arr.GetLength(0) - 1; i > 0; --i)
            {
                int k = random.Next(i + 1);
                for (int j = 0; j < arr.GetLength(1); ++j)
                {
                    double t = arr[i, j];
                    arr[i, j] = arr[k, j];
                    arr[k, j] = t;
                }
            }
        }

    }
}
