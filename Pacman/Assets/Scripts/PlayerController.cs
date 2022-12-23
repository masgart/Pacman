using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private bool m_TargetSet = false;
    private Vector3 m_Target = new Vector3();
    private float speed = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
        m_TargetSet = false;
        m_Target = new Vector3(500, 500, 0);
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

    public void SetTarget(Vector3 target)
    {
        m_Target = target;
        m_TargetSet = true;
        Debug.Log("Player got new target: " + m_Target.ToString());
    }

    void ReachTarget()
    {
        m_Target = new Vector3();
        m_TargetSet = false;
    }
}
