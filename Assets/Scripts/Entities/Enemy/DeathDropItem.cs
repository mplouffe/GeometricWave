using UnityEngine;
using System.Collections;

namespace lvl_0
{
    public class DeathDropItem : EnemyDeath
    {

        [SerializeField]
        private GameObject item;

        public override void Die()
        {
            base.Die();
            Instantiate(item, transform.position, transform.rotation);
        }
    }
}
