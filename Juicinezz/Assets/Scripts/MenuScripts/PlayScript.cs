using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayScript : MonoBehaviour
{
    void Update()
    {
        Application.LoadLevel(1);
        SoundManagerScript.PlaySound("Start");
    }
}
