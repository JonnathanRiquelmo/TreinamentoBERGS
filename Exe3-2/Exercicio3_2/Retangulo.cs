namespace Exercicio3_2
{
    internal class Retangulo : FiguraGeometrica
    {
        protected double largura, altura;
        public double perimetro;

        public Retangulo(double largura, double altura)
        {
            this.largura = largura;
            this.altura = altura;
            this.perimetro = (2 * largura) + (2 * altura);
        }

        public override void CalcArea()
        {
            Area = largura * altura;
        }

    }
}
