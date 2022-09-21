using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Figure : MonoBehaviour
{
    GameManager gameManager;
    
    List<GameObject> collisionObject = new List<GameObject>();

    public List<GameObject> GetcollisionObject => collisionObject;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        collisionObject.Add(collision.gameObject);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        collisionObject.Remove(collision.gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameManager.Instance;
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
