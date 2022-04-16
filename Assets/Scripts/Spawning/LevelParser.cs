using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class LevelParser : MonoBehaviour
{
    [SerializeField]
    private TextAsset m_levelJson;


    private void OnEnable()
    {
        if (m_levelJson == null)
        {
            m_levelJson = Resources.Load<TextAsset>("level");
        }

        var level = JsonUtility.FromJson<Level>(m_levelJson.text);
    }
}
