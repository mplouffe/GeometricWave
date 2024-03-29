﻿using UnityEngine;
using System.Collections;

public class DeathDropItem : Death {

    public GameObject item;

    /// <summary>
    /// Death
    /// function to handle the killing of the enemy and also drops an item
    /// a subclass of the Death class so that it can be passed as a variable into EnemyHealth scripts
    /// </summary>
    public override void Die()
    {
        base.Die();
        // create the explosion
        Instantiate(item, transform.position, transform.rotation);
    }
}
