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

    public ParticleSystem Par1;
    public ParticleSystem Par2;
    public ParticleSystem Par3;
    public float Angytimer;
    public float countDown = 2;

    // Start is called before the first frame update
    void Start()
    {
        base.setup();

        sprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if(ScoreManager.current.gameIsOngoing)
        {
            base.Moving();

            base.BasicAttack();

            skjuttimer += Time.deltaTime;

            // det här stycket är i stort sett likadant som koden för skjut fienden förutom att vi lade till kod för att rikta projektilerna mot spelaren. -Gustav
            if (skjuttimer > skjutintervall)
            {
                float angle = Vector2.Angle(Vector2.up, Ship.current.transform.position - transform.position);
                // den här delen av koden fick jag av KJ, det är den som riktar projektilen mot spelaren. -Gustav
                float factor = Ship.current.transform.position.x > transform.position.x ? -1 : 1;

                Instantiate(projektil, FiendeBody.position, Quaternion.Euler(0f, 0f, angle * factor));
                skjuttimer = 0 + EnemySpawner.current.enemyExtraSpeed;

            }

            if (hp == 1)
            {
                Angytimer += Time.deltaTime;
                if (Angytimer >= countDown)
                {
                    Par1.gameObject.SetActive(false);
                    Par2.gameObject.SetActive(false);
                    Par3.gameObject.SetActive(false);
                }
            }
        }
        
    }

    public override void Dead() // overidar den vanliga koden för att ta skada
    {
        hp--;

        if (hp == 0)
        {
            base.Dead(); // kallar den vanliga koden för fiender 
        } else
        {
            sprite.color = angrycolor;

            Par1.gameObject.SetActive(true);
            Par2.gameObject.SetActive(true);
            Par3.gameObject.SetActive(true);

            skjutintervall--;
            enemySpeed += new Vector2(1, 0.5f);
            attackintervall--;
        }
    }
}
