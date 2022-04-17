using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
