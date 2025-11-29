using UnityEngine;
using System.Collections;
using UnityEngine.InputSystem;

namespace lvl_0
{
    [RequireComponent(typeof(PlayerInputManager))]
    public class PlayerShooting : MonoBehaviour
    {

        [Header("Projectile Settings")]
        [SerializeField]
        private GameObject m_shot;

        [SerializeField]
        private Transform m_shotSpawn;

        [SerializeField]
        private float m_fireRate = 0.5F;

        [SerializeField]
        private float m_nextFire = 0.0F;

        private InputSource m_inputSource;

        private void Start()
        {
            m_inputSource = GetComponent<PlayerInputManager>().GetInputSource();
        }

        void Update()
        {
            // if player is pressing shot and enough time has passed to shoot again
            if (m_inputSource.Gameplay.Shoot.triggered && m_nextFire < Time.time)
            {
                // set the next time the player can shoot
                m_nextFire = Time.time + m_fireRate;

                // create the shot at the spawn position
                // TODO: Object pool this to manage GC
                GameObject clone = Instantiate(m_shot, m_shotSpawn.position, m_shotSpawn.rotation) as GameObject;
            }
        }
    }
}
