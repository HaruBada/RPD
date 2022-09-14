using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Figure : MonoBehaviour
{
    GameManager gameManager;
    List<GameObject> collisionObject = new List<GameObject>();

    [SerializeField]
    GameObject upgreatFigure;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        collisionObject.Add(collision.gameObject);
        if(gameManager.CurrentFigure && collisionObject.Count == 2)
        {
            for(int i = 0; i < 2; i++)
            {
                GameObject removeObject = collisionObject[0];
                collisionObject.RemoveAt(0);
                Destroy(removeObject);
            }
            GameObject upgreatedFigure = Instantiate(upgreatFigure);
            Destroy(gameObject);
        }
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
        Debug.Log("touch : " + this.name);
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
