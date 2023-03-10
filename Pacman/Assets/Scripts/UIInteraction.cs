using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIInteraction : MonoBehaviour
{
    [SerializeField]
    private PlayerController PlayerController;
    [SerializeField] private Camera Camera;

    // Start is called before the first frame update
    void Start()
    {
        PlayerController = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        Vector3 mousePos = Input.mousePosition;
        Vector3 worldPos = Camera.ScreenToWorldPoint(mousePos);
        Debug.Log("Got mouse click event at " + mousePos.ToString() + ", WorldPos: " + worldPos.ToString());
        worldPos.z = 0;

        // find node closest to this one
        float minDistance = 1000.0f;
        Vector3 closestPos = worldPos;
        Node closestNode = Node.Nodes[0,0].GetComponent<Node>();
        foreach (var node in Node.Nodes)
        {
            float curDistance = (node.transform.position - worldPos).magnitude;
            if (curDistance < minDistance)
            {
                minDistance = curDistance;
                closestNode = node.GetComponent<Node>();
                closestPos = node.transform.position;
            }
        }

        Debug.Log("This is at grid position (" + closestNode.GridPosX.ToString() + "," + closestNode.GridPosY.ToString() + ")");

        // now we have the grid position clicked - determine a path from the player position
        // just go straight lines
        int targetX = closestNode.GridPosX;
        int targetY = closestNode.GridPosY;

        // Create path to target
        List<Node> gridPath = new List<Node>();
        if ( System.Math.Abs(targetX-PlayerController.GridPosX) < System.Math.Abs(targetY-PlayerController.GridPosY) )
        {
            // vertical movement
            targetX = PlayerController.GridPosX;
            if (targetY > PlayerController.GridPosY)
            {
                for (int curY=PlayerController.GridPosY+1; curY <= targetY; ++curY)
                {
                    gridPath.Add(Node.Nodes[targetX, curY].GetComponent<Node>());
                }
            }
            else
            {
                for (int curY = PlayerController.GridPosY - 1; curY >= targetY; --curY)
                {
                    gridPath.Add(Node.Nodes[targetX, curY].GetComponent<Node>());
                }
            }
        }
        else
        {
            // horizontal movement
            targetY = PlayerController.GridPosY;
            if (targetX > PlayerController.GridPosX)
            {
                for (int curX = PlayerController.GridPosX + 1; curX <= targetX; ++curX)
                {
                    gridPath.Add(Node.Nodes[curX, targetY].GetComponent<Node>());
                }
            }
            else
            {
                for (int curX = PlayerController.GridPosX - 1; curX >= targetX; --curX)
                {
                    gridPath.Add(Node.Nodes[curX, targetY].GetComponent<Node>());
                }
            }
        }

        Debug.Log("Target: (" + targetX.ToString() + ", " + targetY.ToString() + ")");

        PlayerController.SetGridPath(gridPath);
    }
}
