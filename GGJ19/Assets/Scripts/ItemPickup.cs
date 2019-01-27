using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag ("Player"))
        {
            other.gameObject.GetComponent<CrabSize>().EatFood(10);
            this.gameObject.SetActive (false);
        }
    }

}
