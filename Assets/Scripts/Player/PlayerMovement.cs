using UnityEngine;
using System.Collections;
using UnityEngine.InputSystem;
using UnityEngine.UI;

[System.Serializable]
[RequireComponent(typeof(Rigidbody2D))]
/// <summary>
/// The basic player movement script.
/// </summary>
public class PlayerMovement : MonoBehaviour
{
    [Header("Player Controls")]
    [SerializeField]
    private InputAction m_moveAction;
    
    [Range(0f, 1f)]
    [SerializeField]
    private float m_deadZone;
 
    [SerializeField]
    private Rigidbody2D m_rigidBody;

    [Header("Vertical Motion")]

    [SerializeField]
    [Range(0f, 100f)]
    public float maxVerticalSpeed;

    [SerializeField]
    [Range(0f, 1f)]
    private float minVerticalSpeed;
    
    [SerializeField]
    [Range(0f, 100f)]
    private float m_verticalAcceleration;

    [SerializeField]
    [Range(0f, 100f)]
    private float m_verticalDrag;

    [Header("Horizontal Motion")]
    [SerializeField]
    [Range(0f, 100f)]
    public float maxHorizontalSpeed;
    [SerializeField]
    [Range(0f, 1f)]
    private float minHorizontalSpeed;
    [SerializeField]
    [Range(0f, 100f)]
    private float m_horiztonalAcceleration;
    [SerializeField]
    [Range(0f, 100f)]
    private float m_horizontalDrag;

    private Vector3 m_playerMotion;

    private void OnEnable()
    {
        m_moveAction.Enable();
        if (m_rigidBody == null)
        {
            m_rigidBody = GetComponent<Rigidbody2D>();
        }
    }

    private void OnDisable()
    {
        m_moveAction.Disable();
    }

    void FixedUpdate()
    {
        var movementInput = m_moveAction.ReadValue<Vector2>();
        float movementX = movementInput.x;
        float movementY = movementInput.y;

        m_playerMotion = Vector3.zero;

        if(movementY > m_deadZone)
        {
            if (m_rigidBody.velocity.y < maxVerticalSpeed)
            {
                m_playerMotion = gameObject.transform.up * m_verticalAcceleration;
            }

        }
        else if(movementY < -m_deadZone)
        {
            if (m_rigidBody.velocity.y > -maxVerticalSpeed)
            {
                m_playerMotion = -gameObject.transform.up * m_verticalAcceleration;
            }
        }
        else
        {
            if (Mathf.Abs(m_rigidBody.velocity.y) > minVerticalSpeed)
            {
                m_playerMotion.y = -m_rigidBody.velocity.y * m_verticalDrag;
            }
            else
            {
                m_playerMotion.y = -m_rigidBody.velocity.y;
            }
        }

        if (movementX > m_deadZone)
        {
            if (m_rigidBody.velocity.x < maxHorizontalSpeed)
            {
                m_playerMotion += gameObject.transform.right * m_horiztonalAcceleration;
            }

        }
        else if (movementX < -m_deadZone)
        {
            if (m_rigidBody.velocity.x > -maxHorizontalSpeed)
            {
                m_playerMotion += -gameObject.transform.right * m_horiztonalAcceleration;
            }
        }
        else
        {
            if (Mathf.Abs(m_rigidBody.velocity.x) > minHorizontalSpeed)
            {
                m_playerMotion.x += -m_rigidBody.velocity.x * m_horizontalDrag;
            }
            else
            {
                m_playerMotion.x += -m_rigidBody.velocity.x;
            }
        }


        m_rigidBody.AddForce(m_playerMotion);
    }
}