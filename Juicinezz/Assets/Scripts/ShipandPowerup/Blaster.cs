using UnityEngine;

public class Blaster : MonoBehaviour
{
    public Transform FirePoint;
    public GameObject projectilePrefab;
    float Timer;
    public bool LetsButtonMash = false;
    float countDown = 8;
    float shootCooldown = 0.2f;
    float cooldownTimer = 0;
    void Update()
    {
        if(ScoreManager.current.gameIsOngoing)
        {
            cooldownTimer += Time.deltaTime;

            if (Input.GetButtonDown("Fire1") && shootCooldown <= cooldownTimer && LetsButtonMash == false)
            {
                Shoot();//BANG. Mattias.
                cooldownTimer = 0;
            }

            if (LetsButtonMash)
            {

                if (shootCooldown <= cooldownTimer)
                {
                    Shoot();
                    cooldownTimer = 0;//Auto Bang bang tills cooldown och cooldown timer är lika. Mattias.
                }

                Timer += Time.deltaTime;
                if (Timer >= countDown)
                {
                    LetsButtonMash = false;
                    Timer = 0;
                }
            }
        }
        
   
    }
    void Shoot()
    {
        SoundManagerScript.PlaySound("Shoot");
        CameraController.current.ScreenShake();
        Instantiate(projectilePrefab, FirePoint.position, FirePoint.rotation); // Skapar Bullet. Mattias.
    }


}
