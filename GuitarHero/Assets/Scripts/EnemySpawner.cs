using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {

    public enum EnemyType
    {
        up,
        right,
        down,
        left
    }

    public int pooledAmount = 50;
    public GameObject enemy;
    List<GameObject> enemies;

    public Vector3 creationPoint;
    public float spawnReloadTime = 1f;
    private float spawnTime = 0;

    public float minSpawnTime = 4f;
    public float maxSpawnTime = 6f;
    public float spawnCounter = 0;

    public EnemyType type;

    // Use this for initialization
    void Start()
    {
        creationPoint = gameObject.transform.position;

        enemies = new List<GameObject>();
        for (int i = 0; i < pooledAmount; i++)
        {
            GameObject obj = (GameObject)Instantiate(enemy);
            obj.gameObject.GetComponent<Enemy>().type = (Enemy.enemyType)type;
            obj.SetActive(false);
            enemies.Add(obj);
        }
    }

    public void CreateEnemy()
    {
        for (int i = 0; i < enemies.Count; i++)
        {
            if (!enemies[i].activeInHierarchy)
            {
                enemies[i].transform.position = creationPoint;
                enemies[i].SetActive(true);
                break;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        // TODO find better solution
        spawnTime += Time.deltaTime;

        minSpawnTime -= spawnCounter;
        maxSpawnTime -= spawnCounter;

        spawnCounter += 0.0000001f;

        if (spawnTime >= spawnReloadTime)
        {
            CreateEnemy();
            spawnTime = 0;
            spawnReloadTime = Random.Range(minSpawnTime, maxSpawnTime);
        }
    }
}
