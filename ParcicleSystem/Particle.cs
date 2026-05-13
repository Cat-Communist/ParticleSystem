using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParcicleSystem
{
    internal class Particle
    {
        public int radius;
        public float x;
        public float y;

        public float direction;
        public float speed;

        public static Random random = new Random();

        public Particle()
        {
            direction = random.Next(360);
            speed = 1 + random.Next(10);
            radius = 2 + random.Next(10);
        }

        public void Draw(Graphics g)
        {
            var b = new SolidBrush(Color.Red);

            g.FillEllipse(b, x - radius, y - radius, radius * 2, radius * 2);

            b.Dispose();
        }
    }
}
