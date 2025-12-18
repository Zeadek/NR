using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using NumberRecognizer.NeuroNet;
using System.IO;

namespace NumberRecognizer
{
    public partial class Form1 : Form
    {
        private double[] inputPixels;
        private Network network;

        public Form1()
        {
            InitializeComponent();

            inputPixels = new double[15];
            network = new Network();
        }

        private void Changing_State_Pixel_Button_Click(object sender, EventArgs e)
        {
            if (((Button)sender).BackColor == Color.White){
                ((Button)sender).BackColor = Color.Black;
                inputPixels[((Button)sender).TabIndex] = 1;
            }
            else
            {
                ((Button)sender).BackColor = Color.White;
                inputPixels[((Button)sender).TabIndex] = 0;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void SaveTrainSample_Click(object sender, EventArgs e)
        {
            string path = AppDomain.CurrentDomain.BaseDirectory + "train.txt";
            string tmpStr = numericUpDown_NecessaryOutput.Value.ToString();

            for (int i =0;i<inputPixels.Length;i++)
            {
                tmpStr += " " + inputPixels[i].ToString();
            }
            tmpStr += "\n";

            File.AppendAllText(path, tmpStr);
        }

        private void SaveTestSample_Click(object sender, EventArgs e)
        {
            string path = AppDomain.CurrentDomain.BaseDirectory + "test.txt";
            string tmpStr = "";

            for (int i = 0; i < inputPixels.Length; i++)
            {
                tmpStr += " " + inputPixels[i].ToString();
            }
            tmpStr += "\n";

            File.AppendAllText(path, tmpStr);
        }

        private void Form1_Load_1(object sender, EventArgs e)
        {

        }

        private void button16_Click(object sender, EventArgs e)
        {

        }

        private void button_Recognize_Click(object sender, EventArgs e)
        {
            network.ForwardPass(network, inputPixels);
            label_Output.Text = network.Fact.ToList().IndexOf(network.Fact.Max()).ToString();
            label_probability.Text = (100 * network.Fact.Max()).ToString("0.00") + "%";
        }

        private void label_probability_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void chart_Event_Click(object sender, EventArgs e)
        {

        }

        private void Label_Output_Click(object sender, EventArgs e)
        {

        }

        private void Train_Click(object sender, EventArgs e)
        {
            network.Train(network);
            for (int i = 0; i < network.E_error_avr.Length; i++)
            {
                chart_Event.Series[0].Points.AddY(network.E_error_avr[i]);
            }
        }

        private void button16_Click_1(object sender, EventArgs e)
        {
            network.Test(network);
            for (int i = 0; i < network.E_error_avr.Length; i++)
            {
                chart_Event.Series[0].Points.AddY(network.E_error_avr[i]);
            }
        }

        private void veses_Click(object sender, EventArgs e)
        {
            string pathDirWeights = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "memory");

            if (Directory.Exists(pathDirWeights))
                Directory.Delete(pathDirWeights, true);

            chart_Event.Series[0].Points.Clear();

            network = new Network();
        }
    }
}
