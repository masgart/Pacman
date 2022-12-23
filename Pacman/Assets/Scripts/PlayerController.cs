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
        m_TargetSet = true;
        m_Target = new Vector3(500, 500, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (m_TargetSet)
        {
            Vector3 my_pos = transform.position;
            Vector3 direction = m_Target - my_pos;
            transform.position += direction.normalized * speed * Time.deltaTime;
        }
    }

    void SetTarget(Vector3 target)
    {
        m_Target = target;
        m_TargetSet = true;
    }

    void ReachTarget()
    {
        m_Target = new Vector3();
        m_TargetSet = false;
    }
}
