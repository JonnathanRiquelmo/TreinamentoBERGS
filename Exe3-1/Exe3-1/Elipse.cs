namespace Exercicio3_1
{
    internal class Elipse : FiguraGeometrica
    {
        private double raio1, raio2;

        protected double Raio1 { get => raio1; set => raio1 = value; }
        protected double Raio2 { get => raio2; set => raio2 = value; }

        public Elipse(double raio1, double raio2)
        {
            this.Raio1 = raio1;
            this.Raio2 = raio2;
        }

        public override void CalcArea()
        {
             this.Area = Math.PI * (raio1 * raio2); 
        }

    }
}
