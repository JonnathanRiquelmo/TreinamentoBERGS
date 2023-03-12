namespace Exercicio3_1
{
    internal class Circulo : Elipse
    {
        public Circulo(double raio1, double raio2) : base(raio1, raio2)
        {
            this.Raio1 = raio1;
            //this.Raio2 = 0;
        }

        public override void CalcArea()
        {
            this.Area = Math.PI * Math.Pow(Raio1, 2);
        }
    }
}
