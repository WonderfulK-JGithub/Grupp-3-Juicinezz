using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField,Range(0.1f,0.5f)] float shakeSmoothness = 0f;
    [SerializeField,Range(0f,2f)] float shakeBaseMagnitude = 0f;
    [SerializeField,Range(0.2f,0.6f)] float shakeTime = 0f;

    float timer = 0f;

    void FixedUpdate()
    {
        if(timer > 0f)
        {
            timer -= Time.fixedDeltaTime;

            Vector3 shakePosition = new Vector3(Random.Range(-shakeBaseMagnitude, shakeBaseMagnitude), Random.Range(-shakeBaseMagnitude, shakeBaseMagnitude), -10f);

            transform.position = Vector3.Lerp(transform.position,shakePosition,shakeSmoothness);
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(0f, 0f, -10f), shakeSmoothness);
        }
    }


    public void ScreenShake()
    {
        timer = shakeTime;
    }
}
