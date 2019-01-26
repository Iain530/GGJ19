using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectShell : MonoBehaviour
{
    public GameObject target;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.gameObject.transform.position = target.transform.position;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.gameObject.CompareTag("Player"))
        {
            target = GameObject.FindGameObjectWithTag("Player");
        }
    }
}
