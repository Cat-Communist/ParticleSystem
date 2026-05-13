using System;
using System.Security.Cryptography.X509Certificates;

namespace ParticleSystem
{
    public partial class Form1 : Form
    {
        Emitter emitter;

        public Form1()
        {
            InitializeComponent();

            picDisplay.Image = new Bitmap(picDisplay.Width, picDisplay.Height);

            emitter = new TopEmitter
            {
                width = picDisplay.Width,
                GravitationY = 0.25f
            };

            emitter.gravityPoints.Add(new Gravity.AntiGravityPoint
            {
                x = (float)(picDisplay.Width / 2),
                y = picDisplay.Height / 2
            });

            emitter.gravityPoints.Add(new Gravity.GravityPoint
            {
                x = (float)(picDisplay.Width * 0.25),
                y = picDisplay.Height / 2
            });

            emitter.gravityPoints.Add(new Gravity.GravityPoint
            {
                x = (float)(picDisplay.Width * 0.75),
                y = picDisplay.Height / 2
            });
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            emitter.UpdateState();

            using (var g = Graphics.FromImage(picDisplay.Image))
            {
                g.Clear(Color.Black);

                emitter.Render(g);
            }

            picDisplay.Invalidate();
        }

        private void picDisplay_MouseMove(object sender, MouseEventArgs e)
        {
            emitter.mMousePositionX = e.X;
            emitter.MousePositionY = e.Y;
        }
    }
}