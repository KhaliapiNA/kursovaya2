using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace kursovaya2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 f = new Form2();
            f.ShowDialog();
        }

        public double Dlina_xB, Dlina_yB, Mom, F, Dlina_xC, Dlina_yC, Alfa, Dlina_xD, Dlina_yD, Dlina_xE, Dlina_yE, q;
        public double X_A, Y_A, R_A, Ugol, R_B, Mom_A, Fx, Fy, CosAlpha, SinAlpha, Qx, Qy;

        private void button2_Click(object sender, EventArgs e)
        {
            button2.Enabled = false;


            F = (double)(numericUpDown1.Value);
            Alfa = (double)(numericUpDown2.Value);
            Dlina_xC = (double)(numericUpDown3.Value);
            Dlina_yC = (double)(numericUpDown4.Value);
            Mom = (double)(numericUpDown5.Value);
            Dlina_xD = (double)(numericUpDown13.Value);
            Dlina_yD = (double)(numericUpDown12.Value);
            Dlina_xE = (double)(numericUpDown11.Value);
            Dlina_yE = (double)(numericUpDown10.Value);
            q = (double)(numericUpDown14.Value);




            CosAlpha = Math.Cos(Alfa * Math.PI / 180);
            SinAlpha = Math.Sin(Alfa * Math.PI / 180);

            Fx = F * CosAlpha;
            Fy = F * SinAlpha;
            Qx = q * (Math.Abs(Dlina_xE - Dlina_xD));
            Qy = (Math.Abs(Dlina_yD - Dlina_yE)) * q;


            if (radioButton1.Checked == true)
            {

                X_A = Fx;
                Y_A = Fy - Qy;
                Mom_A = Mom + Fy * Dlina_xC - Fx * Dlina_yC - (Dlina_xD + (Dlina_xE - Dlina_xD) / 2) * Qy;
                R_A = Math.Sqrt(X_A * X_A + Y_A * Y_A);
                Ugol = Math.Acos(X_A / R_A);
                if ((X_A < 0 && Y_A < 0) || (X_A > 0 && Y_A < 0))
                    Ugol = -Ugol;

                textBox16.Text = Convert_Strig(Convert.ToString(X_A));
                textBox15.Text = Convert_Strig(Convert.ToString(R_A));
                textBox14.Text = Convert_Strig(Convert.ToString(Y_A));
                textBox13.Text = Convert_Strig(Convert.ToString(Ugol * 180 / Math.PI));
                textBox12.Text = Convert_Strig(Convert.ToString(Mom_A));

                textBox4.Text = Convert.ToString(Math.Cos(Alfa * Math.PI / 180));
                textBox5.Text = Convert.ToString(Math.Sin(Alfa * Math.PI / 180));
                textBox7.Text = Convert.ToString(F * Math.Cos(Alfa * Math.PI / 180));
                textBox6.Text = Convert.ToString(F * Math.Sin(Alfa * Math.PI / 180));
            }

            else
            {
                X_A = -Fx - Qy;
                Y_A = -Fy;
                Mom_A = -Mom - Fy * Dlina_xC + Fx * Dlina_yC + Qy * (Dlina_yD + Dlina_yE) / 2;
                R_A = Math.Sqrt(X_A * X_A + Y_A * Y_A);
                Ugol = Math.Acos(X_A / R_A);
                if ((X_A < 0 && Y_A < 0) || (X_A > 0 && Y_A < 0))
                    Ugol = -Ugol;

                textBox16.Text = Convert_Strig(Convert.ToString(X_A));
                textBox15.Text = Convert_Strig(Convert.ToString(R_A));
                textBox14.Text = Convert_Strig(Convert.ToString(Y_A));
                textBox13.Text = Convert_Strig(Convert.ToString(Ugol * 180 / Math.PI));
                textBox12.Text = Convert_Strig(Convert.ToString(Mom_A));

                textBox4.Text = Convert.ToString(CosAlpha);
                textBox5.Text = Convert.ToString(SinAlpha);
                textBox7.Text = Convert.ToString(Fx);
                textBox6.Text = Convert.ToString(Fy);
                textBox8.Text = Convert.ToString(Qy);
                textBox9.Text = Convert.ToString(Qx);
                textBox10.Text = Convert.ToString((Dlina_yD + Dlina_yE) / 2);
                textBox11.Text = Convert.ToString((Dlina_xD + Dlina_xE) / 2);



            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            F = 41.50;
            Alfa = 75;
            Dlina_xC = -1.40;
            Dlina_yC = -2.60;
            Mom = 19.0;
            Dlina_xD = -1.40;
            Dlina_yD = -0.20;
            Dlina_xE = -1.40;
            Dlina_yE = 1.10;
            q = -14.50;
            //F = 12.50;
            //Alfa = 50;
            //Dlina_xC = -1.4;
            //Dlina_yC = -2.10;
            //Mom = 15.40;
            //Dlina_xD = 1.6;
            //Dlina_yD = -2.10;
            //Dlina_xE = 1.6;
            //Dlina_yE = -0.20;
            //q = -2.50;
            numericUpDown1.Value = Convert.ToDecimal(F);
            numericUpDown2.Value = Convert.ToDecimal(Alfa - 180);
            numericUpDown3.Value = Convert.ToDecimal(Dlina_xC);
            numericUpDown4.Value = Convert.ToDecimal(Dlina_yC);
            numericUpDown5.Value = Convert.ToDecimal(Mom);
            numericUpDown13.Value = Convert.ToDecimal(Dlina_xD);
            numericUpDown12.Value = Convert.ToDecimal(Dlina_yD);
            numericUpDown11.Value = Convert.ToDecimal(Dlina_xE);
            numericUpDown10.Value = Convert.ToDecimal(Dlina_yE);
            numericUpDown14.Value = Convert.ToDecimal(q);
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            button2.Enabled = true;
            textBox16.Text = "";
            textBox15.Text = "";
            textBox14.Text = "";
            textBox13.Text = "";
            textBox12.Text = "";

        }


        public static string Convert_Strig(string s)
        {
            string str = string.Empty;

            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] == ',')
                {
                    s += "0000";
                    str += "," + s[i + 1] + s[i + 2] + s[i + 3];
                    return str;
                }
                str += s[i];
            }
            return str;
        }




        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            button2.Enabled = true;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            button2.Enabled = true;
        }
    }


}