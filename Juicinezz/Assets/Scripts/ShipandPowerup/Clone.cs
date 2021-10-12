using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clone : MonoBehaviour
{
    public GameObject player;
    public GameObject CloneCreate;


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            int random = Random.Range(0,2);
            if(random == 0)
            {
              Instantiate(CloneCreate, collision.transform.position + new Vector3(2, -2, 0), CloneCreate.transform.rotation);
            }
            else
            {
              Instantiate(CloneCreate, collision.transform.position + new Vector3(-2, -2, 0), CloneCreate.transform.rotation);
            }
            Destroy(gameObject);
        }//om denna krockar med ett gameobjekt med tag Player s� skapar den clonen och sedan d�r. Mattias.
    }
}
