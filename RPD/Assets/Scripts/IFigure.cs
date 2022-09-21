using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IFigure
{
    int damage { get; set; }
    void Shot();
    void Combine();
    void Die();
    int GetFIgureType { get; }
}
