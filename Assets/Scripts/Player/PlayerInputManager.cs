using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace lvl_0
{
    public class PlayerInputManager : MonoBehaviour
    {
        private InputSource m_inputSource;

        private void Awake()
        {
            m_inputSource = new InputSource();
        }

        private void OnEnable()
        {
            m_inputSource.Gameplay.Enable();
        }

        private void OnDisable()
        {
            m_inputSource.Gameplay.Disable();
        }

        public InputSource GetInputSource()
        {
            return m_inputSource;
        }
    }
}
