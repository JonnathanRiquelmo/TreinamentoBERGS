namespace Exercicio3_1
{
    /// <summary>
    /// 1. Inicie o Visual Studio.NET
    /// 2. Crie um novo programa do tipo Console Application
    /// 3. Crie uma classe abstrata chamada FiguraGeometrica, com uma variável protegida
    /// do tipo double chamada “área” e um método abstrato chamado CalcArea do tipo
    /// void. Crie uma propriedade somente leitura “Area” para essa variável.
    /// 4. Crie uma classe chamada Retangulo que herde de FiguraGeometrica, com duas
    /// variáveis protegidas chamadas largura e altura do tipo Double.
    /// 5. Faça com que o construtor da classe receba os valores para os campos largura e
    /// altura.
    /// 6. Sobrescreva o método CalcArea, que implemente o cálculo da área do retângulo
    /// (área = largura * altura) e ponha o resultado na variável área.
    /// 7. Crie uma classe chamada Quadrado que herde de Retangulo.
    /// 8. Faça com que o construtor da classe receba apenas 1 valor para o campo lado do
    /// tipo Double.
    /// 9. Crie uma classe chamada Elipse que herde de FiguraGeometrica, com duas
    /// variáveis protegidas chamadas raio1 e raio2 do tipo Double.
    /// 10. Faça com que o construtor da classe receba os valores para os campos raio1 e
    /// raio2.
    /// 11. Sobrescreva o método CalcArea, que implemente o cálculo da área da elipse
    /// (área = "PI" * ((r1 + r2) / 2) ^ 2 e ponha o resultado na variável área.
    /// 12. Crie uma classe chamada Circulo que herde de Elipse.
    /// 13. Faça com que o construtor da classe receba apenas 1 valor para o campo raio do
    /// tipo Double.
    /// 14. Faça com que o programa apresente a opção de cálculo de área para cada um
    /// dos tipos acima. 
    /// </summary>
    internal class Program
    {
        static void Main(string[] args)
        {
            Retangulo r = new Retangulo(8 ,2); //16 mtrs²
            r.CalcArea();
            Quadrado q = new Quadrado(5); //25 mtrs²
            q.CalcArea();
            Elipse e = new Elipse(3, 5); // 47.12389 mtrs²
            e.CalcArea();
            Circulo c = new Circulo(5, 0); // 78.57 mtrs²
            c.CalcArea();

            Console.WriteLine($"Área Retangulo: {r.Area} ");
            Console.WriteLine($"Área Quadrado: {q.Area}");
            Console.WriteLine($"Área Elipse: {e.Area}");
            Console.WriteLine($"Área Circulo: {c.Area}");
        }
    }
}