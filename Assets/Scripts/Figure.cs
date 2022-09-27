using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Figure : MonoBehaviour
{
    GameManager gameManager;

    int id;
    public int ID => id;
    public FigureColorType _figureColorType;
    public FigureShapeType _figureShapeType;
    public int _figureLevel;

    public FigureCombine _figureCombine;


    // public List<GameObject> GetcollisionObject => collisionObject;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameManager.Instance;
        this.id = GetInstanceID();

        _figureCombine = this.GetComponent<FigureCombine>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown() {
        gameManager.CurrentFigure = this;
    }

    //private void OnMouseUp() {
    //    gameManager.CurrentFigure = null;
    //}

    private void OnMouseDrag()
    {
        Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        pos.z = 0;
        this.transform.position = pos;
    }

}
