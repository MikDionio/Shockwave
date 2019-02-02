using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Points : Pickup, Pickable {
    private GameObject Score;
    private GameObject GameController;
    // Use this for initialization
    void Start()
    {
        Score = GameObject.FindGameObjectWithTag("Score");
        GameController = GameObject.FindGameObjectWithTag("GameController");
    }

    // Update is called once per frame
    void Update()
    {

    }

    new public void onPick()//what happens when this item is picked up?
    {
        Score.GetComponent<Score>().updateScore(value);
        Destroy();
        Debug.Log("Scored!");
    }

    public void Destroy()
    {
        GameController.GetComponent<GameController>().spawnPickup();//spawn a new pickup
        this.gameObject.SetActive(false);
    }
}
