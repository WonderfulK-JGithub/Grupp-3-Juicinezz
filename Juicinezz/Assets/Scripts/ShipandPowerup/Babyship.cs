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
            Destroy(gameObject); //D�dar sig sj�lv n�r countDown sl�r 0. Mattias.
        }
    }
}
