using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Babyship : Ship 
{
    public float countDown = 15;
    float timer;
  
   
    public override void Update()
    {
        base.Update(); //tar Update() fr�n Skep koden. Mattias.
        timer += Time.deltaTime;
        if (timer >= countDown)
        {
            Destroy(gameObject);
        }
        //Efter att ha skapats s�tter den timer p� 15 sec sedan d�r den. Mattias.
    }
}
