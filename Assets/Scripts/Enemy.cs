using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour, Destroyable, Movable {
    public float moveSpeed;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        move();
	}

    public void Destroy()
    {
        this.gameObject.SetActive(false);
    }

    public void move()
    {
        GameObject Turret = GameObject.FindGameObjectWithTag("Turret");
        Vector2 direction = new Vector2(Turret.transform.position.x - this.transform.position.x, Turret.transform.position.y - this.transform.position.y);
        direction.Normalize();
        transform.Translate(direction*moveSpeed*Time.deltaTime);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Projectile")) //add an exclamation mark and see what happens ;)
        {
            Debug.Log("Destroy");
            collision.gameObject.GetComponent<Projectile>().Destroy();
            Destroy();
        }
    }
}
