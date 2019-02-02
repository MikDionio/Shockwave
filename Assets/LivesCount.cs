using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LivesCount : MonoBehaviour {

    private int lives;
    public Text livesText;

	// Use this for initialization
	void Start () {
        lives = 3;
        livesText.text = "Lives: " + lives;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void addLife()
    {
        lives++;
        livesText.text = "Lives: " + lives;
    }

    public void removeLife()
    {
        lives--;
        livesText.text = "Lives: " + lives;
    }
}
