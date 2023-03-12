using System;
using System.ComponentModel;

namespace Exercicio2_1
{
    /// <summary>
    /// 1. Inicie o Visual Studio.NET
    /// 2. Crie um novo programa do tipo Console Application
    /// 3. Faça com que o programa peça 2 valores ao usuário do seguinte modo:
    /// Bem-vindo <nome do usuário> agora são<hora atual>.
    /// Digite o 1º valor para a soma:
    /// Digite o 2º valor para a soma:
    /// 4. Faça com que o programa exiba o resultado do seguinte modo:
    /// <nome do usuário>, o resultado da operação é<resultado>.
    /// </summary>
    internal class Program
    {   
        static void Main(string[] args)
        {
            Console.WriteLine("Bem-vindo {0}, agora são {1}.", Environment.UserName, System.DateTime.Now.Hour);

            Console.Write("Digite o 1º valor da soma: ");
            int vlr1 = int.Parse(Console.ReadLine());
            Console.Write("Digite o 2º valor da soma: ");
            int vlr2 = int.Parse(Console.ReadLine());

            Console.WriteLine("{0}, o resultado da operação é {1}", Environment.UserName, vlr1 + vlr2);
        }
    }
}