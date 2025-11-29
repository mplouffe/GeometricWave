using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace lvl_0
{
    public class SpawnLibrary : MonoBehaviour
    {
        [SerializeField]
        private SpawnDictionary m_rawDictionary;

        private Dictionary<SpawnType, GameObject> m_dictionary;

        void Start()
        {
            m_dictionary = new Dictionary<SpawnType, GameObject>(m_rawDictionary.Dictionary.Length);
            foreach(var dictionaryEntry in m_rawDictionary.Dictionary)
            {
                if (m_dictionary.ContainsKey(dictionaryEntry.Type))
                {
                    Debug.LogError($"Attempting to add duplicate key of type {dictionaryEntry.Type} to SpawnLibrary");
                    continue;
                }
                m_dictionary.Add(dictionaryEntry.Type, dictionaryEntry.Prefab);
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
                Debug.LogError($"Could not find type: {type} in SpawnDictionary");
                return null;
            }
        }
    }
}