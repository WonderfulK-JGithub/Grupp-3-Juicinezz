using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skott : MonoBehaviour
{
    public Rigidbody2D bullet;
    // Start is called before the first frame update
    void Awake()
    {
        bullet = GetComponent<Rigidbody2D>();
        SoundManagerScript.PlaySound("OppShoot");
    }

    // Update is called once per frame
    void Update()
    {
        bullet.velocity = new Vector2(5*transform.up.x, 5*transform.up.y);

        if (transform.position.y < -5)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Ship.current.TakeDamage(1);
        }
    }
}
