using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace lvl_0
{
    [Serializable]
    public class DictionaryEntry
    {
        public SpawnType Type;
        public GameObject Prefab;
    }

    [CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/SpawnDictionary", order = 1)]
    public class SpawnDictionary : ScriptableObject
    {
        [SerializeField]
        public DictionaryEntry[] Dictionary;
    }
}
