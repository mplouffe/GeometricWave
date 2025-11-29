using UnityEngine;
using System.Collections;

namespace lvl_0
{
    public class PlayerDeath : Death
    {

        [SerializeField]
        private GameObject m_explosion;

        public override void Die()
        {
            Manager.Instance.playerIsAlive = false;
            Manager.Instance.playerLives--;

            if (m_explosion != null)
            {
                Instantiate(m_explosion, transform.position, transform.rotation);
            }

            Destroy(gameObject);
        }
    }
}
