using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : Ship
{
    public float countDown = 15;
    float timer;


    public override void Update()
    {
        base.Update(); //tar Update() från Skep koden. Mattias.

        //Shield ska förstöra alla fiende projectiles som rör den.

        timer += Time.deltaTime;
        if (timer >= countDown)
        {
            Destroy(gameObject);
        }
        //Efter att ha skapats sätter den timer på 15 sec sedan dör den. Mattias.
    }
}