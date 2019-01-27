using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrabMovement : MonoBehaviour {

    public int speed = 1;
    public Rigidbody2D rb;

    private Vector2 velocity;
	[SerializeField]
    private Animator ani, anihead;

    private float noShellSpeed = 1.3f;
    private CrabSize size;
    private ParticleSystem particles;

    void Start() {
        rb = GetComponent<Rigidbody2D>();
        size = GetComponent<CrabSize>();
        ani = transform.GetChild(1).GetComponent<Animator>();
		anihead = transform.GetChild(1).GetChild(0).GetComponent<Animator>();
        particles = transform.GetChild(3).GetComponent<ParticleSystem>();
		Debug.Log(anihead, ani);
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

        rb.velocity = velocity * speed * (size.HasShell() ? 1f : noShellSpeed);

        // change animation
        if (velocity.y != 0) {
            ani.SetInteger("movement", 2);
            anihead.SetInteger("movement",2);
            particles.Play();
        } else if (velocity.x != 0) {
            ani.SetInteger("movement", 1);
            anihead.SetInteger("movement",1);
            particles.Play();
        } else {
            ani.SetInteger("movement", 0);
            anihead.SetInteger("movement",0);
            particles.Pause();
        }
    }

}
