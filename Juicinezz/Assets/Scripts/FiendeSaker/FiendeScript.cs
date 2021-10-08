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


}
