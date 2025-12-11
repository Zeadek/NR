
namespace NumberRecognizer
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title1 = new System.Windows.Forms.DataVisualization.Charting.Title();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.button8 = new System.Windows.Forms.Button();
            this.button9 = new System.Windows.Forms.Button();
            this.button10 = new System.Windows.Forms.Button();
            this.button11 = new System.Windows.Forms.Button();
            this.button12 = new System.Windows.Forms.Button();
            this.button13 = new System.Windows.Forms.Button();
            this.button14 = new System.Windows.Forms.Button();
            this.button15 = new System.Windows.Forms.Button();
            this.SaveTrainSample = new System.Windows.Forms.Button();
            this.numericUpDown_NecessaryOutput = new System.Windows.Forms.NumericUpDown();
            this.buttonRecognize = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label_Output = new System.Windows.Forms.Label();
            this.label_probability = new System.Windows.Forms.Label();
            this.button_Recognize = new System.Windows.Forms.Button();
            this.chart_Event = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.Train = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_NecessaryOutput)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart_Event)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.White;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Location = new System.Drawing.Point(9, 177);
            this.button1.Margin = new System.Windows.Forms.Padding(4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(61, 56);
            this.button1.TabIndex = 0;
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.Changing_State_Pixel_Button_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.White;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Location = new System.Drawing.Point(70, 177);
            this.button2.Margin = new System.Windows.Forms.Padding(4);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(61, 56);
            this.button2.TabIndex = 1;
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.Changing_State_Pixel_Button_Click);
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.White;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Location = new System.Drawing.Point(132, 177);
            this.button3.Margin = new System.Windows.Forms.Padding(4);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(61, 56);
            this.button3.TabIndex = 2;
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.Changing_State_Pixel_Button_Click);
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.Color.White;
            this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button4.Location = new System.Drawing.Point(132, 233);
            this.button4.Margin = new System.Windows.Forms.Padding(4);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(61, 56);
            this.button4.TabIndex = 5;
            this.button4.UseVisualStyleBackColor = false;
            this.button4.Click += new System.EventHandler(this.Changing_State_Pixel_Button_Click);
            // 
            // button5
            // 
            this.button5.BackColor = System.Drawing.Color.White;
            this.button5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button5.Location = new System.Drawing.Point(70, 233);
            this.button5.Margin = new System.Windows.Forms.Padding(4);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(61, 56);
            this.button5.TabIndex = 4;
            this.button5.UseVisualStyleBackColor = false;
            this.button5.Click += new System.EventHandler(this.Changing_State_Pixel_Button_Click);
            // 
            // button6
            // 
            this.button6.BackColor = System.Drawing.Color.White;
            this.button6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button6.Location = new System.Drawing.Point(9, 233);
            this.button6.Margin = new System.Windows.Forms.Padding(4);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(61, 56);
            this.button6.TabIndex = 3;
            this.button6.UseVisualStyleBackColor = false;
            this.button6.Click += new System.EventHandler(this.Changing_State_Pixel_Button_Click);
            // 
            // button7
            // 
            this.button7.BackColor = System.Drawing.Color.White;
            this.button7.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button7.Location = new System.Drawing.Point(132, 290);
            this.button7.Margin = new System.Windows.Forms.Padding(4);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(61, 56);
            this.button7.TabIndex = 8;
            this.button7.UseVisualStyleBackColor = false;
            this.button7.Click += new System.EventHandler(this.Changing_State_Pixel_Button_Click);
            // 
            // button8
            // 
            this.button8.BackColor = System.Drawing.Color.White;
            this.button8.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button8.Location = new System.Drawing.Point(70, 290);
            this.button8.Margin = new System.Windows.Forms.Padding(4);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(61, 56);
            this.button8.TabIndex = 7;
            this.button8.UseVisualStyleBackColor = false;
            this.button8.Click += new System.EventHandler(this.Changing_State_Pixel_Button_Click);
            // 
            // button9
            // 
            this.button9.BackColor = System.Drawing.Color.White;
            this.button9.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button9.Location = new System.Drawing.Point(9, 290);
            this.button9.Margin = new System.Windows.Forms.Padding(4);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(61, 56);
            this.button9.TabIndex = 6;
            this.button9.UseVisualStyleBackColor = false;
            this.button9.Click += new System.EventHandler(this.Changing_State_Pixel_Button_Click);
            // 
            // button10
            // 
            this.button10.BackColor = System.Drawing.Color.White;
            this.button10.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button10.Location = new System.Drawing.Point(132, 347);
            this.button10.Margin = new System.Windows.Forms.Padding(4);
            this.button10.Name = "button10";
            this.button10.Size = new System.Drawing.Size(61, 56);
            this.button10.TabIndex = 11;
            this.button10.UseVisualStyleBackColor = false;
            this.button10.Click += new System.EventHandler(this.Changing_State_Pixel_Button_Click);
            // 
            // button11
            // 
            this.button11.BackColor = System.Drawing.Color.White;
            this.button11.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button11.Location = new System.Drawing.Point(70, 347);
            this.button11.Margin = new System.Windows.Forms.Padding(4);
            this.button11.Name = "button11";
            this.button11.Size = new System.Drawing.Size(61, 56);
            this.button11.TabIndex = 10;
            this.button11.UseVisualStyleBackColor = false;
            this.button11.Click += new System.EventHandler(this.Changing_State_Pixel_Button_Click);
            // 
            // button12
            // 
            this.button12.BackColor = System.Drawing.Color.White;
            this.button12.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button12.Location = new System.Drawing.Point(9, 347);
            this.button12.Margin = new System.Windows.Forms.Padding(4);
            this.button12.Name = "button12";
            this.button12.Size = new System.Drawing.Size(61, 56);
            this.button12.TabIndex = 9;
            this.button12.UseVisualStyleBackColor = false;
            this.button12.Click += new System.EventHandler(this.Changing_State_Pixel_Button_Click);
            // 
            // button13
            // 
            this.button13.BackColor = System.Drawing.Color.White;
            this.button13.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button13.Location = new System.Drawing.Point(132, 403);
            this.button13.Margin = new System.Windows.Forms.Padding(4);
            this.button13.Name = "button13";
            this.button13.Size = new System.Drawing.Size(61, 56);
            this.button13.TabIndex = 14;
            this.button13.UseVisualStyleBackColor = false;
            this.button13.Click += new System.EventHandler(this.Changing_State_Pixel_Button_Click);
            // 
            // button14
            // 
            this.button14.BackColor = System.Drawing.Color.White;
            this.button14.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button14.Location = new System.Drawing.Point(70, 403);
            this.button14.Margin = new System.Windows.Forms.Padding(4);
            this.button14.Name = "button14";
            this.button14.Size = new System.Drawing.Size(61, 56);
            this.button14.TabIndex = 13;
            this.button14.UseVisualStyleBackColor = false;
            this.button14.Click += new System.EventHandler(this.Changing_State_Pixel_Button_Click);
            // 
            // button15
            // 
            this.button15.BackColor = System.Drawing.Color.White;
            this.button15.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button15.Location = new System.Drawing.Point(9, 403);
            this.button15.Margin = new System.Windows.Forms.Padding(4);
            this.button15.Name = "button15";
            this.button15.Size = new System.Drawing.Size(61, 56);
            this.button15.TabIndex = 12;
            this.button15.UseVisualStyleBackColor = false;
            this.button15.Click += new System.EventHandler(this.Changing_State_Pixel_Button_Click);
            // 
            // SaveTrainSample
            // 
            this.SaveTrainSample.AutoSize = true;
            this.SaveTrainSample.BackColor = System.Drawing.Color.Transparent;
            this.SaveTrainSample.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.SaveTrainSample.Location = new System.Drawing.Point(328, 72);
            this.SaveTrainSample.Margin = new System.Windows.Forms.Padding(4);
            this.SaveTrainSample.Name = "SaveTrainSample";
            this.SaveTrainSample.Size = new System.Drawing.Size(188, 49);
            this.SaveTrainSample.TabIndex = 15;
            this.SaveTrainSample.Text = "Сохранить обуч.";
            this.SaveTrainSample.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.SaveTrainSample.UseVisualStyleBackColor = false;
            this.SaveTrainSample.Click += new System.EventHandler(this.SaveTrainSample_Click);
            // 
            // numericUpDown_NecessaryOutput
            // 
            this.numericUpDown_NecessaryOutput.Font = new System.Drawing.Font("Microsoft Sans Serif", 50.8F);
            this.numericUpDown_NecessaryOutput.Location = new System.Drawing.Point(213, 71);
            this.numericUpDown_NecessaryOutput.Margin = new System.Windows.Forms.Padding(4);
            this.numericUpDown_NecessaryOutput.Name = "numericUpDown_NecessaryOutput";
            this.numericUpDown_NecessaryOutput.Size = new System.Drawing.Size(94, 103);
            this.numericUpDown_NecessaryOutput.TabIndex = 16;
            // 
            // buttonRecognize
            // 
            this.buttonRecognize.AutoSize = true;
            this.buttonRecognize.BackColor = System.Drawing.Color.Transparent;
            this.buttonRecognize.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.buttonRecognize.Location = new System.Drawing.Point(328, 124);
            this.buttonRecognize.Margin = new System.Windows.Forms.Padding(4);
            this.buttonRecognize.Name = "buttonRecognize";
            this.buttonRecognize.Size = new System.Drawing.Size(188, 49);
            this.buttonRecognize.TabIndex = 17;
            this.buttonRecognize.Text = "Сохранить тест.";
            this.buttonRecognize.UseVisualStyleBackColor = false;
            this.buttonRecognize.Click += new System.EventHandler(this.SaveTestSample_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.8F);
            this.label1.Location = new System.Drawing.Point(208, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(200, 26);
            this.label1.TabIndex = 18;
            this.label1.Text = "Желаемый отклик";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label_Output
            // 
            this.label_Output.BackColor = System.Drawing.Color.SeaGreen;
            this.label_Output.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.8F);
            this.label_Output.Location = new System.Drawing.Point(12, 71);
            this.label_Output.Name = "label_Output";
            this.label_Output.Size = new System.Drawing.Size(100, 50);
            this.label_Output.TabIndex = 20;
            this.label_Output.Text = "Out";
            this.label_Output.Click += new System.EventHandler(this.Label_Output_Click);
            // 
            // label_probability
            // 
            this.label_probability.BackColor = System.Drawing.Color.SeaGreen;
            this.label_probability.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.8F);
            this.label_probability.Location = new System.Drawing.Point(16, 138);
            this.label_probability.Name = "label_probability";
            this.label_probability.Size = new System.Drawing.Size(152, 32);
            this.label_probability.TabIndex = 21;
            this.label_probability.Text = "Probability";
            this.label_probability.Click += new System.EventHandler(this.label_probability_Click);
            // 
            // button_Recognize
            // 
            this.button_Recognize.Location = new System.Drawing.Point(118, 71);
            this.button_Recognize.Name = "button_Recognize";
            this.button_Recognize.Size = new System.Drawing.Size(75, 35);
            this.button_Recognize.TabIndex = 22;
            this.button_Recognize.Text = "Распознать";
            this.button_Recognize.UseVisualStyleBackColor = true;
            this.button_Recognize.Click += new System.EventHandler(this.button_Recognize_Click);
            // 
            // chart_Event
            // 
            chartArea1.Name = "ChartArea1";
            this.chart_Event.ChartAreas.Add(chartArea1);
            this.chart_Event.Location = new System.Drawing.Point(213, 184);
            this.chart_Event.Name = "chart_Event";
            series1.BorderWidth = 3;
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series1.Name = "Series1";
            this.chart_Event.Series.Add(series1);
            this.chart_Event.Size = new System.Drawing.Size(518, 275);
            this.chart_Event.TabIndex = 23;
            this.chart_Event.Text = "chart1";
            title1.Name = "Title1";
            title1.Text = "График средних энергий ошибок";
            this.chart_Event.Titles.Add(title1);
            this.chart_Event.Click += new System.EventHandler(this.chart_Event_Click);
            // 
            // Train
            // 
            this.Train.Location = new System.Drawing.Point(118, 112);
            this.Train.Name = "Train";
            this.Train.Size = new System.Drawing.Size(75, 23);
            this.Train.TabIndex = 24;
            this.Train.Text = "Train";
            this.Train.UseVisualStyleBackColor = true;
            this.Train.Click += new System.EventHandler(this.Train_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkCyan;
            this.ClientSize = new System.Drawing.Size(743, 483);
            this.Controls.Add(this.Train);
            this.Controls.Add(this.chart_Event);
            this.Controls.Add(this.button_Recognize);
            this.Controls.Add(this.label_probability);
            this.Controls.Add(this.label_Output);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonRecognize);
            this.Controls.Add(this.numericUpDown_NecessaryOutput);
            this.Controls.Add(this.SaveTrainSample);
            this.Controls.Add(this.button13);
            this.Controls.Add(this.button14);
            this.Controls.Add(this.button15);
            this.Controls.Add(this.button10);
            this.Controls.Add(this.button11);
            this.Controls.Add(this.button12);
            this.Controls.Add(this.button7);
            this.Controls.Add(this.button8);
            this.Controls.Add(this.button9);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.Text = "FormMain";
            this.Load += new System.EventHandler(this.Form1_Load_1);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_NecessaryOutput)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart_Event)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.Button button10;
        private System.Windows.Forms.Button button11;
        private System.Windows.Forms.Button button12;
        private System.Windows.Forms.Button button13;
        private System.Windows.Forms.Button button14;
        private System.Windows.Forms.Button button15;
        private System.Windows.Forms.Button SaveTrainSample;
        private System.Windows.Forms.NumericUpDown numericUpDown_NecessaryOutput;
        private System.Windows.Forms.Button buttonRecognize;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label_Output;
        private System.Windows.Forms.Label label_probability;
        private System.Windows.Forms.Button button_Recognize;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart_Event;
        private System.Windows.Forms.Button Train;
    }
}

