using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitPaths : MonoBehaviour
{
    [SerializeField]
    List<GameObject> paths = new List<GameObject>();

    public List<GameObject> GetPaths => paths;

}
