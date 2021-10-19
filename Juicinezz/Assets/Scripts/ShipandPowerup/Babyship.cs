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
        base.Update(); //tar Update() från Skep koden. Mattias.
        timer += Time.deltaTime;
        if (timer >= countDown)
        {
            Destroy(gameObject);
        }
        //Efter att ha skapats sätter den timer på 15 sec sedan dör den. Mattias.

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
