using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelCreator : MonoBehaviour
{
    [SerializeField] private GameObject NodeProto;

    // Start is called before the first frame update
    void Start()
    {
        CreateNodes(21, 25, 0.2f);
    }

    void CreateNodes(int sizeX, int sizeY, float distance)
    {
        //Debug.Log("NodeProto: " + NodeProto.name);
        float offsetX = -((sizeX-1) * distance) / 2;
        float offsetY = -((sizeY-1) * distance) / 2;
        for (int curX=0; curX<sizeX; ++curX)
        {
            for (int curY=0; curY<sizeY; ++curY)
            {
                GameObject newNode = Instantiate<GameObject>(NodeProto);
                newNode.transform.position = new Vector3(curX * distance + offsetX, curY * distance + offsetY, 0);
                newNode.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
