using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Prototype.Characters;

namespace Prototype
{
    public class WaveManager : MonoBehaviour
    {
        public static WaveManager instance;

        public List<Character> enemyList;

        [SerializeField] private GameObject SpawnPoints;
        [SerializeField] private EnemyCharacter enemyCharacter;


        [SerializeField] private int maximumEnemy = 25;
        [SerializeField] private int amountSpawnAtStart = 10;

        [SerializeField] private float currentSpawnCooldown = 0f;
        [SerializeField] private float spawnCooldown = 3f;

        private void Awake()
        {
            if (instance != null)
            {
                Destroy(gameObject);
            }

            instance = this;
        }

        private void Start()
        {
            SpawnUnit(amountSpawnAtStart);
        }

        private void Update()
        {
            if (currentSpawnCooldown < spawnCooldown)
            {
                currentSpawnCooldown += Time.deltaTime;
                return;
            }

            SpawnUnit(1);
            currentSpawnCooldown = 0f;
        }

        void SpawnUnit(int amount)
        {
            for (int i = 0; i < amount; i++)
            {
                if (enemyList.Count >= maximumEnemy)
                {
                    break;
                }
                Transform spawnPoint = SpawnPoints.transform.GetChild(Random.Range(0, SpawnPoints.transform.childCount - 1));

                EnemyCharacter enemy = Instantiate(enemyCharacter.gameObject, spawnPoint.position, Quaternion.identity).GetComponent<EnemyCharacter>();
                enemy.SetWaveManager(this);
                enemyList.Add(enemy);
            }
        }

        public void RemoveDeadCharacter(EnemyCharacter enemy)
        {
            enemyList.Remove(enemy);
        }
    }
}

