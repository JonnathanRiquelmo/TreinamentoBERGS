﻿namespace Exercicio3_1
{
    internal abstract class FiguraGeometrica
    {
        private double area;

        public double Area { get => area; set => area = value; }

        public abstract void CalcArea();
    }
}
