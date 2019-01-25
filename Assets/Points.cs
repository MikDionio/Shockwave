using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Points : Pickup, Pickable {
    private GameObject Score;

    // Use this for initialization
    void Start()
    {
        Score = GameObject.FindGameObjectWithTag("Score");
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
}
