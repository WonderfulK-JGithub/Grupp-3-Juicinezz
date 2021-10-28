using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Iwillnotdie : MonoBehaviour
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
            collision.gameObject.GetComponent<Ship>().invincibility = true;
           
            Destroy(gameObject);
        }//om denna krockar med ett gameobjekt med tag Player så aktiveras boolen invincibility på spelaren och sedan dör den. Mattias.
    }
}

