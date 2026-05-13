using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ParticleSystem.Gravity;

namespace ParticleSystem
{
    public class Gravity
    {
        public abstract class IImpactPoint
        {
            public float x;
            public float y;

            public abstract void ImpactParticle(Particle particle);

            public void Render(Graphics g)
            {
                g.FillEllipse(
                    new SolidBrush(Color.Yellow),
                    x - 5,
                    y - 5,
                    10, 10
                );
            }
        }

        public class GravityPoint : IImpactPoint
        {
            public int Mass = 100;

            public override void ImpactParticle(Particle particle)
            {
                float dX = x - particle.x;
                float dY = y - particle.y;
                float r2 = MathF.Max(100, (dX * dX + dY * dY));
                float m = 100;

                particle.speedX += dX * m / r2;
                particle.speedY += dY * m / r2;
            }
        }

        public class AntiGravityPoint : IImpactPoint
        {
            public int Mass = 100;

            public override void ImpactParticle(Particle particle)
            {
                float dX = x - particle.x;
                float dY = y - particle.y;
                float r2 = MathF.Max(100, (dX * dX + dY * dY));
                float m = 100;

                particle.speedX -= dX * m / r2;
                particle.speedY -= dY * m / r2;
            }
        }
    }
}
