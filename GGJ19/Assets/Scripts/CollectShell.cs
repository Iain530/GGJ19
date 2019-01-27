using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectShell : MonoBehaviour
{
    public GameObject target;
    public AudioSource pickup;
    private bool dropped = false;

    // Update is called once per frame
    void Update()
    {
        if (target && !dropped) {
            this.gameObject.transform.position = target.transform.position;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.gameObject.CompareTag("Player"))
        {
            target = GameObject.FindGameObjectWithTag("Player");
            target.GetComponent<CrabSize>().SetShell(this);
        }
    }

    public void Drop() {
        dropped = true;
        transform.eulerAngles = new Vector3(0, 0, 180f);
    }
}
