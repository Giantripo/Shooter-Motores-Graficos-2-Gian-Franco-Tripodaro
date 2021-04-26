using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeController : MonoBehaviour
{
    public float slowFactor = 0.05f;
    public float slowLength = 3f;
    public bool isTrue =false;
    public float cont;

    private void Start()
    {
        cont = 0;
    }
    private void Update()
    {

        cont -= Time.deltaTime;
        Debug.Log("slowmode en: "+cont);
        if (Input.GetKeyDown(KeyCode.U) && cont < 0 )
        {
            slowMotion();
            cont = 4; 
        }
        
        Time.timeScale += (1f / slowLength) * Time.unscaledDeltaTime;
        Time.timeScale = Mathf.Clamp(Time.timeScale, 0f, 1f);

    }
    public void slowMotion()
    {
        Time.timeScale = slowFactor;
        Time.fixedDeltaTime = Time.timeScale * .02f;
    }
}
