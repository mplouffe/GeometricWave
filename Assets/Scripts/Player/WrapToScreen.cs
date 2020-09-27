using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WrapToScreen : MonoBehaviour
{
    public float xMin, xMax, yMin, yMax;

    // Start is called before the first frame update
    void Start()
    {

    }

    void Update()
    {
        if (transform.position.x < xMin)
        {
            transform.SetPositionAndRotation(new Vector3(xMax, transform.position.y, 0), transform.rotation);
        }
        else if (transform.position.x > xMax)
        {
            transform.SetPositionAndRotation(new Vector3(xMin, transform.position.y, 0), transform.rotation);
        }
        else if (transform.position.y < yMin)
        {
            transform.SetPositionAndRotation(new Vector3(transform.position.x, yMax, 0), transform.rotation);
        }
        else if (transform.position.y > yMax)
        {
            transform.SetPositionAndRotation(new Vector3(transform.position.x, yMin, 0), transform.rotation);
        }
    }
}
