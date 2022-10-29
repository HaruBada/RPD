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

public class Figure : MonoBehaviour
{
    GameManager _gameManager;

    int id;
    FigureData _figureData;
    public FigureData GetFigureData => _figureData;
    public int ID => id;
    public FigureShapeType _figureShapeType;
    public FigureColorType _figureColorType;
    public int _figureLevel;

    SpriteRenderer _spriteRenderer;

    public FigureCombine _figureCombine;
    FigureDataManager _figureDataManager;
    SpriteManager _spriteManager;
    CircleCollider2D _circleCollider;

    public bool isCombine = false;
    // public List<GameObject> GetcollisionObject => collisionObject;
    // Start is called before the first frame update

    public void Init(FigureData data)
    {
        _figureData = data;
        _figureShapeType = _figureData.shape;
        _figureColorType = _figureData.color;
        _figureLevel = _figureData.level;

        
        gameObject.name = $"{_figureShapeType} {_figureColorType} {_figureLevel}";
        SetSortingOrder(_gameManager.GetFigureSortingOrder(transform.position.y) + 1);
        ApplyFigure();
    }

    public void ApplyFigure()
    {
        _spriteRenderer.sprite = _spriteManager.GetFigureSprite(_figureData.sprite);
    }
    
    void Awake()
    {
        _figureDataManager = FigureDataManager.Instance;
        _figureDataManager.Get(_figureShapeType, _figureColorType, _figureLevel);
        _gameManager = GameManager.Instance;
        _spriteManager = SpriteManager.Instance;
        this.id = GetInstanceID();

        _figureCombine = this.GetComponent<FigureCombine>();
        _spriteRenderer = this.GetComponent<SpriteRenderer>();
        _circleCollider = this.GetComponent<CircleCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CheckMaxLevel()
    {
        if (_figureData.evolutions[0] != -1)
            return;

        _figureCombine.enabled = false;
        //_circleCollider.enabled = false;
    }    

    private void OnMouseDown() {
        _gameManager.CurrentFigure = this;
    }

    private void OnMouseUp()
    {
        SetSortingOrder(_gameManager.GetFigureSortingOrder(transform.position.y));
    }

    private void OnMouseDrag()
    {
        Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        pos.z = 0;
        this.transform.position = pos;

        SetSortingOrder(_gameManager.GetFigureSortingOrder(pos.y) + 100);
    }

    public void SetSortingOrder(int sortingOrder)
    {
        _spriteRenderer.sortingOrder = sortingOrder;
    }

}
