using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Autoup : MonoBehaviour
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
            SoundManagerScript.PlaySound("PowerUp");
            collision.gameObject.GetComponent<Ship>().blast.LetsButtonMash = true;
            Destroy(gameObject);
        }//S?ger till att n?r skeppet nuddar s? activeras LetsButtonMash p? Skeppets barn Firepoint. Mattias. Och d?r. Mattias.
    }
}
