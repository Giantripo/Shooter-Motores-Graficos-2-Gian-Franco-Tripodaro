using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeController : MonoBehaviour
{
    public float slowFactor = 0.05f;
    public float slowLength = 2f;
    public bool slowActive =false;
    public float cont;
    public float cont2;
    private void Start()
    {
        cont = 0;
    }
    private void Update()
    {
        if (slowActive == true)
        {
            cont2 -= Time.unscaledDeltaTime;
            if (cont2 < -3 )
            {
                slowActive = false;
                cont2 = 0;
                
            }
            Time.timeScale += (1f / slowLength) * Time.unscaledDeltaTime;
            Time.timeScale = Mathf.Clamp(Time.timeScale, 0f, 1f);
        }
        cont -= Time.deltaTime;
        
        if (cont < 0 && slowActive ==false)
        {
            if (Input.GetKeyDown(KeyCode.U))
            {

                slowMotion();
                cont = 3;
            }

        }

        //Time.timeScale += (1f / slowLength) * Time.unscaledDeltaTime;
        //Time.timeScale = Mathf.Clamp(Time.timeScale, 0f, 1f);


    }
    public void slowMotion()
    {
        slowActive = true;
        Time.timeScale = slowFactor;
        Time.fixedDeltaTime = Time.timeScale * .02f;
    }
}
