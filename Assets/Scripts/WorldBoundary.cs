using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class WorldBoundary : MonoBehaviour
{
    [SerializeField]
    private Collider2D m_collider;

    private void Awake()
    {
        if (m_collider == null)
        {
            m_collider = gameObject.GetComponent<Collider2D>();
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        Destroy(collision.gameObject);
    }
}
