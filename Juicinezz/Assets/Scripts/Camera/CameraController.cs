using UnityEngine;

//av K-J
public class CameraController : MonoBehaviour
{
    public static CameraController current = null;

    [SerializeField,Range(0f,0.2f)] float shakeMagnitude = 0f; //hur stark screenshaken ska vara
    [SerializeField,Range(0.2f,0.6f)] float shakeTime = 0f;//hur l�nge den ska vara

    float timer = 0f;//timer som h�ller koll p� n�r screenshaken ska sluta
    float power = 0f;//hur mycket positionen kan �ndras
    float powerReduction = 0f;//hur mycket mindre power man ska f� varje sekund

    private void Awake()
    {
        current = this;
    }

    void FixedUpdate()
    {
        if(timer > 0f)
        {
            timer -= Time.fixedDeltaTime;

            Vector3 shakePosition = new Vector3(Random.Range(-power, power), Random.Range(-power, power), 0f); //hittar en random float mellan negativ och positiv power, f�r b�de x och y position

            transform.position = new Vector3(0f,0f,-10f) + shakePosition; //ger kameran en ny position

            power -= powerReduction * Time.deltaTime;//Minskar kraften p� screenshaken (s� att det blir en smoth transition och att den inte g�r fr�n 100% till 0% p� en frame)
        }
        else
        {
            transform.position = new Vector3(0f, 0f, -10f);
        }
    }


    public void ScreenShake()
    {
        //ger private variablerna r�tt v�rde baserat p� variablerna som man kan �ndra i inspektorn
        timer = shakeTime;
        power = shakeMagnitude;
        powerReduction = power / timer;
    }
}
