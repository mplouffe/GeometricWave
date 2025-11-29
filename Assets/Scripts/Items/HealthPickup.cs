using UnityEngine;
using System.Collections;

namespace lvl_0
{
    public class HealthPickup : MonoBehaviour
    {
        [SerializeField]
        private LayerMask m_collectorMask;

        void OnTriggerEnter(Collider other)
        {
            int otherLayer = other.gameObject.layer;

            if ((m_collectorMask.value & 1 << otherLayer) != 0)
            {
                other.GetComponent<EntityHealth>().GetHealth(2);
                Destroy(gameObject);
            }
        }
    }
}
