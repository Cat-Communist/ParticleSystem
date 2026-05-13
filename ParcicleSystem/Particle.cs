using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.Automation;

namespace ParticleSystem
{
    public class Particle
    {
        public int radius;
        public float x;
        public float y;
        public float speedX;
        public float speedY;
        public float life;

        public static Random random = new Random();

        public Particle()
        {
            var direction = random.Next(360);
            var speed = 1 + random.Next(10);

            speedX = MathF.Cos(direction * MathF.PI / 180) * speed;
            speedY = -MathF.Sin(direction * MathF.PI / 180) * speed;

            radius = 2 + random.Next(10);
            life = 20 + random.Next(100);
        }

        public virtual void Draw(Graphics g)
        {
            float k = Math.Min(1f, life / 100); // Math.Min ограничивает k не выше 1.
            int alpha = (int)(k * 255);
            
            var color = Color.FromArgb(alpha, Color.Red);
            var b = new SolidBrush(color);

            g.FillEllipse(b, x - radius, y - radius, radius * 2, radius * 2);

            b.Dispose();
        }
    }

    public class ParticleColorful : Particle
    {
        public Color fromColor;
        public Color toColor;

        public static Color MixColor(Color color1, Color color2, float k)
        {
            return Color.FromArgb(
                (int)(color2.A * k + color1.A * (1 - k)),
                (int)(color2.R * k + color1.R * (1 - k)),
                (int)(color2.G * k + color1.G * (1 - k)),
                (int)(color2.B * k + color1.B * (1 - k))
            );
        }

        public override void Draw(Graphics g)
        {
            float k = Math.Min(1f, life / 100);

            var color = MixColor(toColor, fromColor, k);
            var b = new SolidBrush(color);

            g.FillEllipse(b, x - radius, y - radius, radius * 2, radius * 2);

            b.Dispose();
        }
    }
}
