using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CrabHealth : MonoBehaviour
{
    public int health = 100;

    private HealthBar _healthBar;
    // Start is called before the first frame update
    void Start()
    {
        _healthBar = GameObject.Find("HealthBar").GetComponent<HealthBar>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void UpdateHealth(int newHealth)
    {
        if (newHealth <= 0)
        {
            
            SceneManager.LoadScene(2);
            return;
        }
        
        health = newHealth;
        _healthBar.SetSize( newHealth / 100f);


    }
}
