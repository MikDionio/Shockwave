using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

    public List<GameObject> EnemyTypes = new List<GameObject>();
    public List<GameObject> EnemySpawnPoints = new List<GameObject>();

    private List<GameObject> PooledEnemies = new List<GameObject>();

    public List<GameObject> PickupTypes = new List<GameObject>();
    private List<GameObject> PooledPickups = new List<GameObject>();

    // Use this for initialization
    void Start() {

        //Pool enemy types
        poolObject(12, EnemyTypes[0], PooledEnemies); //pool 12 fodders
        poolObject(3, EnemyTypes[1], PooledEnemies);  //pool 3 Bombers

        //Pool pickups
        poolObject(5, PickupTypes[0], PooledPickups); //pool 5 10pts. pickups
        poolObject(1, PickupTypes[1], PooledPickups); //pool 1 100pts. pickups
        poolObject(2, PickupTypes[2], PooledPickups); //pool 2 Lives pickups

        //Enemy spawning
        InvokeRepeating("spawnEnemy", 0.01f, 0.5f);

        spawnPickup();
    }

    // Update is called once per frame
    void Update() {
        
    }

    void poolObject(int poolAmount, GameObject ObjectType, List<GameObject> PooledObjects)//instantiate object instances, and then store them on a pool list
    { 
        for(int i = 0; i < poolAmount; i++)
        {
            GameObject ObjectInstance = Instantiate(ObjectType, this.transform.position, this.transform.rotation, this.transform);
            ObjectInstance.SetActive(false);
            PooledObjects.Add(ObjectInstance);
        }
    }

    void spawnEnemy()//spawns enemies outside the arena
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

    public void spawnPickup()//spawns pickups in the arena
    {
        float xpos = Random.Range(-6.0f, 6.0f);
        float ypos = Random.Range(-3.0f, 3.0f);
        int pickup = Random.Range(0, PickupTypes.Count);

        GameObject pickupInstance = PooledPickups[pickup];
        pickupInstance.transform.position = new Vector2(xpos, ypos);
        pickupInstance.SetActive(true);
    }
        
}
