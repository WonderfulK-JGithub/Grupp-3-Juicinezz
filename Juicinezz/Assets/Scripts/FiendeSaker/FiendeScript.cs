using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FiendeScript : GrunderFiender
{
    // Start is called before the first frame update
    void Start()
    {
        base.setup();
    }

    // Update is called once per frame
    void Update()
    {
        base.Moving();
        base.BasicAttack();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            print("ded");
        }
    }

    private void OnDestroy()
    {
        base.dead();
    }
}
