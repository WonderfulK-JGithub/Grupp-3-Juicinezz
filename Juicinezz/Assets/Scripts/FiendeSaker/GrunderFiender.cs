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

    public Vector2 enemySpeed;
    public int pointValue;

    public bool isAttacking;

    public float targetRotation;
    public float currentRotation;
    public float rotationSpeed;

    // Start is called before the first frame update
    public void setup()
    {
        print("yes");
        FiendeBody = GetComponent<Rigidbody2D>();
    }

    public void Moving()
    {
        if ((transform.position.x > 4 && direction == 1) || (transform.position.x < -4 && direction == -1)) // Checkar om fienden är nära kanterna och vänder den om den färdas i fel riktning - Gustav
        {
            direction *= -1;
        }
        FiendeBody.velocity = new Vector2(enemySpeed.x * direction, (transform.position.y - verticalstartpos) * VerticalDirection * enemySpeed.y); //multiplicerar hastigheten med riktningen så att den färdas i rätt riktning
        // Y axeln håller objektet stilla om den är vid starthöjden av objektet, om den sedan flyttas lite neråt så kommer den att fortsätta i den riktningen och vänds om vid kanten av skärmen.

        if (transform.position.y > verticalstartpos - 0.2 && VerticalDirection == -1) transform.position = new Vector3(transform.position.x, verticalstartpos, 0f); //om den är nära sin verticalstartpos och ska uppåt placeras den där automatikst.

        if(transform.position.y == verticalstartpos)
        {
            targetRotation = 0f;//ändrar vilken rotation fienden ska ha
        }
        else
        {
            if(isAttacking)
            {
                targetRotation = 25f * direction;//ändrar vilken rotation fienden ska ha
            }
            else
            {
                targetRotation = 180 - 25f * direction; //ändrar vilken rotation fienden ska ha
            }
        }
        currentRotation = Mathf.MoveTowardsAngle(currentRotation, targetRotation, rotationSpeed); //ändrar rotations variabeln stegvis, så att den inte ändrar hela rotationen direkt
        transform.localRotation = Quaternion.Euler(new Vector3(0f, 0f, currentRotation)); //ändrar rotationen
    }

    public void BasicAttack()
    {
        if (transform.position.y < -4 && VerticalDirection == 1)
        {
            VerticalDirection = -1; // noterar när den är nära den nedre kanten av skärmen och vänder den om i fall att den är det
            isAttacking = false;
        }


        attacktimer += Time.deltaTime;
        if (attacktimer > attackintervall) // räknar upp till 15 sekunder och får fienden att attackera 
        {
            if(Random.Range(0,2) == 0)
            {
                VerticalDirection = 1; // ser till att fienden färdas i rätt riktning 

                transform.position -= new Vector3(0, 0.1f, 0); //flyttar ner objektet lite vilket får den att börja åka ner

                attacktimer = 0; //nollställer räknaren.

                isAttacking = true;
            }
            else
            {
                attacktimer = Random.Range(0,attackintervall - 1);
            }
           
        }
    }

    public void Dead()
    {
        ScoreManager.current.AddScorePoints(pointValue, transform.position);//lägger till poäng
        Instantiate(deadparticle, transform.position, Quaternion.identity);//skapar explotionen
        Destroy(gameObject); //tar bort fiende objektet
    }
}
