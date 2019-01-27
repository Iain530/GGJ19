using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerBar : MonoBehaviour
{
    private static HealthBar guage;
    private static float duration = 10f;
    private static float normallizedValue = 1.0f;
    private void Awake(){
        guage = GetComponent<HealthBar>();
    }

    private void Update(){
        normallizedValue -= Time.deltaTime/duration;
        if(normallizedValue < 0)
        normallizedValue = 0;
        guage.SetSize(normallizedValue);
        if( normallizedValue <=0 )
            OnTimeOut();
    }

    public static void Reset(){
        normallizedValue = 0;
    }

    public static void SetValue(float newValue/* [0.0,1.0] */){
        normallizedValue = newValue;
    }

    public static void OnTimeOut(){
        Debug.LogError("there is no implementation on timeout");
    }
}
