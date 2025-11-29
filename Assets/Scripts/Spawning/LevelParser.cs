using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace lvl_0
{
    public class LevelParser : MonoBehaviour
    {
        [SerializeField]
        private TextAsset m_levelJson;

        [SerializeField]
        private EnemySpawner m_enemySpawner;

        private Level m_currentLevel;

        private void OnEnable()
        {
            if (m_levelJson == null)
            {
                m_levelJson = Resources.Load<TextAsset>("level");
            }

            m_currentLevel = JsonUtility.FromJson<Level>(m_levelJson.text);
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
}
