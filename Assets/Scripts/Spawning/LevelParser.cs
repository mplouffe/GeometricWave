using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class LevelParser : MonoBehaviour
{
    [SerializeField]
    private TextAsset m_levelJson;

    [SerializeField]
    private EnemySpawner m_enemySpawner;

    private void OnEnable()
    {
        if (m_levelJson == null)
        {
            m_levelJson = Resources.Load<TextAsset>("level");
        }

        var level = JsonUtility.FromJson<Level>(m_levelJson.text);
        Debug.Log(level.SpawnEvents[0].direction);

        m_lastSpawn = Time.time;
    }

    [SerializeField]
    private float m_spawnDelay;

    private float m_lastSpawn;

    private void Update()
    {
        if (Time.time - m_lastSpawn > m_spawnDelay)
        {
            m_lastSpawn = Time.time;
            SpawnType type = SpawnType.SquareFighter;
            SpawnDirection direction = (SpawnDirection)Random.Range(0, 4);
            m_enemySpawner.SpawnEnemy(type, direction, Vector3.zero);
        }
    }
}
