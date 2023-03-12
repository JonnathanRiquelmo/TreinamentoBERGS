namespace Exercicio3_2
{
    internal class Quadrado : Retangulo
    {
        double lado;
        
        public double Lado { get => lado; set => lado = value; }

        public Quadrado(double lado) : base(lado, lado)
        {
            this.Lado = lado;
        }



    }
}
