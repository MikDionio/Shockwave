using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour, Pickable, Destroyable {

    public int value;
    

    // Use this for initialization
    void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void onPick()//what happens when this item is picked up?
    {
        
    }

    public void Destroy()
    {
        this.gameObject.SetActive(false);
    }
}
