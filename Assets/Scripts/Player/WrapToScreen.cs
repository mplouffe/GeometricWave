using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class WrapToScreen : MonoBehaviour
{
    [SerializeField]
    private Rigidbody2D m_rigidBody;

    [SerializeField]
    private float m_xBound;

    [SerializeField]
    private float m_yBound;

    private void OnEnable()
    {
        if (m_rigidBody == null)
        {
            m_rigidBody = GetComponent<Rigidbody2D>();
        }
    }

    void FixedUpdate()
    {
        if (transform.position.x < -m_xBound)
        {
            transform.SetPositionAndRotation(new Vector3(-m_xBound, transform.position.y, 0), transform.rotation);
            m_rigidBody.velocity = new Vector2(0, m_rigidBody.velocity.y);
        }
        else if (transform.position.x > m_xBound)
        {
            transform.SetPositionAndRotation(new Vector3(m_xBound, transform.position.y, 0), transform.rotation);
            m_rigidBody.velocity = new Vector2(0, m_rigidBody.velocity.y);
        }
        
        if (transform.position.y < -m_yBound)
        {
            transform.SetPositionAndRotation(new Vector3(transform.position.x, -m_yBound, 0), transform.rotation);
            m_rigidBody.velocity = new Vector2(m_rigidBody.velocity.x, 0);
        }
        else if (transform.position.y > m_yBound)
        {
            transform.SetPositionAndRotation(new Vector3(transform.position.x, m_yBound, 0), transform.rotation);
            m_rigidBody.velocity = new Vector2(m_rigidBody.velocity.x, 0);
        }
    }
}
