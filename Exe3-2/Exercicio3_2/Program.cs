using System.Collections;
using System;

namespace Exercicio3_2
{
    /// <summary>
    /// 1. Modifique o exercício 3.1 incluindo um ArrayList figuras.Toda vez que for
    /// instanciado um objeto da hierarquia de FiguraGeometrica, adicione o mesmo no
    /// ArrayList.
    /// 2. Modifique a classe Retangulo incluindo o método Perimetro público do tipo
    /// Double. (2 * lado1 + 2 * lado2)
    /// 3. Na saída do programa, percorra a lista exibindo todos os cálculos de área
    /// realizados e indique o tipo do objeto(Quadrado, Retângulo, Elipse, Círculo). Caso
    /// seja um objeto da hierarquia de Retangulo, então execute o método Perimetro
    /// mostrando na tela o perímetro do objeto.
    /// </summary>
    internal class Program
    {
        static void Main(string[] args)
        {
            ArrayList figuras = new ArrayList();

            Retangulo r = new Retangulo(8, 2); //16 mtrs²
            r.CalcArea();
            figuras.Add(r);

            Quadrado q = new Quadrado(5); //25 mtrs²
            q.CalcArea();
            figuras.Add(q);

            Elipse e = new Elipse(3, 5); // 47.12389 mtrs²
            e.CalcArea();
            figuras.Add(e);

            Circulo c = new Circulo(5, 0); // 78.57 mtrs²
            c.CalcArea();
            figuras.Add(c);

           

            foreach (FiguraGeometrica item in figuras)
            {                
                if (item.GetType() == typeof(Retangulo))
                {
                    Retangulo aux = (Retangulo)item;
                    Console.WriteLine($"Objeto RETANGULO com ÁREA DE {aux.Area} mtrs²");
                }
                else if (item.GetType() == typeof(Quadrado))
                {
                    Quadrado aux = (Quadrado)item;
                    Console.WriteLine($"Objeto QUADRADO com ÁREA DE {aux.Area} mtrs²");
                }
                else if (item.GetType() == typeof(Elipse))
                {
                    Elipse aux = (Elipse)item;
                    Console.WriteLine($"Objeto ELIPSE com ÁREA DE {aux.Area} mtrs²");
                }
                else if (item.GetType() == typeof(Circulo))
                {
                    Circulo aux = (Circulo)item;
                    Console.WriteLine($"Objeto CIRCULO com ÁREA DE {aux.Area} mtrs²");
                }

            }
        }
    }
}