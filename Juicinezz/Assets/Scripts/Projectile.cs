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
    }//G�r s� att projectile sjuter rakt upp. Mattias.


    private void OnTriggerEnter2D(Collider2D collision)
    {
       /* Enemy enemy = hitInfo.transform.GetComponent<Enemy>();
        if (enemy != null)
        {
            enemy.TakeDamage(damage);
        }
        Destroy(gameObject);*/
    }
}
