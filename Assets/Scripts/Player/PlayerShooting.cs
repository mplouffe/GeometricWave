using UnityEngine;
using System.Collections;
using UnityEngine.InputSystem;

/// <summary>
/// Player Shooting Class
/// the shooting script for the player
/// </summary>
public class PlayerShooting : MonoBehaviour {

    public InputAction shotAction;

    public GameObject shot;             // reference to the object that will be spawned by the shot
    public Transform shotSpawn;         // reference to the location where the shot will be spawned
    public float fireRate = 0.5F;       // a wait time between shots
    public float nextFire = 0.0F;       // used to calculate if enough time has passed so you can shoot again

    private void OnEnable()
    {
        shotAction.Enable();
    }

    private void OnDisable()
    {
        shotAction.Disable();
    }

    void Update()
    {
        // if player is pressing shot and enough time has passed to shoot again
        if (shotAction.triggered && nextFire < Time.time)
        {
            // set the next time the player can shoot
            nextFire = Time.time + fireRate;
            // create the shot at the spawn position
            // TODO: Object pool this to manage GC
            GameObject clone = Instantiate(shot, shotSpawn.position, shotSpawn.rotation) as GameObject;
        }
    }
}
