using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveManager : MonoBehaviour
{
    public static WaveManager instance;

    public GameObject SpawnPoints;
    public EnemyCharacter EnemyCharacter;

    public List<Character> enemyList;
    public int maximumEnemy = 25;

    public float currentSpawnCooldown = 0f;
    public float spawnCooldown = 3f;


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
        SpawnUnit(20);
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

            EnemyCharacter enemy = Instantiate(EnemyCharacter.gameObject, spawnPoint.position, Quaternion.identity).GetComponent<EnemyCharacter>();
            enemy.SetWaveManager(this);
            enemyList.Add(enemy);
        }
    }

    public void RemoveDeadCharacter(EnemyCharacter enemy)
    {
        enemyList.Remove(enemy);
    }
}
