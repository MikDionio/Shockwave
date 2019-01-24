using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour, Destroyable, Movable {
    public float moveSpeed;

    // Use this for initialization
    void Start() {

    }

    // Update is called once per frame
    void Update() {
        move();
        onLeaveMap();
    }

    public void move()
    {
        this.transform.Translate(new Vector2(0.0f,1.0f) * moveSpeed * Time.deltaTime);
    }

    public void Destroy()
    {
        this.gameObject.SetActive(false);
    }

    public void onLeaveMap()
    {
        if ((this.transform.position.x > 20)||(this.transform.position.x < -20)||(this.transform.position.y > 15)||(this.transform.position.y < -15))
        {
            Destroy();
        }
    }
}
