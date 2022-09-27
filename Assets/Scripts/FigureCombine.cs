using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FigureCombine : MonoBehaviour
{
    Figure _figure;
    CombineManager _combineManager;

    List<Figure> collisionObject = new List<Figure>();

    public int _combineCount = 3;

    private void Start()
    {
        _figure = this.GetComponent<Figure>();
        _combineManager = CombineManager.Instance;
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        Figure other = collision.GetComponent<Figure>();

        if (other == null)
            return;

        //if (other.ID > _figure.ID)
        //    return;

        if (_figure._figureColorType != other._figureColorType
            || _figure._figureShapeType != other._figureShapeType
            || _figure._figureLevel != other._figureLevel
            )
            return;

        collisionObject.Add(other);

        if(collisionObject.Count >= _combineCount - 1)
        {
            _combineManager.Combine(collisionObject, _figure);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        // 태그 또는 레이어 검사를 먼저 진행하면 좋다 

        Figure other = collision.GetComponent<Figure>();
        if(other && collisionObject.Contains(other))
            collisionObject.Remove(other);
    }

}
