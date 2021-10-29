using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clone : MonoBehaviour
{
    public GameObject player;
    public GameObject CloneCreate;

    private void Awake()
    {
        Destroy(gameObject,10f);//Tar bort powerupen efter 10 sekunder
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Babyship smollship = FindObjectOfType<Babyship>();
            if (smollship != null) Destroy(smollship.gameObject);//d�dar klonsheppet om man redan hade ett

            SoundManagerScript.PlaySound("PowerUp");
            // SoundManagerScript.PlaySound("1Up"); //Spelar powerup ljudet /Theo
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
        }//om denna krockar med ett gameobjekt med tag Player s� skapar den clonen p� en ut av tv� platser och sedan d�r den. Mattias.
    }
}
