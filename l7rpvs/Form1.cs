using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace l7rpvs
{
    public partial class Form1 : Form
    {
        string path = @"C:\fileProg\f1.txt";
        public Form1()
        {
            InitializeComponent();
        }

        public struct Data
        {
            public int day;
            public int month;
            public int year;
        }
        public struct Th
        {
            public string name;
            public int count;
            public Data date;
            public int price;

        }

        private void button1_Click(object sender, EventArgs e)
        {

            int monNow = 8;
            int monNew;
            try
            {
                monNew = Convert.ToInt32(textBox7.Text);

                StreamReader strR = new StreamReader(path);
                string line;
                string[,] words = new string[100, 100];
                int count = 0;

                while ((line = strR.ReadLine()) != null)
                {
                    string[] word = line.Split(new char[] { ' ' });
                    int c = Convert.ToInt32(word[4]);
                    int c2 = Convert.ToInt32(word[2]);
                    if ((c-monNow) >= 1 && c2>= int.Parse(textBox8.Text))
                    {
                        for (int i = 0; i < word.Length; i++)
                        {
                            words[count, i] = word[i]; // в двумерный массив записываем все записи с указаным годом
                        }
                        count++;
                    }
                }

                int N = count, l = 0;

                while (l < 2)
                {
                    int j = 0;

                    for (int i = 1; i < N; i++)
                    {
                        int f = Convert.ToInt32(words[j, 0].ToUpper().First());
                        if (Convert.ToInt32(words[j, 0].ToUpper().First()) > Convert.ToInt32(words[i, 0].ToUpper().First()))
                        {
                            string[] buffer = new string[6];
                            for (int k = 0; k < 6; k++)
                            {
                                buffer[k] = words[j, k];
                                words[j, k] = words[i, k];
                                words[i, k] = buffer[k];
                            }
                        }
                        j++;
                    }
                    l++;
                }

                string msg = "";

                for (int i = 0; i < N; i++)
                {
                    for (int k = 0; k < 6; k++)
                    {
                        msg += words[i, k] + " ";
                    }
                    msg += "\r\n";
                }

                textBox6.Text += msg;

                strR.Close();
            }
            catch
            {
                MessageBox.Show("Неверные данные", "Error!");
            }
        
    }

    private void button2_Click(object sender, EventArgs e)
        {
            Th a;
            a.name = textBox1.Text;
            a.count =Int32.Parse(textBox2.Text);
            a.price =Int32.Parse(textBox3.Text);
            string[] m = textBox4.Text.Split('/');
            a.date.day = Int32.Parse(m[0]);
            a.date.month = Int32.Parse(textBox4.Text.Split('/')[1]);
            a.date.year = Int32.Parse(textBox4.Text.Split('/')[2]);
            textBox5.Text += a.name + " " + a.count + " " + a.price + " " + a.date.day + "/" + a.date.month + "/" + a.date.year + "\r\n";
            StreamWriter strW = new StreamWriter(path, true);
            string str = a.name + " " + a.count + " " + a.price + " " + a.date.day + " " + a.date.month + " " + a.date.year;
            strW.WriteLine(str);
            strW.Close();

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
