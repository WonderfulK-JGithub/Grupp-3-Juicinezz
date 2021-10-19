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
        

        if (skjuttimer > skjutintervall)
        {
            float angle = Vector2.Angle(Vector2.up, FindObjectOfType<Ship>().transform.position - transform.position);

            float factor = FindObjectOfType<Ship>().transform.position.x > transform.position.x ? -1 : 1;

            Instantiate(projektil, FiendeBody.position, Quaternion.Euler(0f, 0f, angle * factor));
            skjuttimer = 0;

        }

        
    }

    public override void Dead()
    {
        hp--;

        if (hp == 0)
        {
            base.Dead();
        } else
        {
            sprite.color = angrycolor;
        }
    }
}
