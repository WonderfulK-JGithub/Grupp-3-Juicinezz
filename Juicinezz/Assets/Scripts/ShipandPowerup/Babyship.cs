using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Babyship : Ship 
{
    public float CountDown = 15;
    float timer;


    private void Start()
    {
        speed = baseSpeed;
    }
    public override void Update()
    {
        base.Update(); //tar Update() fr�n Skep koden. Mattias.
        timer += Time.deltaTime;
        if (timer >= countDown)
        {
            Destroy(gameObject);
        }
        //Efter att ha skapats s�tter den timer p� 15 sec sedan d�r den. Mattias.

       /* if (HitTheGas)
        {
            speed = baseSpeed *2;

            if (speedtimer >= slowcountDown)
            {
                speed = baseSpeed;
                speedtimer = 0;
                HitTheGas = false;
            }
        }*/
        
    }
}
