using UnityEngine;

public class Blaster : MonoBehaviour
{
    public Transform FirePoint;
    public GameObject projectilePrefab;

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        } //Om du trycker på en knapp registrerad som "Fire1" så skapar den en projectile. Mattias.
    }
    void Shoot()
    {
        Instantiate(projectilePrefab, FirePoint.position, FirePoint.rotation);
    }


}
