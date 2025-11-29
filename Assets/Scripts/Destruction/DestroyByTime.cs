using UnityEngine;
using System.Collections;

public class DestroyByTime : MonoBehaviour {

    public float lifetime;      // how long the object will live until it is destroyed

	void Start () {
        // Destroy(has an overload that lets you give it the a duration (in seconds) before the
        // destroy is called on the game object
        Destroy(gameObject, lifetime);
	}
}
