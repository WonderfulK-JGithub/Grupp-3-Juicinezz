using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Autoup : MonoBehaviour
{
    public GameObject player;
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
          //  gameObject.GetComponent<FirePoint>().LetsButtonMash = true;
            Destroy(gameObject);
        }
    }
}
