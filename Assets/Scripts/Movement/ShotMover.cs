using UnityEngine;
using System.Collections;

namespace lvl_0
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class ShotMover : MonoBehaviour
    {
        [SerializeField]
        private LayerMask m_collisionLayerMask;

        [SerializeField]
        private float m_speed;

        [SerializeField]
        private GameObject m_shotSparkPrefab;

        [SerializeField]
        private int damage = 1;

        private void Start()
        {
            // fire the bullet forward at the bullet's speed
            GetComponent<Rigidbody2D>().velocity = transform.up * m_speed;
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            int otherLayer = other.gameObject.layer;

            if ((m_collisionLayerMask.value & (1 << otherLayer)) != 0)
            {
                other.GetComponent<EntityHealth>().TakeDamage(damage);
                Instantiate(m_shotSparkPrefab, transform.position, transform.rotation);
                Destroy(gameObject);
            }
        }
    }
}
