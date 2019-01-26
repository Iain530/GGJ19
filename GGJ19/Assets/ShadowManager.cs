using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShadowManager : MonoBehaviour
{
    public Transform spawnPoint1, spawnPoint2;
    public Vector3 moveDirection;
    public float destructTime = 30;
    public float minInterval = 1;
    [SerializeField]
    public Shadow[] shadows;
    public const float loopInterval = 0.05f;

    IEnumerator Start() {
        while(true){    
            yield return new WaitForSeconds(loopInterval);
            foreach(Shadow shadow in shadows){
                if(shadow.ShouldSpawn()){
                    StartCoroutine(ShadowAnimate(shadow));
                    yield return new WaitForSeconds(minInterval);
                }
            }
        }
    }

    IEnumerator ShadowAnimate(Shadow shadow){
        Vector3 pos = shadow.overrideSpawnPoint ? shadow.spawnPos : Vector3.Lerp(spawnPoint1.position, spawnPoint2.position, Random.Range(0.0f,1.0f));
        GameObject shadowObject = GameObject.Instantiate(shadow.prefab,pos,Quaternion.identity);
        Rigidbody2D rigid = shadowObject.AddComponent(typeof(Rigidbody2D)) as Rigidbody2D;
        rigid.gravityScale = 0;
        rigid.velocity = moveDirection*shadow.speed;
        yield return new WaitForSeconds(destructTime);
        Destroy(shadowObject);
    }
}

[System.Serializable]
public class Shadow{
    public GameObject prefab;
    public float speed;
    public float chanceEveryXSec = 10;
    public bool overrideSpawnPoint;
    public Vector3 spawnPos;
    public bool ShouldSpawn(){
        return Random.Range(0,1000) < 1000*ShadowManager.loopInterval/chanceEveryXSec;
    }
}
