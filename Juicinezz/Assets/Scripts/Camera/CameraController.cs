using UnityEngine;

//av K-J
public class CameraController : MonoBehaviour
{
    public static CameraController current = null;

    [SerializeField,Range(0f,0.2f)] float shakeMagnitude = 0f; //hur stark screenshaken ska vara
    [SerializeField,Range(0.2f,0.6f)] float shakeTime = 0f;//hur länge den ska vara

    float timer = 0f;//timer som håller koll på när screenshaken ska sluta
    float power = 0f;//hur mycket positionen kan ändras
    float powerReduction = 0f;//hur mycket mindre power man ska få varje sekund

    private void Awake()
    {
        current = this;
    }

    void FixedUpdate()
    {
        if(timer > 0f)
        {
            timer -= Time.fixedDeltaTime;

            Vector3 shakePosition = new Vector3(Random.Range(-power, power), Random.Range(-power, power), 0f); //hittar en random float mellan negativ och positiv power, för både x och y position

            transform.position = new Vector3(0f,0f,-10f) + shakePosition; //ger kameran en ny position

            power -= powerReduction * Time.deltaTime;//Minskar kraften på screenshaken (så att det blir en smoth transition och att den inte går från 100% till 0% på en frame)
        }
        else
        {
            transform.position = new Vector3(0f, 0f, -10f);
        }
    }


    public void ScreenShake()
    {
        //ger private variablerna rätt värde baserat på variablerna som man kan ändra i inspektorn
        timer = shakeTime;
        power = shakeMagnitude;
        powerReduction = power / timer;
    }
}
