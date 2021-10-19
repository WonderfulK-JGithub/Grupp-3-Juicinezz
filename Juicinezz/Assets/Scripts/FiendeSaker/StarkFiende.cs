using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarkFiende : GrunderFiender
{
    public GameObject projektil;
    public float skjutintervall;
    public float skjuttimer;
    public GameObject player;
    private int hp = 2;
    public SpriteRenderer sprite;
    public Color angrycolor;

    // Start is called before the first frame update
    void Start()
    {
        base.setup();

        sprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        base.Moving();

        base.BasicAttack();

        skjuttimer += Time.deltaTime; 
        
        // det h�r stycket �r i stort sett likadant som koden f�r skjut fienden f�rutom att vi lade till kod f�r att rikta projektilerna mot spelaren. -Gustav
        if (skjuttimer > skjutintervall)
        {
            float angle = Vector2.Angle(Vector2.up, FindObjectOfType<Ship>().transform.position - transform.position); 
            // den h�r delen av koden fick jag av KJ, det �r den som riktar projektilen mot spelaren. -Gustav
            float factor = FindObjectOfType<Ship>().transform.position.x > transform.position.x ? -1 : 1;

            Instantiate(projektil, FiendeBody.position, Quaternion.Euler(0f, 0f, angle * factor));
            skjuttimer = 0;

        }

        
    }

    public override void Dead() // overidar den vanliga koden f�r att ta skada
    {
        hp--;

        if (hp == 0)
        {
            base.Dead(); // kallar den vanliga koden f�r fiender 
        } else
        {
            sprite.color = angrycolor;

            skjutintervall--;
            enemySpeed += new Vector2(1, 0.5f);
            attackintervall--;
        }
    }
}
