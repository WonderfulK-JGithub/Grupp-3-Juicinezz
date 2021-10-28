using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Speedup : MonoBehaviour
{
    public GameObject player;

    private void Awake()
    {
        Destroy(gameObject, 10f);//Tar bort powerupen efter 10 sekunder
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            SoundManagerScript.PlaySound("Speed");
            collision.gameObject.GetComponent<Ship>().HitTheGas = true;
            Destroy(gameObject);
        }//om denna krockar med ett gameobjekt med tag Player s� activeras HitTheGas p� spelaren och sedan d�r den. Mattias.
    }
}