using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour
{
    public static List<GameObject> Nodes;

    // Start is called before the first frame update
    void Start()
    {
        if (Nodes == null)
        {
            Nodes = new List<GameObject>();
        }
        Nodes.Add(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
