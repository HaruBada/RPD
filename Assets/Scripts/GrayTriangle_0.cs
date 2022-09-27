using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrayTriangle_0 : MonoBehaviour,IFigure
{
    Figure figure;
    CombineManager combineManager;
    void Awake()
    {
        figure = GetComponent<Figure>();
        combineManager = CombineManager.Instance;
    }


    public int damage { get; set; }

    public void Combine()
    {
    }

    public void Die()
    {
    }

    public void Shot()
    {
    }

    // Start is called before the first frame update
    void Start()
    {
        combineManager.Add_FIgure(this);
    }

    // Update is called once per frame
    void Update()
    {
       
    }
}
