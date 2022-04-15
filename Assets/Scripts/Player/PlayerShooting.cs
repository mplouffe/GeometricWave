using UnityEngine;
using System.Collections;
using UnityEngine.InputSystem;

/// <summary>
/// Player Shooting Class
/// the shooting script for the player
/// </summary>
public class PlayerShooting : MonoBehaviour {

    [SerializeField]
    private InputAction m_shotAction;

    [Header("Projectile Settings")]
    [SerializeField]
    private GameObject m_shot;

    [SerializeField]
    private Transform m_shotSpawn;
    
    [SerializeField]
    private float m_fireRate = 0.5F;
    
    [SerializeField]
    private float m_nextFire = 0.0F;

    private void OnEnable()
    {
        m_shotAction.Enable();
    }

    private void OnDisable()
    {
        m_shotAction.Disable();
    }

    void Update()
    {
        // if player is pressing shot and enough time has passed to shoot again
        if (m_shotAction.triggered && m_nextFire < Time.time)
        {
            // set the next time the player can shoot
            m_nextFire = Time.time + m_fireRate;

            // create the shot at the spawn position
            // TODO: Object pool this to manage GC
            GameObject clone = Instantiate(m_shot, m_shotSpawn.position, m_shotSpawn.rotation) as GameObject;
        }
    }
}
