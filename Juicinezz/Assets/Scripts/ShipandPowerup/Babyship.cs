using UnityEngine;

public class Babyship : Ship
{
    public float CountDown = 15;
    float Deathtimer;


    private void Start()
    {
        speed = baseSpeed;
    }
    public override void Update()
    {
        base.Update(); //tar Update() från Skep koden. Mattias.
        Deathtimer += Time.deltaTime;
        if (Deathtimer >= countDown)
        {
            Destroy(gameObject); //Dödar sig själv när countDown slår 0. Mattias.
        }
    }
}
