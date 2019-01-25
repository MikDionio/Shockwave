using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomber : Enemy {

    public GameObject Explosion;
    private GameObject ExplosionInstance;
    private GameObject Score;

    private void Start()
    {
        ExplosionInstance = Instantiate(Explosion, this.transform);
        ExplosionInstance.SetActive(false);
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
        StartCoroutine(ExplodeOnDie());
        Score.GetComponent<Score>().updateScore(value);
    }

    IEnumerator ExplodeOnDie()
    {
        StartCoroutine(ExplosionInstance.GetComponent<Explosion>().Explode());
        yield return new WaitForSeconds(0.1f);
        this.gameObject.SetActive(false);
    }
}
