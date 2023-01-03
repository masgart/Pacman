using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelCreator : MonoBehaviour
{
    [SerializeField] private GameObject NodeProto;

    // Start is called before the first frame update
    void Start()
    {
        CreateNodes(21, 25, 0.3f);
    }

    void CreateNodes(int sizeX, int sizeY, float distance)
    {
        // clear node list
        Node.Nodes = new GameObject[sizeX,sizeY];
        
        // create the level
        NodeType[,] level = LevelGeneration.Generate(sizeX, sizeY);

        // place nodes for the level
        float offsetX = -((sizeX-1) * distance) / 2;
        float offsetY = -((sizeY-1) * distance) / 2;
        Debug.Log("level[0,0]: " + level[0, 0].ToString());
        for (int curX=0; curX<sizeX; ++curX)
        {
            for (int curY=0; curY<sizeY; ++curY)
            {
                GameObject newNode = Instantiate<GameObject>(NodeProto);
                // set image depending on level content
                switch (level[curX, curY])
                {
                    case NodeType.Collectable:
                        newNode.transform.Find("Collectable").gameObject.SetActive(true);
                        break;
                    case NodeType.Wall:
                        newNode.transform.Find("Wall").gameObject.SetActive(true);
                        break;
                    case NodeType.PowerUp:
                        newNode.transform.Find("PowerUp").gameObject.SetActive(true);
                        break;
                }
                newNode.transform.position = new Vector3(curX * distance + offsetX, curY * distance + offsetY, 0);
                newNode.GetComponent<Node>().GridPosX = curX;
                newNode.GetComponent<Node>().GridPosY = curY;

                // also add the new node to the node list
                Node.Nodes[curX,curY] = newNode;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
