using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParticleSystem
{
    public class Emitter
    {
        private List<Particle> particles = new List<Particle>();

        public List<Gravity.IImpactPoint> gravityPoints = new List<Gravity.IImpactPoint>();
        public int x;
        public int y;
        public float GravitationX = 0;
        public float GravitationY = 0;

        public int direction = 0;
        public int spreading = 0;
        public int speedMin = 1;
        public int speedMax = 10;
        public int radiusMin = 2;
        public int radiusMax = 10;
        public int lifeMin = 20;
        public int lifeMax = 100;

        public Color colorFrom = Color.Red;
        public Color colorTo = Color.FromArgb(0, Color.Magenta);

        public int particleCount = 500;

        public virtual void Reset(Particle particle)
        {
            particle.life = Particle.random.Next(lifeMin, lifeMax);

            particle.x = x;
            particle.y = y;

            var dir = direction + (float)Particle.random.Next(spreading) - spreading / 2;
            var speed = Particle.random.Next(speedMin, speedMax);

            particle.speedX = MathF.Cos(direction * MathF.PI / 180) * speed;
            particle.speedY = -MathF.Sin(direction * MathF.PI / 180) * speed;

            particle.radius = 2 + Particle.random.Next(10);
        }

        public void UpdateState()
        {
            foreach (var particle in particles)
            {
                particle.life -= 1;

                if (particle.life <= 0)
                {
                    Reset(particle);
                }
                else
                {
                    foreach (var point in gravityPoints)
                    {
                        point.ImpactParticle(particle);
                    }

                    particle.speedX += GravitationX;
                    particle.speedY += GravitationY;

                    particle.x += particle.speedX;
                    particle.y += particle.speedY;
                }
            }

            for (var i = 0; i < 10 && particles.Count < particleCount; i++)
            {
                var particle = new ParticleColorful();
                particle.fromColor = Color.Red;
                particle.toColor = Color.FromArgb(0, Color.Magenta);

                Reset(particle);

                particles.Add(particle);
            }
        }

        public void Render(Graphics g)
        {
            foreach (var particle in particles)
            {
                particle.Draw(g);
            }

            foreach (var point in gravityPoints)
            {
                point.Render(g);
            }
        }
    }

    public class TopEmitter() : Emitter
    {
        public int width;

        public override void Reset(Particle particle)
        {
            base.Reset(particle);

            particle.x = Particle.random.Next(width);
            particle.y = 0;
        }
    }
}
