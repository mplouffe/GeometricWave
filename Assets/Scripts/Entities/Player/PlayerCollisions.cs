using UnityEngine;
using System.Collections;

namespace lvl_0
{
    [RequireComponent(typeof(PlayerHealth))]
    public class PlayerCollisions : MonoBehaviour
    {
        [SerializeField]
        private LayerMask m_collisionLayerMask;

        private PlayerHealth m_playerHealth;

        private void Start()
        {
            m_playerHealth = GetComponent<PlayerHealth>();    
        }

        void OnCollisionEnter(Collision collision)
        {
            int otherLayer = collision.gameObject.layer;

            if ((m_collisionLayerMask.value & 1 << otherLayer) != 0)
            {
                m_playerHealth.TakeDamage(1);
                collision.gameObject.GetComponent<EntityHealth>().TakeDamage(1);
            }
        }
    }
}
