using System;
using System.Runtime.Intrinsics.X86;

namespace Exercicio2_2
{
    /// <summary>
    /// 1. Inicie o Visual Studio.NET
    /// 2. Crie um novo programa do tipo Console Application
    /// 3. Crie uma classe chamada Calculadora
    /// 4. Crie uma variável privada chamada valorA do tipo Double
    /// 5. Crie uma variável privada chamada valorB do tipo Double
    /// 6. Implemente um método para cada uma das 4 operações básicas(Somar,
    /// Subtrair, Multiplicar e Dividir)
    /// 7. Crie o método construtor da classe Calculadora que receba 2 valores do tipo
    /// Double e os passe para as variáveis valorA e valorB
    /// 8. Solicite ao usuário que digite 2 valores, para os campos valorA e valorB
    /// 9. Na função Main da classe Program, instancie um objeto do tipo Calculadora,
    /// passando como parâmetros para o método construtor os valores digitados pelo usuário
    /// 10. Exiba para o usuário o resultado das 4 operações básicas.
    /// </summary>
    internal class Program
    {
        static void Main(string[] args)
        {
            Calculadora Calc;

            Console.Write("Digite o 1º valor: ");
            int valorA = int.Parse(Console.ReadLine());
            Console.Write("Digite o 2º valor: ");
            int valorB = int.Parse(Console.ReadLine());

            Calc = new Calculadora(valorA, valorB);

            Console.WriteLine(Calc.ExibirResultadoOperacoes());
        }
    }
}