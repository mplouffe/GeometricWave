using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Explodable))]
public class Death : MonoBehaviour {

    [SerializeField]
    private Explodable m_explodable;

    /// <summary>
    /// Death
    /// function to handle the killing of the enemy
    /// </summary>
    public virtual void Die()
    {
        m_explodable.explode();
        ExplosionForce ef = GameObject.FindObjectOfType<ExplosionForce>();
        ef.doExplosion(transform.position);
    }
}
