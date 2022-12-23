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
        foreach (var node in Node.Nodes)
        {
            float curDistance = (node.transform.position - worldPos).magnitude;
            if (curDistance < minDistance)
            {
                minDistance = curDistance;
                closestPos = node.transform.position;
            }
        }

        PlayerController.SetTarget(closestPos);
    }
}
