using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelCreator : MonoBehaviour
{
    [SerializeField] private GameObject NodeProto;

    // Start is called before the first frame update
    void Start()
    {
        CreateNodes(5, 3, 1.0f);
    }

    void CreateNodes(int sizeX, int sizeY, float distance)
    {
        //Debug.Log("NodeProto: " + NodeProto.name);
        for (int curX=0; curX<sizeX; ++curX)
        {
            for (int curY=0; curY<sizeY; ++curY)
            {
                GameObject newNode = Instantiate<GameObject>(NodeProto);
                newNode.transform.position = new Vector3(curX * distance, curY * distance, 0);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
