using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Speedup : MonoBehaviour
{
    public GameObject player;



    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<Ship>().HitTheGas = true;
            Destroy(gameObject);
        }//om denna krockar med ett gameobjekt med tag Player så activeras HitTheGas på spelaren och sedan dör. Mattias.
    }
}