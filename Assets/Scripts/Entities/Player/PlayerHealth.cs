using UnityEngine;
using System.Collections;
using UnityEngine.UI;

namespace lvl_0
{
    public class PlayerHealth : EntityHealth
    {
        [SerializeField]
        private GameObject player;

        private Slider m_healthSlider;
        private bool m_isDead;

        protected override void Awake()
        {
            base.Awake();
            // TODO: Slider updates should be event based
            m_healthSlider = GameObject.FindGameObjectWithTag("healthUI").GetComponent<Slider>();
            m_healthSlider.value = m_currentHealth;
        }

        public override void TakeDamage(int amount)
        {
            if (Manager.Instance.playerIsAlive)
            {
                // TODO: change this to event based
                Manager.Instance.damaged = true;
                int currentHealthValue = Mathf.Max(m_currentHealth - amount, 0);
                if (m_healthSlider != null)
                {
                    m_healthSlider.value = currentHealthValue;
                }
                base.TakeDamage(amount);
            }
        }

        public override void GetHealth(int amount)
        {
            base.GetHealth(amount);
            Manager.Instance.healed = true;
            m_healthSlider.value = m_currentHealth;
        }
    }
}
