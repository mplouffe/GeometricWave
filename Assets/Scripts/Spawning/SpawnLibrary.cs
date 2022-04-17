using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnLibrary : MonoBehaviour
{
    [SerializeField]
    private SpawnDictionary m_rawDictionary;

    private Dictionary<SpawnType, GameObject> m_dictionary;

    void Start()
    {
        m_dictionary = new Dictionary<SpawnType, GameObject>(m_rawDictionary.Dictionary.Length);
        for (int i = 0; i < m_rawDictionary.Dictionary.Length; i++)
        {
            if (!m_dictionary.ContainsKey(m_rawDictionary.Dictionary[i].Type))
            {
                m_dictionary.Add(m_rawDictionary.Dictionary[i].Type, m_rawDictionary.Dictionary[i].Prefab);
            }
            else
            {
                // TODO: log error
            }
        }
    }

    
    public GameObject CheckOutPrefab(SpawnType type)
    {
        if (m_dictionary.ContainsKey(type))
        {
            return m_dictionary[type];
        }
        else
        {
            // TODO: log error
            return null;
        }
    }
}