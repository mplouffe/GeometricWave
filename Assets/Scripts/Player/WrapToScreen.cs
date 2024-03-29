﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class WrapToScreen : MonoBehaviour
{
    [SerializeField]
    private Rigidbody2D m_rigidBody;

    public float xMin, xMax, yMin, yMax;

    private void OnEnable()
    {
        if (m_rigidBody == null)
        {
            m_rigidBody = GetComponent<Rigidbody2D>();
        }
    }

    void FixedUpdate()
    {
        if (transform.position.x < xMin)
        {
            transform.SetPositionAndRotation(new Vector3(xMin, transform.position.y, 0), transform.rotation);
            m_rigidBody.velocity = new Vector2(0, m_rigidBody.velocity.y);
        }
        else if (transform.position.x > xMax)
        {
            transform.SetPositionAndRotation(new Vector3(xMax, transform.position.y, 0), transform.rotation);
            m_rigidBody.velocity = new Vector2(0, m_rigidBody.velocity.y);
        }
        
        if (transform.position.y < yMin)
        {
            transform.SetPositionAndRotation(new Vector3(transform.position.x, yMin, 0), transform.rotation);
            m_rigidBody.velocity = new Vector2(m_rigidBody.velocity.x, 0);
        }
        else if (transform.position.y > yMax)
        {
            transform.SetPositionAndRotation(new Vector3(transform.position.x, yMax, 0), transform.rotation);
            m_rigidBody.velocity = new Vector2(m_rigidBody.velocity.x, 0);
        }
    }
}
