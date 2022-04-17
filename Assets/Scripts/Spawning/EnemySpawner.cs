using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    private Collider2D m_northSpawnArea;

    [SerializeField]
    private Collider2D m_eastSpawnArea;

    [SerializeField]
    private Collider2D m_southSpawnArea;

    [SerializeField]
    private Collider2D m_westSpawnArea;

    [SerializeField]
    private SpawnLibrary m_spawnLibrary;

    public void SpawnEnemy(SpawnType type, SpawnDirection direction, Vector3 spawnOffset)
    {
        var spawnArea = direction switch
        {
            SpawnDirection.North => m_northSpawnArea,
            SpawnDirection.East => m_eastSpawnArea,
            SpawnDirection.South => m_southSpawnArea,
            SpawnDirection.West => m_westSpawnArea,
            _ => null,
        };
        Vector3 spawnPosition = spawnArea.bounds.center + spawnOffset;
        Instantiate(m_spawnLibrary.CheckOutPrefab(type), spawnPosition, spawnArea.gameObject.transform.rotation);
    }
}
