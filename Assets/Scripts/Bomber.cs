using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomber : Enemy {

    public GameObject Explosion;
    private GameObject ExplosionInstance;
    private GameObject Score;

    private void Start()
    {
        Score = GameObject.FindGameObjectWithTag("Score");
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Projectile")) //add an exclamation mark and see what happens ;)
        {
            collision.gameObject.GetComponent<Projectile>().Destroy();
            Destroy();
        }
    }

    new void Destroy()
    {
        //Update Score
        Score.GetComponent<Score>().updateScore(value);

        //Explode
        if(ExplosionInstance == null)
        {
            ExplosionInstance = Instantiate(Explosion, this.transform.position, Quaternion.identity);
            ExplosionInstance.SetActive(false);
        }

        ExplosionInstance.GetComponent<ExplosionEffect>().Explode();
        this.gameObject.SetActive(false);
    }
}
