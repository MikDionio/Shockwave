using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifePickup : Pickup, Pickable {

    private GameObject LivesCount;
    private GameObject GameController;

	// Use this for initialization
	void Start () {
        LivesCount = GameObject.FindGameObjectWithTag("Lives");
        GameController = GameObject.FindGameObjectWithTag("GameController");
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnPick()
    {
        LivesCount.GetComponent<LivesCount>().addLife();
        Destroy();
    }

    public void Destroy()
    {
        GameController.GetComponent<GameController>().spawnPickup();//spawn a new pickup
        this.gameObject.SetActive(false);
    }
}
