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
    private Camera minimapCamera;
    private float targetViewport;

    private Vector3 targetSize;
    public AudioSource walk;
    public AudioSource run;
    public AudioSource pickup;

    public static float growStep = 1.1f;

    void Start() {
        hud = GameObject.FindWithTag("Hud").GetComponent<Hud>();
        hud.UpdateHud(food, sizeIncreaseIntervals[size]);
        camera = transform.GetChild(0).GetComponent<Camera>();
        minimapCamera = camera.gameObject.transform.GetChild(0).GetComponent<Camera>();
        targetViewport = camera.orthographicSize;
        targetSize = transform.localScale;
    }

    void Update(){
        camera.orthographicSize = Mathf.Lerp(camera.orthographicSize, targetViewport, Time.deltaTime/(Mathf.Abs(camera.orthographicSize-targetViewport)));
        transform.localScale = Vector3.Lerp(transform.localScale, targetSize, Time.deltaTime*10);
    }

    public bool HasShell() {
        return shell != null;
    }
    void IncreaseSize() {
        size++;
        // transform.localScale = ((Vector3) transform.localScale) + new Vector3(0.5f, 0.5f, 0);
        // targetSize += new Vector3(0.5f,0.5f,0);
        targetSize*=growStep;
        if (shell) {
            TimerBar.duration = 90;
            shell.Drop();
            walk.Stop();
            run.Play();
            shell = null;
        }
    }

    internal void EatFood(int value) {
        food += value;
        if (food >= sizeIncreaseIntervals[size]) {
            food = food - sizeIncreaseIntervals[size];
            IncreaseSize();
            expandViewPort();
        }
        hud.UpdateHud(food, sizeIncreaseIntervals[size]);
    }


    private void expandViewPort() {
        targetViewport += 2.0f;
        minimapCamera.orthographicSize += 4.0f;
    }

    int FoodToNextSize() {
        return sizeIncreaseIntervals[size];
    }

    public void SetShell(CollectShell shell) {
        this.shell = shell;
        run.Stop();
        walk.PlayDelayed(1.5f);
        pickup.Play();

        TimerBar.duration = 90;
        TimerBar.Reset();
    }
}
