using UnityEngine;
using System.Collections;



/// <summary>
/// EnemyMovement Script
/// </summary>
public class EnemyMovement : MonoBehaviour {

    [SerializeField]
    private Rigidbody2D m_rigidbody;

    [SerializeField]
    private float m_moveSpeed;         // the base speed of the enemy

    private void Awake()
    {
        if (m_rigidbody == null)
        {
            m_rigidbody = GetComponent<Rigidbody2D>();
        }
    }

    private void OnEnable()
    {
        var thrustForce = transform.up * m_moveSpeed;
        m_rigidbody.velocity = thrustForce;
    }
}
