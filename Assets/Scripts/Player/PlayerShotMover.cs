using UnityEngine;
using System.Collections;

public class PlayerShotMover : MonoBehaviour
{
    [SerializeField]
    private Rigidbody2D m_rigidbody;

    [SerializeField]
    private float m_speed;

    [SerializeField]
    private GameObject m_shotSpark;    // a reference to the explosion that is generate when the shot hits something
    
    [SerializeField]
    private int m_damage = 1;          // the damage the shot deals

    private bool m_hit;                       // flag for if a hit has occured

    private void Awake()
    {
        if (m_rigidbody == null)
        {
            m_rigidbody = GetComponent<Rigidbody2D>();
        }
    }

    void OnEnable()
    {
        m_rigidbody.velocity = transform.up * m_speed;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Enemy")
        {
            other.GetComponent<EnemyHealth>().TakeDamage(m_damage);
            m_hit = true;
        }

        if (m_hit)
        {
            // TODO: Object Pool Shot Sparks
            Instantiate(m_shotSpark, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }


}

