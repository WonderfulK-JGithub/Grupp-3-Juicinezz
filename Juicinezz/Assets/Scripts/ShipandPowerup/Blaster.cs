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
            if (Input.GetButtonDown("Fire1"))
            {
                Shoot();//BANG. Mattias.
            }

            if (LetsButtonMash)
            {

                cooldownTimer += Time.deltaTime;
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
