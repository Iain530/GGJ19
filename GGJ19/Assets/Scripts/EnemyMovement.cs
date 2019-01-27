using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemyMovement : MonoBehaviour
{
    public GameObject Player;


    
    public float accelerationTime = 2f;
    public float maxSpeed = 1f;
    private Rigidbody2D _rb;
    private Vector2 _movement;
    private float _timeLeft;
    private float _aggroTime = 10; 
    private bool _aggro = false;
    private CrabHealth _crabHealth;

    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _crabHealth = Player.GetComponent<CrabHealth>();
    }

    void Update()
    {
        float dist = Vector2.Distance(Player.transform.position, transform.position);
        if (!_aggro)
        {
                        
            if (dist < 10) _aggro = true;
            
            _timeLeft -= Time.deltaTime;
            if (_timeLeft >= 0) return;

            _movement = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f));
            _timeLeft += accelerationTime;

            
            
            
        }
        else
        {
            if (dist < 1)
            {
                _crabHealth.UpdateHealth(_crabHealth.health - 1);
            }
            
            _aggroTime -= Time.deltaTime;
            if (_timeLeft >= 0)
            {
                _aggroTime = 10;
                _aggro = false;
            }
        }

    }

    void FixedUpdate()
    {
        if (_aggro)
        {
            Vector2 toTarget = Player.transform.position - transform.position;
            transform.Translate(toTarget * 0.8f * Time.deltaTime);
            return;
        }
        var velocity = _rb.velocity;
        velocity = new Vector3((float) (velocity.x * 0.95), (float) (velocity.y * 0.95));
        _rb.velocity = velocity;
        _rb.AddForce(_movement * maxSpeed);
    }
}