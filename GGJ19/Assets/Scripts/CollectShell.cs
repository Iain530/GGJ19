using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectShell : MonoBehaviour
{
    public GameObject target;
    public int fittingSize = 1;
    public AudioSource pickup;
    private bool dropped = false;

void Awake(){
    GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
    for(int i = 0; i < fittingSize; i++)
        transform.localScale = transform.localScale*CrabSize.growStep;

}
    void Update()
    {
        if (target && !dropped) {
            this.gameObject.transform.position = target.transform.position;
        }

        if(GameObject.FindGameObjectWithTag("Player").GetComponent<CrabSize>().size == fittingSize){
            GetComponent<BoxCollider2D>().isTrigger = true;
        }
        else
        {
            GetComponent<BoxCollider2D>().isTrigger = false;
        }



        if(dropped){
            SpriteRenderer sr = GetComponentInChildren<SpriteRenderer>();
            Color oldColor = sr.color; 
            oldColor.a -= Time.deltaTime/3;
            sr.color = oldColor;
            GetComponent<BoxCollider2D>().isTrigger = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            CrabSize component = GameObject.FindGameObjectWithTag("Player").GetComponent<CrabSize>();

            Debug.Log("QQQQQ " + component.size + " " + fittingSize);

            if(dropped == false && (component.size == fittingSize) && (component.HasShell()==false)){
                component.SetShell(this);
                target = GameObject.FindGameObjectWithTag("Player");
            }
        }
    }

    public void Drop() {
        dropped = true;
        transform.eulerAngles = new Vector3(0, 0, 180f);
    }
}
