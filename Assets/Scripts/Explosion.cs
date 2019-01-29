using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour {
    public float duration;
    public ParticleSystem ExplosionEffect;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        
	}

    public void Explode()
    {
        this.gameObject.SetActive(true);
        ParticleSystem explosionInstance = Instantiate(ExplosionEffect, this.gameObject.transform.position, Quaternion.identity);
        explosionInstance.Play(true);
        Debug.Log("Expl");
        Debug.Log("ode!");
        Destroy(this.gameObject);
    }
}
