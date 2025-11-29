using UnityEngine;
using System.Collections;

namespace lvl_0
{
    [RequireComponent(typeof(Death))]
    public class EntityHealth : MonoBehaviour
    {
        [SerializeField]
        protected int m_baseHealth = 3;

        [SerializeField]
        protected int m_currentHealth;

        [SerializeField]
        protected Death m_death;

        private bool isDead;

        protected virtual void Awake()
        {
            m_death = GetComponent<Death>();
            m_currentHealth = m_baseHealth;
        }

        public virtual void TakeDamage(int amount)
        {
            if (isDead) return;

            int newHealth = m_currentHealth - amount;
            m_currentHealth = Mathf.Max(newHealth, 0);

            if (m_currentHealth == 0)
            {
                isDead = true;
                m_death.Die();
            }
        }

        public virtual void GetHealth(int amount)
        {
            int newHealth = m_currentHealth + amount;
            m_currentHealth = Mathf.Min(newHealth, m_baseHealth);
        }
    }
}
