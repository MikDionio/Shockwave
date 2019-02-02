﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour, Pickable, Destroyable {

    public int value;
    private GameObject GameController;

    // Use this for initialization
    void Start () {
        GameController = GameObject.FindGameObjectWithTag("GameController");
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void onPick()//what happens when this item is picked up?
    {
        
    }

    public void Destroy()
    {
        GameController.GetComponent<GameController>().spawnPickup();//spawn a new pickup
        this.gameObject.SetActive(false);
    }
}
