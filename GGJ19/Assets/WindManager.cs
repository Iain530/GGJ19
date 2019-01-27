using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindManager : MonoBehaviour
{
    public GameObject pref;
    public Vector3 offset;

    void Start(){
        InvokeRepeating("S",1,2);
    }

    void S(){

        Vector3 pos = Camera.main.ViewportToWorldPoint(new Vector3(1,1,0));
        
        Instantiate(pref,pos+offset, pref.transform.rotation);
    }

    // Update is called once per frame
}
