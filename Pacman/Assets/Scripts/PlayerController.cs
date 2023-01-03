using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private bool m_TargetSet = false;
    private Vector3 m_Target = new Vector3();
    private List<Node> m_GridPath;
    private float speed = 1.0f;

    public int GridPosX { get; private set; }
    public int GridPosY { get; private set; }

    // Start is called before the first frame update
    void Start()
    {
        m_TargetSet = false;
        m_Target = new Vector3(500, 500, 0);
        GridPosX = 0;
        GridPosY = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (m_TargetSet)
        {
            Vector3 direction = m_Target - transform.position;
            transform.position += direction.normalized * speed * Time.deltaTime;
            if ((m_Target - transform.position).magnitude <= 0.01f)
            {
                transform.position = m_Target;
                ReachTarget();
            }
        }
    }

    void SetTarget(Vector3 target)
    {
        m_Target = target;
        m_TargetSet = true;
        Debug.Log("Player got new target: " + m_Target.ToString());
    }

    void ReachTarget()
    {
        Debug.Log("Player reached target at " + m_Target.ToString());
        m_Target = new Vector3();

        if (m_GridPath.Count > 0)
        {
            SetNextTarget();
        }
        else
        {
            m_TargetSet = false;
        }
    }

    void SetNextTarget()
    {
        // pop the first element
        Node nextTarget = m_GridPath[0];
        m_GridPath.RemoveAt(0);

        GridPosX = nextTarget.GridPosX;
        GridPosY = nextTarget.GridPosY;

        m_Target = nextTarget.gameObject.transform.position;
        m_TargetSet = true;
    }

    public void SetGridPath(List<Node> nodes)
    {
        m_GridPath = nodes;

        if (!m_TargetSet)
        {
            if (m_GridPath.Count > 0)
            {
                SetNextTarget();
            }
        }
    }
}
