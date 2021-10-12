using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrunderFiender : MonoBehaviour
{
    public Rigidbody2D FiendeBody;
    public int direction = 1;
    public int VerticalDirection = 1;
    public float attacktimer;
    public float attackintervall = 10;
    public float verticalstartpos;
    public GameObject deadparticle;

    // Start is called before the first frame update
    public void setup()
    {
        print("yes");
        FiendeBody = GetComponent<Rigidbody2D>();
        verticalstartpos = Random.Range(1, 4); // lagrar start höjden av fienden
    }

    public void Moving()
    {
        if ((transform.position.x > 4 && direction == 1) || (transform.position.x < -4 && direction == -1)) // Checkar om fienden är nära kanterna och vänder den om den färdas i fel riktning - Gustav
        {
            direction *= -1;
        }
        FiendeBody.velocity = new Vector2(5 * direction, (transform.position.y - verticalstartpos) * VerticalDirection); //multiplicerar hastigheten med riktningen så att den färdas i rätt riktning
        // Y axeln håller objektet stilla om den är vid starthöjden av objektet, om den sedan flyttas lite neråt så kommer den att fortsätta i den riktningen och vänds om vid kanten av skärmen.
    }

    public void BasicAttack()
    {
        if (transform.position.y < -4 && VerticalDirection == 1)
        {
            VerticalDirection = -1; // noterar när den är nära den nedre kanten av skärmen och vänder den om i fall att den är det
        }


        attacktimer += Time.deltaTime;
        if (attacktimer > attackintervall) // räknar upp till 15 sekunder och får fienden att attackera 
        {
            VerticalDirection = 1; // ser till att fienden färdas i rätt riktning 

            transform.position -= new Vector3(0, 0.1f, 0); //flyttar ner objektet lite vilket får den att börja åka ner

            attacktimer = 0; //nollställer räknaren. 
        }
    }

    public void dead()
    {
        Instantiate(deadparticle, transform.position, Quaternion.identity);
    }
}
