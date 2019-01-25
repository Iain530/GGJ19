using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CrabSize : MonoBehaviour {

    public SpriteRenderer sr;
    public Sprite[] sprites;

    public int size = 0;

    public int food = 0;
    public int[] sizeIncreaseIntervals;

    void Start() {
        sr = GetComponent<SpriteRenderer>();
        sr.sprite = sprites[size];
    }

    void IncreaseSize() {
        size++;
        sr.sprite = sprites[size];
    }

    void EatFood(int value) {
        food += value;
        if (food >= sizeIncreaseIntervals[size]) {
            food = food - sizeIncreaseIntervals[size];
            IncreaseSize();
        }
    }

    int FoodToNextSize() {
        return sizeIncreaseIntervals[size];
    }
}
