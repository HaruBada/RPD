using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum FigureColorType
{
    Gray,
    Red,
    Blue,
    Green
}

public enum FigureShapeType
{
	Tri,
	Quad,
	Cir,
	Star,
	Dia,
	Heart
}

public interface IFigure
{
    int damage { get; set; }
    void Shot(Unit TargetUnit);
    void Combine();
    void Die();
}
