using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Hud : MonoBehaviour {
    private Text txt;

    void Start() {
        txt = transform.GetChild(0).GetComponent<Text>();
    }

    public void UpdateHud(int food, int toNext) {
        txt.text = food.ToString() + "/" + toNext.ToString();
    }
}
