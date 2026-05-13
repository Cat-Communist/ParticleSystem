namespace ParcicleSystem
{
    public partial class Form1 : Form
    {
        List<Particle> particles = new List<Particle>();
        public Form1()
        {
            InitializeComponent();

            picDisplay.Image = new Bitmap(picDisplay.Width, picDisplay.Height);

            for (var i = 0; i < 250; i++)
            {
                var particle = new Particle();
                particle.x = picDisplay.Image.Width / 2;
                particle.y = picDisplay.Image.Height / 2;

                particles.Add(particle);
            }
        }

        private void UpdateState()
        {
            foreach (var particle in particles) 
            {
                var directionRadians = particle.direction * Math.PI / 180 ;
                particle.x += (float)(particle.speed * Math.Cos(directionRadians));
                particle.y += (float)(particle.speed * Math.Sin(directionRadians));
            }
        }

        private void Render(Graphics g)
        {
            foreach (var particle in particles)
            {
                particle.Draw(g);
            }
        }

        int counter = 0;
        private void timer1_Tick(object sender, EventArgs e)
        {
            counter++;

            UpdateState();

            using (var g =  Graphics.FromImage(picDisplay.Image))
            {
                g.Clear(Color.White);

                Render(g);
            }

            picDisplay.Invalidate();    
        }
    }
}