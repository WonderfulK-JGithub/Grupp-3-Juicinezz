using UnityEngine;

public class Blaster : MonoBehaviour
{
    public Transform FirePoint;
    public GameObject projectilePrefab;
    float Timer;
    float shootSpeed = 0.5f;
    float ssppppeeeeed = 1;
    private void Start()
    {
        //  Timer += Time.deltaTime;
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }

        /*  if (Input.GetButtonDown("Fire1") && Timer> shootSpeed*ssppppeeeeed)
        {
            Shoot();
            Timer = 0;
        }*/ //Om du trycker på en knapp registrerad som "Fire1" så skapar den en projectile. Mattias.

    }
    void Shoot()
    {
        Instantiate(projectilePrefab, FirePoint.position, FirePoint.rotation);
    }


}
