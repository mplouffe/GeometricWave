using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FragmentLifetime : MonoBehaviour
{
    [SerializeField]
    private MeshRenderer m_spriteMaterial;

    [SerializeField]
    private float m_blinkDuration;

    [SerializeField]
    private float m_fragmentLifetime;

    private float m_destructionStart;
    private float m_lastBlink;
    private bool m_isOn;

    public void Init(float fragmentLifetime, float blinkDuration)
    {
        m_blinkDuration = blinkDuration;
        m_fragmentLifetime = fragmentLifetime;
    }

    private void OnEnable()
    {
        if (m_spriteMaterial == null)
        {
            m_spriteMaterial = GetComponent<MeshRenderer>();
        }
        m_destructionStart = Time.time;
        m_lastBlink = Time.time;
        m_isOn = true;
    }

    private void Update()
    {
        if (Time.time - m_lastBlink > m_blinkDuration)
        {
            m_isOn = !m_isOn;
            m_spriteMaterial.enabled = !m_spriteMaterial.enabled;
            m_lastBlink = Time.time;
        }

        if (Time.time - m_destructionStart > m_fragmentLifetime)
        {
            Destroy(gameObject);
        }
    }
}
