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
            Instantiate(Kula, FiendeBody.position, Quaternion.identity);

            attacktimer = 0;
        }
    }

    private void OnDestroy()
    {
        base.dead();
    }
}
