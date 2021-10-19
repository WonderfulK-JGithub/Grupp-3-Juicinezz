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
    private void Start()
    {
       
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }

        if (LetsButtonMash)
        {
            cooldownTimer += Time.deltaTime;
            if (shootCooldown <= cooldownTimer)
            {
                Shoot();
                cooldownTimer = 0;
            }

            Timer += Time.deltaTime;
            if (Timer >= countDown)
            {
                LetsButtonMash = false;
            }
        }
   
    }
    void Shoot()
    {
        Instantiate(projectilePrefab, FirePoint.position, FirePoint.rotation);
    }


}
