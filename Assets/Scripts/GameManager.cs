using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public int score = 0;
    public bool isPaused = false;
    public int lives = 3;
    public GameObject PlayerPrefab;
    public GameObject Player;
    public GameObject AsteroidPrefab;
    public List<GameObject> enemiesList = new List<GameObject>();
    public GameObject[] EnemyPrefabs;
    public int maxEnemiesSpawnable;
    public List<Transform> spawnPoints = new List<Transform>();

    public void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this.gameObject);
            Debug.LogError("I tried to create a second game manager.");
        }

    }

    void Update()
    {
        SpawnEnemies();
    }

    public void Respawn()
    {
        Player = Instantiate(PlayerPrefab);
    }

    public void SpawnEnemies()
    {
        if (enemiesList.Count < maxEnemiesSpawnable)
        {
            int RandomSpawn = Random.Range(0, spawnPoints.Count);
            int RandomEnemy = Random.Range(0, EnemyPrefabs.Length);
            Instantiate(EnemyPrefabs[RandomEnemy], spawnPoints[RandomSpawn].position,
                spawnPoints[RandomSpawn].rotation);
        }
    }

    public void DestroyAllEnemies()
    {
        foreach (GameObject enemy in enemiesList)
        {
            Destroy(enemy);
        }
        enemiesList.Clear();
    }

}

