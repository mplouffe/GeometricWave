using UnityEngine;
using System.Collections;

namespace lvl_0
{
    [RequireComponent(typeof(Explodable))]
    public class EnemyDeath : Death
    {

        [SerializeField]
        private Explodable m_explodable;

        public override void Die()
        {
            m_explodable.explode();
            // TODO: Use a singleton or events for this
            ExplosionForce ef = FindObjectOfType<ExplosionForce>();
            ef.doExplosion(transform.position);
        }
    }
}
