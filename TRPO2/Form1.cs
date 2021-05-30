using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace TRPO2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void StartBTN_Click(object sender, EventArgs e) //кнопка начать
        {
            vGenerate();
            vMakeDispersion();
            vMakeIntervals();
        }

        private double fGenerateNumber(int x) //сгенерированное случайное число прозодит через 
                                              //формулу экспоненциального закона распределения 
        {
            double c; 
            c = 3 * Math.Exp((3 * -1) * x);
            return c; 
        }

        private List<double> values = new List<double>();

        private void vMakeIntervals()
        {
            /*
            int amount, counter = 0, j = 0;
            double interval, min = 100, max = -100;
            double[] array = new double[100];

            List<int> counters = new List<int>();
            values.Sort();
            min = values[0]; max = values[values.Count - 1];

            label3.Text = min.ToString(); label4.Text = max.ToString();

            amount = 10;
            interval = (max - min) / amount;

            double left = min, right = min + interval; //определение левой и правой границы интервала
          
            for (int i = 0; i < amount; i++)
            {
                foreach(double value in values)
                {
                    if (value >= left && value <= right) { counter++;  }
                }
                left += interval; right += interval;
                counters.Add(counter);
                
                counter = 0;
            }
           
            
            chart1.Series.Add(new Series("0"));
            chart1.Series["0"].Points.DataBindY(counters);*/
            chart1.Series.Clear();
            List<int> Counters = new List<int>();
            double Min = values[0], Max = values[values.Count - 1];
            double Interval = (Max - Min) / 10;
            double Left = Min, Right = Left + Interval;
            int counter = 0;
            for (int i = 0; i < 10; i++)
            {
                foreach (double j in values)
                {
                    if (j >= Left && j <= Right)
                    {
                        counter++; label3.Text = Interval.ToString();
                    }
                }
                Left += Interval;
                Right += Interval;
                Counters.Add(counter);
                counter = 0;
            }
            chart1.Series.Add(new Series("Exp")); // Создание нового чарта гистограммы и ее заполнение
            chart1.Series["Exp"].Points.DataBindY(Counters);

        }

        private void vMakeDispersion() //функция подсчета дисперсии
        {
            double a, D, sumvalueB = 0, sumvalueA = 0;

            foreach(double value in values)
            {
                a = Math.Sqrt(value);
                sumvalueA += a;
                sumvalueB += value;
            }

            double avgA = sumvalueA/99, avgB = Math.Sqrt(sumvalueB/99);

            D = avgA - avgB;
            label2.Text = avgA.ToString();
            label1.Text = D.ToString();

        }

        private void vGenerate() //генерация случайного числа
        {
            Random rnd = new Random();
            double value, sumValue = 0; int x;
            
            for(int i = 0; i < 100; i++)
            {
                /*if(i%10 == 0)
                {
                    this.chart1.Series[0].Points.Add(sumValue);
                    sumValue = 0;
                }*/

                x = rnd.Next(0, 50);
                value = fGenerateNumber(x);
                values.Add(value);
                sumValue += value;
                dataGridView1.Rows.Add(i, value);
            }
     
        }

    }
}
