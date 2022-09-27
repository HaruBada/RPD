using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrayCircle_0 : MonoBehaviour, IFigure
{
    Figure figure;
    CombineManager combineManager;

    void Awake()
    {
        figure = GetComponent<Figure>();
        combineManager = CombineManager.Instance;
    }

    private void Start()
    {
        combineManager.Add_FIgure(this);
    }

    public int damage { get; set; }

    public void Die()
    {
    }

    public void Shot(Unit TargetUnit)
    {

    }

    public void Combine()
    {
        
    }


    // Update is called once per frame
    void Update()
    {
       
    }

}
