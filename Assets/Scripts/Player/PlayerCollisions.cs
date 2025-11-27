using UnityEngine;
using System.Collections;

namespace lvl_0
{
    [RequireComponent(typeof(PlayerHealth))]
    public class PlayerCollisions : MonoBehaviour
    {
        private PlayerHealth m_playerHealth;

        private void Start()
        {
            m_playerHealth = GetComponent<PlayerHealth>();    
        }

        void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.tag == "Enemy")
            {
                m_playerHealth.TakeDamage(1);
                collision.gameObject.GetComponent<EnemyHealth>().TakeDamage(1);
            }
        }
    }
}
