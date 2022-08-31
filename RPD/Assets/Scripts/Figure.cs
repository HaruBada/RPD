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
        if (collisionCount == 2) // 3���� ������ ��ġ�� �����ϵ��� ���� ������ 3�� ȣ��..
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
