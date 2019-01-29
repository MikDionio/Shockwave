using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

    public List<GameObject> EnemyTypes = new List<GameObject>();
    public List<GameObject> EnemySpawnPoints = new List<GameObject>();

    private List<GameObject> PooledEnemies = new List<GameObject>();
    public GameObject ExplosionEffect;

    // Use this for initialization
    void Start() {

        //Pool enemy types
        poolEnemies(12, EnemyTypes[0]);
        poolEnemies(3, EnemyTypes[1]);

        //Enemy spawning
        InvokeRepeating("spawnEnemy", 0.01f, 0.5f);
    }

    // Update is called once per frame
    void Update() {
        
    }

    void poolEnemies(int poolAmount, GameObject EnemyType)
    { 
        for(int i = 0; i < poolAmount; i++)
        {
            GameObject EnemyInstance = Instantiate(EnemyType, this.transform.position, this.transform.rotation, this.transform);
            EnemyInstance.SetActive(false);
            PooledEnemies.Add(EnemyInstance);
        }
    }

    void spawnEnemy()
    {
        int type = Random.Range(0, EnemyTypes.Count);
        int position = Random.Range(0, EnemySpawnPoints.Count);

        foreach(GameObject enemy in PooledEnemies)
        {
            if (!enemy.activeSelf && EnemyTypes[type].CompareTag(enemy.tag))
            {
                enemy.transform.position = EnemySpawnPoints[position].transform.position;
                enemy.SetActive(true);
                break;
            }
        }

    }
        
}
