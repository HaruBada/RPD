using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Figure : MonoBehaviour
{
    int collisionCount;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        collisionCount += 1;
        Debug.Log("collistion Count : " + collisionCount);
        if (collisionCount == 2) // 3개의 도형이 겹치면 반응하도록 유도 하지만 3번 호출..
        {
            Debug.Log("collision 3");
            
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        collisionCount -= 1;
        Debug.Log("collistion Count : " + collisionCount);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
