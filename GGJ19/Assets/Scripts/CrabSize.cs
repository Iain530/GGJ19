using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CrabSize : MonoBehaviour {

    public Sprite[] sprites;

    public int size = 0;

    public int[] sizeIncreaseIntervals;
    private int food = 0;

    private SpriteRenderer sr;
    private Hud hud;

    void Start() {
        sr = GetComponent<SpriteRenderer>();
        // sr.sprite = sprites[size];
        hud = GameObject.FindWithTag("Hud").GetComponent<Hud>();
        hud.UpdateHud(food, sizeIncreaseIntervals[size]);
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
        hud.UpdateHud(food, sizeIncreaseIntervals[size]);
    }

    int FoodToNextSize() {
        return sizeIncreaseIntervals[size];
    }
}
