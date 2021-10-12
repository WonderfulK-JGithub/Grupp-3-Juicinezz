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
        } //Om du trycker p� en knapp registrerad som "Fire1" s� skapar den en projectile. Mattias.
    }
    void Shoot()
    {
        Instantiate(projectilePrefab, FirePoint.position, FirePoint.rotation);
    }


}
