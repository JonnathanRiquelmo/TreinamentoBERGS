namespace Exercicio3_1
{
    internal class Retangulo : FiguraGeometrica
    {
        protected double largura, altura;

        public Retangulo(double largura, double altura)
        {
            this.largura = largura;
            this.altura = altura;
        }

        public override void CalcArea()
        {
            Area = largura * altura;
        }

    }
}
