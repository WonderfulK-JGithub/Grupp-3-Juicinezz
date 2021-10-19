using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed = 10;
    public Rigidbody2D rb;
    void Start()
    {
        rb.velocity = transform.up * speed;
    }//Gör så att projectile sjuter rakt upp. Mattias.

    private void Update()
    {
        if (transform.position.y > 8)
        {
            Destroy(gameObject);
        }
    }



    private void OnTriggerEnter2D(Collider2D collision)
    {
       /* Enemy enemy = hitInfo.transform.GetComponent<Enemy>();
        if (enemy != null)
        {
            enemy.TakeDamage(damage);
        }
        Destroy(gameObject);*/

        if (collision.tag == "Fiende")
        {
            collision.GetComponent<GrunderFiender>().Dead();

            Destroy(gameObject);
        }

    }
}
