using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Laba_3_LITOVKA
{
    public partial class Form1 : Form
    {
        static double R = 8.31;
        static double E1 = 251000;
        static double E2 = 297000;
        static double A1 = 200000000000;
        static double A2 = 8000000000000;
        static double D = 0.1;
        static double Cj = 31 * 1.4 / 100/ 0.028;
        static double T = 1350;
        static double L = 160;
        static double m0 = 2.6;
        static double m1 = 3.0;
        static double k1 = A1 * Math.Exp(-E1 / R / T);
        static double k2 = A2 * Math.Exp(-E2 / R / T);
        static double p = 1.4;

        public double u(double m)
        {
            return m / (p * 3.14 * Math.Pow(D, 2) / 4);
        }
        public double d_C1( double C, double m)
        {
            return -k1 * C / u(m);
        }
        public double d_C2(double C1, double C2, double m)
        {
            return (k1 * C1 - k2 * C2 )/ u(m);
        }
        public Form1()
        {
            InitializeComponent();

            double C = Cj;
            double m = m0;
            chart1.Series[0].Points.Clear();
            for (double l = 0; l < L; l = l + 0.5)
            {
                chart1.Series[0].Points.AddXY(l, C);
                C = C + d_C1(C,m) * 0.5;

            }
            C = Cj;
            m = m + 0.15;
            chart1.Series[1].Points.Clear();
            for (double l = 0; l < L; l = l + 0.5)
            {
                chart1.Series[1].Points.AddXY(l, C);
                C = C + d_C1(C, m) * 0.5;

            }
            
            C = Cj;
            m = m + 0.15;
            chart1.Series[2].Points.Clear();
            for (double l = 0; l < L; l = l + 0.5)
            {
                chart1.Series[2].Points.AddXY(l, C);
                C = C + d_C1(C, m) * 0.5;

            }
//chart1.ChartAreas[0].AxisX.Maximum = 30;



            /////////////////////////////////////////////////////////////////////////

            double C2 = 0;
            C = Cj;
            m = m0;
            chart2.Series[0].Points.Clear();
            for (double l = 0; l < L; l = l + 0.5)
            {
                chart2.Series[0].Points.AddXY(l, C2);

                C = C + d_C1(C, m) * 0.5;
                C2 = C2 + d_C2(C, C2, m) * 0.5;

            }
            C2 = 0;
            C = Cj;
            m = m + 0.15;
            chart2.Series[1].Points.Clear();
            for (double l = 0; l < L; l = l + 0.5)
            {
                chart2.Series[1].Points.AddXY(l, C2);
                C = C + d_C1(C, m) * 0.5;
                C2 = C2 + d_C2(C, C2, m) * 0.5;

            }

            C2 = 0;
            C = Cj;
            m = m + 0.5;
            chart2.Series[2].Points.Clear();
            for (double l = 0; l < L; l = l + 0.5)
            {
                chart2.Series[2].Points.AddXY(l, C2);
                C = C + d_C1(C, m) * 0.5;
                C2 = C2 + d_C2(C,C2, m) * 0.5;

            }
           //chart2.ChartAreas[0].AxisX.Maximum = 30;
        }
    }
}
