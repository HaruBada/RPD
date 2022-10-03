using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum FigureColorType
{
    Gray,
    Red,
    Blue,
    Green,
    Max
}

public enum FigureShapeType
{
	Tri,
	Quad,
	Cir,
	Star,
	Dia,
	Heart,
    Max
}

public interface IFigure
{
    int damage { get; set; }
    void Shot();
    void Combine();
    void Die();
}
