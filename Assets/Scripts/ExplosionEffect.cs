using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionEffect : MonoBehaviour {

    ParticleSystem ps;

    public float duration;

	// Use this for initialization
	void Start () {
        this.GetComponent<ParticleSystem>().Clear();
    }
	
	// Update is called once per frame
	void Update () {

    }

    public void Explode()
    {
        this.gameObject.SetActive(true);
        this.GetComponent<ParticleSystem>().Play(true);
        Invoke("SelfDestruct", duration);
    }

    public void SelfDestruct()
    {
        Destroy(gameObject);
    }
}
