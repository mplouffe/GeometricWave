using UnityEngine;
using System.Collections;

namespace lvl_0
{
    public class DestroyByBoundary : MonoBehaviour
    {
        void OnTriggerExit(Collider other)
        {
            // if the object has left the boundary box colider:
            // if it is another object with a death element, call it's Die function
            // if it doesn't have a death object, just destroy it
            if (other.gameObject.GetComponent<Death>())
            {
                other.gameObject.GetComponent<Death>().Die();
            }
            else
            {
                Destroy(other.gameObject);
            }
        }
    }
}
