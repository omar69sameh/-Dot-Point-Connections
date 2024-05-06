using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ProgressBar;

namespace Peoblwm_10
{
    public partial class Form1 : Form
    {
        int z = 0, i = 0, j = 0, v = 0;
        int ct = 0;
        int y, x;
        int y2;
        int ct2 = 0;
        int ct3 = 0;
        class cActor
        {
            public int x, y;
        }
        void line(int x, int y)
        {
            Graphics g = this.CreateGraphics();
            SolidBrush brush = new SolidBrush(Color.Green);
            Pen pen = new Pen(brush);
            g.DrawLine(pen, 0, y, this.ClientSize.Width, y);
        }
        void ellips(int x, int y, Color cl)
        {
            Graphics g = this.CreateGraphics();
            SolidBrush brush = new SolidBrush(cl);
            g.FillEllipse(brush, x, y, 12, 12);
        }
        List<cActor> upActors = new List<cActor>();
        List<cActor> downActors = new List<cActor>();
        public Form1()
        {
            this.Text = "Problem_10";
            this.MouseDown += Form1_MouseDown;
            this.KeyDown += Form1_KeyDown;

        }
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
            {
                if (i == j)
                {
                    ellips(upActors[i].x, upActors[i].y, Color.Blue);
                    i--;
                }
                else
                {
                    ellips(upActors[j].x, upActors[j].y, Color.Blue);
                    ellips(upActors[i].x, upActors[i].y, Color.Blue);
                    j--;
                    i--;
                }
                if (i < 0)
                {
                    i = upActors.Count - 1;
                }
                if (j < 0)
                {
                    j = upActors.Count - 1;
                }
                ellips(upActors[i].x, upActors[i].y, Color.DarkKhaki);
            }
            if (e.KeyCode == Keys.Right)
            {
                if (i == j)
                {
                    ellips(upActors[i].x, upActors[i].y, Color.Blue);
                    i++;
                }
                else
                {
                    ellips(upActors[j].x, upActors[j].y, Color.Blue);
                    ellips(upActors[i].x, upActors[i].y, Color.Blue);
                    j++;
                    i++;
                }
                if (i >= upActors.Count)
                {
                    i = 0;
                }
                if (j >= upActors.Count)
                {
                    j = 0;
                }
                ellips(upActors[i].x, upActors[i].y, Color.DarkKhaki);
            }
            if (e.KeyCode == Keys.Up)
            {
                if (z == v)
                {
                    ellips(downActors[z].x, downActors[z].y, Color.Red);
                    z--;
                }
                else
                {
                    ellips(downActors[v].x, downActors[v].y, Color.Red);
                    ellips(downActors[z].x, downActors[z].y, Color.Red);
                    z--;
                    v--;
                }
                if (z < 0)
                {
                    z = downActors.Count - 1;
                }
                if (v < 0)
                {
                    v = downActors.Count - 1;
                }
                ellips(downActors[z].x, downActors[z].y, Color.DarkKhaki);
            }
            if (e.KeyCode == Keys.Down)
            {
                if (z == v)
                {
                    ellips(downActors[z].x, downActors[z].y, Color.Red);
                    z++;
                }
                else
                {
                    ellips(downActors[v].x, downActors[v].y, Color.Red);
                    ellips(downActors[z].x, downActors[z].y, Color.Red);
                    z++;
                    v++;
                }
                if (z >= downActors.Count)
                {
                    z = 0;
                }
                if (v >= downActors.Count)
                {
                    v = 0;
                }
                ellips(downActors[z].x, downActors[z].y, Color.DarkKhaki);
            }
            if (e.KeyCode == Keys.Enter)
            {
                MessageBox.Show("top points");
                for (int i = 0; i < upActors.Count; i++)
                {
                    MessageBox.Show($"up, {upActors[i].x},{upActors[i].y}");
                }
                for (int i = 0; i < downActors.Count; i++)
                {
                    MessageBox.Show($"Down, {downActors[i].x},{downActors[i].y}");
                }
            }
        }
        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ct++;
                if (ct == 1)
                {
                    y = e.Y;
                    line(x, y);
                }
                else
                {
                    if (e.Y > y)
                    {
                        if (ct2 == 0)
                        {
                            y2 = e.Y;
                            x = e.X;
                            cActor pnn = new cActor();
                            pnn.x = x;
                            pnn.y = y2;
                            downActors.Add(pnn);
                            ellips(x, y2, Color.Red);
                            ct2++;
                            ct3 = 0;
                        }
                        else
                        {
                            MessageBox.Show("error");
                        }
                    }
                    else
                    {
                        if (ct3 == 0)
                        {
                            y2 = e.Y;
                            x = e.X;
                            cActor pnn = new cActor();
                            pnn.x = x;
                            pnn.y = y2;
                            upActors.Add(pnn);
                            ellips(x, y2, Color.Blue);
                            ct3++;
                            ct2 = 0;
                        }
                        else
                        {
                            MessageBox.Show("error");
                        }
                    }
                }
            }
        }
    }
}
