using UnityEngine;
using System.Collections;
using UnityEngine.InputSystem;

[System.Serializable]
[RequireComponent(typeof(Rigidbody))]
/// <summary>
/// The basic player movement script.
/// </summary>
public class PlayerMovement : MonoBehaviour
{
    public InputAction moveAction;

    public float rotationSpeed;             // a modifier for the left and right speed
    public float acceleration;        // a modifier for the forward speed
    public float deceleration;            // a modifier for the backwards speed
    public float drag;                  // a modifier for the natural drag you experience as you let go of the controls
    public float rotationDrag;

    public float maxSpeed;
    public float minSpeed;
    public float minRotation;

    private Rigidbody rigidBody;

    private void OnEnable()
    {
        moveAction.Enable();
        rigidBody = GetComponent<Rigidbody>();
    }

    private void OnDisable()
    {
        moveAction.Disable();
    }

    void FixedUpdate()
    {
        var movementInput = moveAction.ReadValue<Vector2>();
        float movementX = movementInput.x;
        float movementY = movementInput.y;

        Vector3 linearAcceleration = new Vector3();

        if(movementY > 0)
        {
            if (rigidBody.velocity.magnitude < maxSpeed)
            {
                linearAcceleration = gameObject.transform.up * acceleration;
            }

        }
        else if(movementY < 0)
        {
            if (rigidBody.velocity.magnitude > minSpeed)
            {
                linearAcceleration = -(rigidBody.velocity.normalized * deceleration);
            }
        }
        else
        {
            if (rigidBody.velocity.magnitude > minSpeed)
            {
                linearAcceleration = -(rigidBody.velocity.normalized * drag);
            }
        }


        float torqueModifier = 0;
        if(movementX > 0)
        {
            torqueModifier = -rotationSpeed;
        }
        else if (movementX < 0)
        {
            torqueModifier = rotationSpeed;
        }
        else
        {
            if (rigidBody.angularVelocity.magnitude > minRotation)
            {
                if (rigidBody.angularVelocity.z < 0)
                {
                    torqueModifier = rotationDrag;
                }
                else if (rigidBody.angularVelocity.z > 0)
                {
                    torqueModifier = -rotationDrag;
                }
            }
        }

        rigidBody.AddForce(linearAcceleration);
        rigidBody.AddTorque(transform.forward * torqueModifier);
    }
}