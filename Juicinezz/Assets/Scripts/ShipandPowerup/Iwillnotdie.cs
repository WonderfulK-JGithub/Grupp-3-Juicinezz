using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Iwillnotdie : MonoBehaviour
{
    public GameObject player;


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
           
            collision.gameObject.GetComponent<Ship>().invincibility = true;
           
            Destroy(gameObject);
        }//om denna krockar med ett gameobjekt med tag Player s� aktiveras boolen invincibility p� spelaren och sedan d�r den. Mattias.
    }
}

