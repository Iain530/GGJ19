using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CrabSize : MonoBehaviour {

    public int size = 0;

    public int[] sizeIncreaseIntervals;
    private int food = 0;

    private Hud hud;
    private CollectShell shell;

    private Camera camera;

    void Start() {
        hud = GameObject.FindWithTag("Hud").GetComponent<Hud>();
        hud.UpdateHud(food, sizeIncreaseIntervals[size]);
        camera = transform.GetChild(0).GetComponent<Camera>();
    }


    public bool HasShell() {
        return shell != null;
    }

    void IncreaseSize() {
        size++;
        transform.localScale = ((Vector3) transform.localScale) + new Vector3(0.5f, 0.5f, 0);
        if (shell) {
            shell.Drop();
            shell = null;
        }
    }

    internal void EatFood(int value) {
        food += value;
        if (food >= sizeIncreaseIntervals[size]) {
            food = food - sizeIncreaseIntervals[size];
            IncreaseSize();
        }
        hud.UpdateHud(food, sizeIncreaseIntervals[size]);
    }


    private void expandViewPort() {
        camera.orthographicSize += 5.0f;
    }

    int FoodToNextSize() {
        return sizeIncreaseIntervals[size];
    }

    public void SetShell(CollectShell shell) {
        this.shell = shell;
    }
}
