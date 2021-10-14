using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkjutandeFiendeScript : GrunderFiender
{
    public GameObject Kula;

    // Start is called before the first frame update
    void Start()
    {
        base.setup();
    }

    // Update is called once per frame
    void Update()
    {
        base.Moving();

        attacktimer += Time.deltaTime;

        if (attacktimer > attackintervall)
        {
            if(Random.Range(0,2) == 0)
            {
                Instantiate(Kula, FiendeBody.position, Quaternion.identity);

                attacktimer = 0;
            }
            else
            {
                attacktimer = Random.Range(0, attackintervall - 1);
            }
            
        }
    }
}
