using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Iwillnotdie : MonoBehaviour
{
    public GameObject player;
    public GameObject ShieldCreate;


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
           //G�r spelaren od�dlig + spela en od�lig animation ungef�r som mario.

           // Instantiate(ShieldCreate, collision.transform.position + new Vector3(0, 0, 0), ShieldCreate.transform.rotation);
            Destroy(gameObject);
        }//om denna krockar med ett gameobjekt med tag Player s�         och sedan d�r. Mattias.
    }
}

