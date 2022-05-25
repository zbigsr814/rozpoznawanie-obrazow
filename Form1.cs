using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace okrag
{
    public partial class Form1 : Form
    {
        Bitmap btm;
        List<Punkt> pktSrodkowe = new List<Punkt>();
        bool[,] tabOkr;


        public Form1()
        {
            InitializeComponent();
        }

        private void btnZaladuj_Click(object sender, EventArgs e)
        {
            btm = new Bitmap(@"..\..\obrazy\koll.jpg");
            btm = CreateNonIndexedImage(btm);
            pictureBox1.Width = btm.Width;
            pictureBox1.Height = btm.Height;
            pictureBox1.Image = btm;
        }

        public Bitmap CreateNonIndexedImage(Bitmap src)
        {
            Bitmap newBmp = new Bitmap(src.Width, src.Height, System.Drawing.Imaging.PixelFormat.Format32bppArgb);

            using (Graphics gfx = Graphics.FromImage(newBmp))
            {
                gfx.DrawImage(src, 0, 0);
            }

            return newBmp;
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            txtX.Text = (Cursor.Position.X-331).ToString();
            txtY.Text = (Cursor.Position.Y-110).ToString();
        }

        private void btnFProg_Click(object sender, EventArgs e)
        {
            Color clr;
            int r;

            for (int i = 0; i < btm.Width; i++)
            {
                for (int j = 0; j < btm.Height; j++)
                {
                    clr = btm.GetPixel(i, j);
                    r = clr.R;

                    if(r<40) btm.SetPixel(i, j, Color.Black);
                    else btm.SetPixel(i, j, Color.White);
                    
                }
            }
            pictureBox1.Image = btm;
        }

        private void btnSzary_Click(object sender, EventArgs e)
        {
            Color clr;
            int r, g, b, mix;
            for (int i = 0; i < btm.Width; i++)
            {
                for (int j = 0; j < btm.Height; j++)
                {
                    clr = btm.GetPixel(i, j);
                    r = clr.R;
                    g = clr.G;
                    b = clr.B;
                    mix = (r + g + b) / 3;
                    btm.SetPixel(i, j, Color.FromArgb(mix,mix,mix));
                }
            }
            pictureBox1.Image = btm;
        }

        private void btnRozmarz_Click(object sender, EventArgs e)
        {
            long mixR = 0;
            long mix = 0;
            int poziom = 5;
            Color clr;

            for (int i = 0; i < btm.Width; i++)
            {
                for (int j = 0; j < btm.Height; j++)
                {
                    mixR = 0;
                    mix = 0;

                    for (int k = -poziom / 2; k < poziom / 2; k++)
                    {

                        for (int l = -poziom / 2; l < poziom / 2; l++)
                        {
                            if (i + k > 0 && i + k < btm.Width && j + l > 0 && j + l < btm.Height)
                            {
                                clr = btm.GetPixel(i + k, j + l);

                                mixR = +clr.R;
                                mix = mix + mixR;
                            }
                        }
                    }
                    int srR = Convert.ToInt16(mix / (poziom * poziom));
                    btm.SetPixel(i, j, Color.FromArgb(srR, srR, srR));
                }
            }
            pictureBox1.Image = btm;
        }

        private void btnWyzSr_Click(object sender, EventArgs e)
        {
            int btmX, btmY;
            btmX = btm.Width;
            btmY = btm.Height;
            tabOkr = new bool[btmX, btmY];

            Color clr;

            for (int i = 0; i < btm.Width; i++)
            {
                for (int j = 0; j < btm.Height; j++)
                {
                    clr = btm.GetPixel(i, j);
                    if (clr.R > 200) tabOkr[i, j] = false;
                    else if (clr.R < 200) tabOkr[i, j] = true;
                }
            }

            int objXpocz = 0, objYpocz = 0;
            int objXkon = 0, objYkon = 0;
            bool jestObiekt = false;
            int cnt = 0;
            List<Punkt> srednia = new List<Punkt>();
            srednia.Clear();

            for (int i = 0; i < btmX; i++)
            {
                for (int j = 0; j < btmY; j++)
                {
                    if (jestObiekt == false && tabOkr[i, j] == true)
                    {
                        jestObiekt = true;
                        objXpocz = j;
                    }
                    if(jestObiekt==true && tabOkr[i,j]==false)
                    {
                        jestObiekt = false;
                        objXkon = j;
                        btm.SetPixel(i, (objXkon - objXpocz) / 2 + objXpocz, Color.Red);
                        srednia.Add(new Punkt(i, (objXkon - objXpocz) / 2 + objXpocz));
                    }
                }
            }
            pktSrodkowe.Clear();
            for (int j = 0; j < btmY; j++)
            {
                for (int i = 0; i < btmX; i++)
                {
                    if (jestObiekt == false && tabOkr[i, j] == true)
                    {
                        jestObiekt = true;
                        objXpocz = i;

                    }
                    else if (jestObiekt == true && tabOkr[i, j] == false)
                    {
                        jestObiekt = false;
                        objXkon = i;
                        btm.SetPixel((objXpocz + objXkon) / 2, j, Color.Red);
                        foreach (var pkt in srednia)
                        {
                            if((objXpocz + objXkon) / 2 == pkt.x && j == pkt.y)
                            {
                                pktSrodkowe.Add(new Punkt(pkt.x, pkt.y));
                                punkt(pkt.x, pkt.y, Color.Yellow, 5);
                            }
                        }
                    }
                }
            }

            pictureBox1.Image = btm;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            int y = Cursor.Position.Y-110;
            int x = Cursor.Position.X-331;

            punkt(x, y);
            pictureBox1.Image = btm;
            int cntP = 0, cntD = 0, cntL = 0, cntG = 0;

            while (tabOkr[x+cntP, y] == true) cntP++;
            while (tabOkr[x, y+ cntD] == true) cntD++;
            while (tabOkr[x - cntL, y] == true) cntL++;
            while (tabOkr[x, y - cntG] == true) cntG++;
            MessageBox.Show(cntP.ToString() + "--" + cntD.ToString() + "  " + cntL.ToString() + "--" + cntG.ToString());
        }

        void prostaPozioma(int x, int y, int dlugoscX)
        {
            for (int i = -dlugoscX/2; i < dlugoscX/2; i++)
            {
                if(x + i >= 0 && x + i < btm.Width)
                {
                    btm.SetPixel(x + i, y, Color.Red);
                }
            }
        }

        void prostaPozioma(int x, int y)
        {
            for (int i = 0; i < btm.Width; i++)
            {
                 btm.SetPixel(i, y, Color.Red);
            }
        }

        void punkt(int x, int y)
        {
            int rozmiar = 5;

            for (int j = -rozmiar/2; j < rozmiar/2; j++)
            {
                for (int k = -rozmiar / 2; k < rozmiar; k++)
                {
                    if (x + j > 0 && x + j < btm.Width && y + k > 0 && y + k < btm.Height)
                    {
                        btm.SetPixel(x + j, y + k, Color.Red);
                    }
                        
                }
            }
        }

        void punkt(int x, int y, Color clr)
        {
            int rozmiar = 5;

            for (int j = -rozmiar / 2; j < rozmiar / 2; j++)
            {
                for (int k = -rozmiar / 2; k < rozmiar; k++)
                {
                    if (x + j > 0 && x + j < btm.Width && y + k > 0 && y + k < btm.Height)
                    {
                        btm.SetPixel(x + j, y + k, clr);
                    }

                }
            }
        }

        void punkt(int x, int y, Color clr, int rozmiar)
        {
            for (int j = -rozmiar / 2; j < rozmiar / 2; j++)
            {
                for (int k = -rozmiar / 2; k < rozmiar; k++)
                {
                    if (x + j > 0 && x + j < btm.Width && y + k > 0 && y + k < btm.Height)
                    {
                        btm.SetPixel(x + j, y + k, clr);
                    }

                }
            }
        }

        public class Punkt
        {
            public int x;
            public int y;

            public Punkt(int x, int y)
            {
                this.x = x;
                this.y = y;
            }

            public void NadpiszPkt(int x, int y)
            {
                this.x = x;
                this.y = y;
            }
        }

        void RysPix(int x, int y)
        {
            if (x > 0 && x < btm.Width && y > 0 && y < btm.Height)
                btm.SetPixel(x,y, Color.Orange);
        }

        private void btnSprOkrag_Click(object sender, EventArgs e)
        {
            bool znalezionoFigure = false;
            foreach (var pkt in pktSrodkowe)
            {
                int cntP = 0, cntD = 0, cntL = 0, cntG = 0;
                int cntGP = 0, cntGL = 0, cntDP = 0, cntDL = 0;

                try
                {
                    while (tabOkr[pkt.x + cntP, pkt.y] == true) { cntP++; }//RysPix(pkt.x + cntP, pkt.y); }
                    while (tabOkr[pkt.x, pkt.y + cntD] == true) { cntD++; }//RysPix(pkt.x, pkt.y + cntD); }
                    while (tabOkr[pkt.x - cntL, pkt.y] == true) { cntL++; }//RysPix(pkt.x - cntL, pkt.y); }
                    while (tabOkr[pkt.x, pkt.y - cntG] == true) { cntG++; }//RysPix(pkt.x, pkt.y - cntG); }

                    while (tabOkr[pkt.x + cntDP, pkt.y + cntDP] == true) { cntDP++; }//RysPix(pkt.x + cntDP, pkt.y + cntDP); }
                    while (tabOkr[pkt.x - cntGL, pkt.y - cntGL] == true) { cntGL++; }//RysPix(pkt.x - cntGL, pkt.y - cntGL); }
                    while (tabOkr[pkt.x + cntGP, pkt.y - cntGP] == true) { cntGP++; }//RysPix(pkt.x + cntGP, pkt.y - cntGP); }
                    while (tabOkr[pkt.x - cntDL, pkt.y + cntDL] == true) { cntDL++; }//RysPix(pkt.x - cntDL, pkt.y + cntDL); }

                    int procentTolerancji = 14;
                    int parKola = (procentTolerancji * cntP) / 100;

                    int[] promienie = new int[8] { cntD, cntL, cntG, cntP, cntGL, cntGP, cntDL, cntDP };
                    Odchylenie odch = new Odchylenie(promienie);

                    if (cntD >= cntG - parKola && cntD <= cntG + parKola
                        && cntD >= cntL - parKola && cntD <= cntL + parKola
                        && cntD >= cntP - parKola && cntD <= cntP + parKola)
                    {
                        if (cntGP >= cntGL - parKola && cntGP <= cntGL + parKola
                        && cntGP >= cntDP - parKola && cntGP <= cntDP + parKola
                        && cntGP >= cntDL - parKola && cntGP <= cntDL + parKola)
                        {
                            punkt(pkt.x, pkt.y, Color.Red, 5);
                            znalezionoFigure = true;
                            MessageBox.Show("Wykryto koło\n" +
                                "Promień uśredniony: " + odch.srednia.ToString() + "pix\n" +
                                "Odchylenie: " + odch.odchylenie.ToString());
                        }
                    }
                }
                catch(IndexOutOfRangeException)
                {

                }
                pictureBox1.Image = btm;
            }
            if (znalezionoFigure == false) MessageBox.Show("Nie znaleziono żadnych figur geometrycznych");
        }

        class Odchylenie
        {
            public double srednia = 0;
            public double odchylenie = 0;

            public Odchylenie(int[] promienie)
            {
                double suma = 0;
                foreach (int promien in promienie)
                {
                    suma += promien;
                }
                srednia = suma / promienie.Length;
                suma = 0;

                foreach (double promien in promienie)
                {
                    suma += ((promien-srednia) * (promien-srednia));
                }
                odchylenie = Math.Sqrt(suma / promienie.Length);
            }
        }
    }
}
