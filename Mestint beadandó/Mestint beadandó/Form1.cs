using Mestint_beadandó.Allapotter;
using Mestint_beadandó.Keresok;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mestint_beadandó
{
    public partial class Form1 : Form
    {
        // Változók
        List<Kereso> keresok = new List<Kereso>();
        List<Allapot> megoldasok = new List<Allapot>();
        int aktualisAllapotIndex = 0;
        
        
        public Form1()
        {
            InitializeComponent();
            // Keresők
            keresok.Add(new Szelessegi());
            keresok.Add(new Melysegi());
            keresok.Add(new BackTrack());
            keresok.Add(new BestFirst());
            //keresok.Add(new ProbaHiba());

            // Célfeltétel kép hozzáadása
            pictureBox3.ImageLocation = "célfeltétel.png";
            pictureBox3.SizeMode = PictureBoxSizeMode.StretchImage;

            //Comboboxhoz keresők hozzáadása
            foreach (Kereso kereso in keresok)
            {
                comboBox1.Items.Add(kereso.GetType().Name);
            }
            comboBox1.SelectedIndex = 0;

            // Konzolra kiiratás
            foreach (Kereso k in keresok)
            {
                Console.WriteLine(" \n----Utvonalak----\n" + k.GetType().Name + "\n------------");
                foreach (Allapot a in k.Utvonal)
                {
                    Console.WriteLine(a.ToString());
                }
            }

            // Listboxra kiiratás
            listBox1.Items.Add("--------------Utvonalak--------------\n");
            foreach (Kereso k in keresok)
            {
                listBox1.Items.Add("--------" + k.GetType().Name + "--------");
                foreach (Allapot a in k.Utvonal)
                {
                    
                    listBox1.Items.Add(a.ToString());
                }
            }
        }


        // Előző lépés
        private void button1_Click(object sender, EventArgs e)
        {
            if (aktualisAllapotIndex > 0) aktualisAllapotIndex--;
            Kirajzol();
        }

        // Kővetkező lépés
        private void button2_Click(object sender, EventArgs e)
        {
            if (megoldasok.Count - 1 > aktualisAllapotIndex) aktualisAllapotIndex++;
            Kirajzol();
        }

        // ComboBox
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            megoldasok = keresok[comboBox1.SelectedIndex].Utvonal;
            aktualisAllapotIndex = 0;
            Kirajzol();
        }

        // Sakktábla init
        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            Kirajzol();
            // Win kép megjelentitése
            if (aktualisAllapotIndex + 1 == megoldasok.Count)
            {
                Win();
            }
            else
            {
                pictureBox2.Image = null;
            }
        }

        // Teljesült feltétel kép:
        private void Win()
        {
            pictureBox2.ImageLocation = "win.png";
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        // Grafikus megjelenítés
        private void Kirajzol()
        {
            int pB_W = pictureBox1.Width;
            int pB_H = pictureBox1.Height;
            Bitmap image = new Bitmap(pB_W, pB_H);
            pictureBox1.Image = image;
            Graphics g = Graphics.FromImage(image);
            Color color1, color2;
            SolidBrush blackBrush, whiteBrush;

            // Sakktábla kirajzolása
            for (int i = 0; i < 3; i++)
            {
                if (i % 2 == 0)
                {
                    color1 = Color.Black;
                    color2 = Color.White;
                }
                else
                {
                    color1 = Color.White;
                    color2 = Color.Black;
                }

                blackBrush = new SolidBrush(color1);
                whiteBrush = new SolidBrush(color2);

                for (int j = 0; j < 2; j++)
                {
                    if (j % 2 == 0) g.FillRectangle(blackBrush, i * pB_W / 3, j * pB_H / 2, pB_W / 3, pB_H / 2);
                    else g.FillRectangle(whiteBrush, i * pB_W / 3, j * pB_H / 2, pB_W / 3, pB_H / 2);
                }
            }

            // Elemi lépésekhez
            Babuk[] babuk = megoldasok[aktualisAllapotIndex].Babuk;

            // Király megjelenítése
            Icon king = new Icon("king.ico");
            int kingX = (pB_W / 3) / 3 + (pB_W / 3) * babuk[0].Oszlop;
            int kingY = (pB_H / 2) / 2 + (pB_H / 2) * (1 - babuk[0].Sor);
            Rectangle rectKing = new Rectangle(kingX-100, kingY-140, 200, 200);
            g.DrawIconUnstretched(king, rectKing);

            // Futó1 megjelenítése
            Icon bishop1 = new Icon("bishop1.ico");
            int bishop1X = (pB_W / 3) / 3 + (pB_W / 3) * babuk[1].Oszlop;
            int bishop1Y = (pB_H / 2) / 2 + (pB_H / 2) * (1 - babuk[1].Sor);
            Rectangle rectbishop1 = new Rectangle(bishop1X - 100, bishop1Y - 140, 20, 20);
            g.DrawIconUnstretched(bishop1, rectbishop1);

            // Futó2 megjelenítése
            Icon bishop2 = new Icon("bishop2.ico");
            int bishop2X = (pB_W / 3) / 3 + (pB_W / 3) * babuk[2].Oszlop;
            int bishop2Y = (pB_H / 2) / 2 + (pB_H / 2) * (1 - babuk[2].Sor);
            Rectangle rectbishop2 = new Rectangle(bishop2X-100, bishop2Y-140, 20, 20);
            g.DrawIconUnstretched(bishop2, rectbishop2);

            // Bástya1 megjelenítése
            Icon rook1 = new Icon("rook1.ico");
            int rook1X = (pB_W / 3) / 3 + (pB_W / 3) * babuk[3].Oszlop;
            int rook1Y = (pB_H / 2) / 2 + (pB_H / 2) * (1-babuk[3].Sor);
            Rectangle rectrook1 = new Rectangle(rook1X-100, rook1Y-140, 20, 20);
            g.DrawIconUnstretched(rook1, rectrook1);

            // Bástya2 megjelenítése
            Icon rook2 = new Icon("rook2.ico");
            int rook2X = (pB_W / 3) / 3 + (pB_W / 3) * babuk[4].Oszlop;
            int rook2Y = (pB_H / 2) / 2 + (pB_H / 2) * (1 - babuk[4].Sor);
            Rectangle rectrook2 = new Rectangle(rook2X-100, rook2Y-140, 20, 20);
            g.DrawIconUnstretched(rook2, rectrook2);

            label1.Text = "Lépések száma (kezdőállapottal): " + megoldasok.Count;
        }
    }
}
