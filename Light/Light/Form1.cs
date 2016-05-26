using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Light
{
    public partial class Form1 : Form,IDisposable
    {
        public Form1()
        {
            InitializeComponent();
        }
        public void PaintSquare(Square sq, int series)
        {
            if (sq is Square)
            {
                for (int i = 0; i < 4; i++)
                {
                    chart1.Series[series].Points.AddXY(sq[i].X, sq[i].Y);
                }
                chart1.Series[series].Points.AddXY(sq[0].X, sq[0].Y);
                chart1.Series[series].Points.AddXY(sq[3].X, sq[3].Y);
            }
        }

        ContainerForMinMaxValue con;

        public int  FindShadowSquare(out double perCent)
        {
            //for square 1 
            int WidthOfSq1 = con[1].X - con[0].X;
            int HeightOfSq1 = con[1].Y - con[0].Y;
            int WidthOfSq2 = con[3].X - con[2].X;
            int HeightOfSq2 = con[3].Y - con[2].Y;
            int TotalLeftX = con[0].X;
            int TotalRighX = con[0].X;
            int TotalDownY = con[0].Y;
            int TotalUpY = con[0].Y;
            for (int i = 0; i < con.Count; i++)
            {
                if (con[i].X < TotalLeftX)
                {
                    TotalLeftX = con[i].X;
                }
                if (con[i].X > TotalRighX)
                {
                    TotalRighX = con[i].X;
                }
                if (con[i].Y < TotalDownY)
                {
                    TotalDownY = con[i].Y;
                }
                if (con[i].Y > TotalUpY)
                {
                    TotalUpY = con[i].Y;
                }
            }
            int totalWidth = TotalRighX - TotalLeftX;
            int totalHeight = TotalUpY - TotalDownY;
            int widthOfShadow = WidthOfSq2 - (totalWidth - WidthOfSq1);
            int heightOfShadow = HeightOfSq2 - (totalHeight - HeightOfSq1);
            int shadowSquare = 0;
            int AreaSq1 = HeightOfSq1 * WidthOfSq1;
            if ((con[3].X < con[0].X) || (con[1].X < con[2].X))
            {
                shadowSquare = AreaSq1;
                perCent = 100;
            }
            else if ((con[3].Y < con[0].Y) || (con[1].Y < con[2].Y))
            {
                shadowSquare = AreaSq1;
                perCent = 100;
            }
            else
            {
                shadowSquare = widthOfShadow * heightOfShadow;
                perCent = 100 - ((shadowSquare * 100) / AreaSq1);
            }
            
           
            return shadowSquare;
        }


        private void button1_Click(object sender, EventArgs e)
        {
            chart1.Series[0].Points.Clear();
            chart1.Series[1].Points.Clear();
            con = new ContainerForMinMaxValue();
            Square sq1 = new Square(new Point(Convert.ToInt16(textBox1.Text.Split(',')[0]), 
                                              Convert.ToInt16(textBox1.Text.Split(',')[1])),
                                    new Point(Convert.ToInt16(textBox2.Text.Split(',')[0]),
                                              Convert.ToInt16(textBox2.Text.Split(',')[1])),
                                    new Point(Convert.ToInt16(textBox3.Text.Split(',')[0]), 
                                              Convert.ToInt16(textBox3.Text.Split(',')[1])),
                                    new Point(Convert.ToInt16(textBox4.Text.Split(',')[0]), 
                                              Convert.ToInt16(textBox4.Text.Split(',')[1])));
            PaintSquare(sq1, 0);
            Square sq2 = new Square(new Point(Convert.ToInt16(textBox5.Text.Split(',')[0]),
                                              Convert.ToInt16(textBox5.Text.Split(',')[1])),
                                    new Point(Convert.ToInt16(textBox6.Text.Split(',')[0]), 
                                              Convert.ToInt16(textBox6.Text.Split(',')[1])),
                                    new Point(Convert.ToInt16(textBox7.Text.Split(',')[0]), 
                                              Convert.ToInt16(textBox7.Text.Split(',')[1])),
                                    new Point(Convert.ToInt16(textBox8.Text.Split(',')[0]), 
                                              Convert.ToInt16(textBox8.Text.Split(',')[1])));
            PaintSquare(sq2, 1);
            
            sq1.MinMax();
            con.Add(sq1);
            sq2.MinMax();
            con.Add(sq2);
            Console.WriteLine();
            double perCent; 
            MessageBox.Show("Shadow Square area", FindShadowSquare(out perCent).ToString());
            MessageBox.Show("Light %", perCent.ToString());
            Dispose(sq1);
            Dispose(sq2);
            Dispose(con);
            
        
            
        }
        private void Dispose(Square sq)
        {
            GC.SuppressFinalize(sq);
        }
         private void Dispose(ContainerForMinMaxValue con)
        {
            GC.SuppressFinalize(con);
        }
       
    }
}
