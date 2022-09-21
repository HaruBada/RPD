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

    int getFigureType = 0;

    public int GetFIgureType => getFigureType;

    public void Die()
    {
    }

    public void Shot()
    {
    }

    public void Combine()
    {
        
    }


    // Update is called once per frame
    void Update()
    {
       if(figure.GetcollisionObject.Count > 1 && combineManager.IsCombining == false)
       {
            combineManager.IsCombining = true;
            combineManager.Combine(figure.GetcollisionObject,this.gameObject);
        }
    }

}
