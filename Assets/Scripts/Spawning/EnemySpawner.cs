using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// GameController Script
/// A basic script that is used to simply spawn enemies.
/// Good to use to test the enemies you've created.
/// Will eventually be replaced by the the procedurally generation scripts.
/// </summary>
public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject m_enemyPrefab;

    [SerializeField]
    private Collider2D m_spawnArea;

    [SerializeField]
    private float m_spawnDelay;

    private float m_lastSpawn;

    private void OnEnable()
    {
        m_lastSpawn = Time.time;
    }

    private void Update()
    {
        if (Time.time - m_lastSpawn > m_spawnDelay)
        {
            m_lastSpawn = Time.time;
            SpawnEnemy();
        }
    }

    /// <summary>
    /// Spawns a GarbageTruck
    /// </summary>
    /// <returns></returns>
    public void SpawnEnemy()
    {
        float spawnPositionX = Random.Range(m_spawnArea.bounds.min.x, m_spawnArea.bounds.max.y);
        float spawnPositionY = m_spawnArea.bounds.center.y;

        // set the position where the garbage truck will be spawned
        Vector3 spawnPosition = new Vector2(spawnPositionX, spawnPositionY);

        Instantiate(m_enemyPrefab, spawnPosition, transform.rotation);
    }
}
