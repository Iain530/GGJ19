using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CrabSize : MonoBehaviour {

    public int size = 0;

    public int[] sizeIncreaseIntervals;
    private int food = 0;

    private Hud hud;

    void Start() {
        hud = GameObject.FindWithTag("Hud").GetComponent<Hud>();
        hud.UpdateHud(food, sizeIncreaseIntervals[size]);
    }

    void Update() {
        
    }

    void IncreaseSize() {
        size++;
        transform.localScale = ((Vector3) transform.localScale) + new Vector3(0.5f, 0.5f, 0); 
    }

    internal void EatFood(int value) {
        food += value;
        if (food >= sizeIncreaseIntervals[size]) {
            food = food - sizeIncreaseIntervals[size];
            IncreaseSize();
        }
        hud.UpdateHud(food, sizeIncreaseIntervals[size]);
    }

    int FoodToNextSize() {
        return sizeIncreaseIntervals[size];
    }
}
