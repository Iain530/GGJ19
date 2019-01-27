﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    private Transform bar;
    // public float v = 0.5f;
    // Start is called before the first frame update
    void Start()
    {
         bar = transform.Find("Bar");
    }

// void Update(){
    // SetSize(v);
// }
    public void SetSize(float sizeNormalized)
    {
        bar.localScale = new Vector3(sizeNormalized, 1f);
    }


}
