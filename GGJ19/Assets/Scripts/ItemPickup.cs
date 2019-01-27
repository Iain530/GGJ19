using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : MonoBehaviour
{

    // Custom behaviour for certain pickups?
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.gameObject.CompareTag ("Player") && other.gameObject.GetComponent<CrabSize>().HasShell())
        {
            other.gameObject.GetComponent<CrabSize>().EatFood(10);
            this.gameObject.SetActive (false);
        }
    }

}
