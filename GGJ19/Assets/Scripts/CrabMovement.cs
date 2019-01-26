using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrabMovement : MonoBehaviour {

    public int speed = 1;
    public Rigidbody2D rb;

    private Vector2 velocity;
    private Animator ani;

    void Start() {
        rb = GetComponent<Rigidbody2D>();
        ani = transform.GetChild(1).GetComponent<Animator>();
    }

    void Update() {
        velocity.x = 0;
        velocity.y = 0;

        if (Input.GetKey(KeyCode.W)) {
            velocity.y = 1;
        } else if (Input.GetKey(KeyCode.S)) {
            velocity.y = -1;
        }

        if (Input.GetKey(KeyCode.D)) {
            velocity.x = 1;
        } else if (Input.GetKey(KeyCode.A)) {
            velocity.x = -1;
        }

        if (velocity.magnitude > 0) {
            velocity = velocity / velocity.magnitude;
        }

        rb.velocity = velocity * speed;

        // change animation
        if (velocity.y != 0) {
            ani.SetInteger("movement", 2);
        } else if (velocity.x != 0) {
            ani.SetInteger("movement", 1);
        } else {
            ani.SetInteger("movement", 0);
        }
    }

}
