using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour, Destroyable {

    public GameObject bulletPrefab;
    public GameObject muzzle;

    public float fireRate;
    public int hp;

    List<GameObject> bulletList = new List<GameObject>();

    // Use this for initialization
    void Start () {
        poolBullets(5);
	}
	
	// Update is called once per frame
	void Update () {
        aimAtMouse();
        shoot();
	}

    void aimAtMouse()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 direction = new Vector2(mousePosition.x - this.transform.position.x, mousePosition.y - this.transform.position.y);
        transform.up = direction;
    }

    void poolBullets(int poolAmount)
    {
        for(int i = 0; i< poolAmount; i++)
        {
            GameObject bulletInstance = Instantiate(bulletPrefab,this.transform.position, this.transform.rotation);
            bulletInstance.SetActive(false);
            bulletList.Add(bulletInstance);
        }
    }

    void shoot()
    {
        float timeLastFired = 0.0f;
        if (Input.GetMouseButtonDown(0) && (Time.time - timeLastFired > fireRate))
        {
            bool hasFired = false;
            foreach (GameObject bullet in bulletList)
            {
                if(!bullet.activeSelf)
                {
                    bullet.transform.position = muzzle.transform.position;
                    bullet.transform.rotation = muzzle.transform.rotation;
                    bullet.SetActive(true);
                    
                    hasFired = true;
                    break;
                }
            }

            if(hasFired == false)//means inactive bullet was not found
            {
                GameObject bulletInstance = Instantiate(bulletPrefab, this.transform.position, this.transform.rotation);
                bulletInstance.transform.position = muzzle.transform.position;
                bulletInstance.transform.rotation = muzzle.transform.rotation;
                hasFired = true;
                bulletList.Add(bulletInstance);
            }

            timeLastFired = Time.time;
        }
        
    }

    public void Destroy()
    {
        this.gameObject.SetActive(false);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Fodder") || collision.gameObject.CompareTag("Bomber"))//if collide with enemy, subtract hp, check if dead
        {
            hp = hp - 1;
            if(hp <= 0)
            {
                Destroy();
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Points"))
        {
            collision.GetComponent<Points>().onPick();
            Debug.Log("points!");
        }else if (collision.gameObject.CompareTag("Lives"))
        {
            collision.GetComponent<LifePickup>().onPick();
            Debug.Log("lives!");
        }
    }
}
