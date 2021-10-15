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
        if ((transform.position.x > 4 && direction == 1) || (transform.position.x < -4 && direction == -1)) // Checkar om fienden �r n�ra kanterna och v�nder den om den f�rdas i fel riktning - Gustav
        {
            direction *= -1;
        }
        FiendeBody.velocity = new Vector2(enemySpeed.x * direction, (transform.position.y - verticalstartpos) * VerticalDirection * enemySpeed.y); //multiplicerar hastigheten med riktningen s� att den f�rdas i r�tt riktning
        // Y axeln h�ller objektet stilla om den �r vid starth�jden av objektet, om den sedan flyttas lite ner�t s� kommer den att forts�tta i den riktningen och v�nds om vid kanten av sk�rmen.

        if (transform.position.y > verticalstartpos - 0.2 && VerticalDirection == -1) transform.position = new Vector3(transform.position.x, verticalstartpos, 0f); //om den �r n�ra sin verticalstartpos och ska upp�t placeras den d�r automatikst.

        if(transform.position.y == verticalstartpos)
        {
            targetRotation = 0f;//�ndrar vilken rotation fienden ska ha
        }
        else
        {
            if(isAttacking)
            {
                targetRotation = 25f * direction;//�ndrar vilken rotation fienden ska ha
            }
            else
            {
                targetRotation = 180 - 25f * direction; //�ndrar vilken rotation fienden ska ha
            }
        }
        currentRotation = Mathf.MoveTowardsAngle(currentRotation, targetRotation, rotationSpeed); //�ndrar rotations variabeln stegvis, s� att den inte �ndrar hela rotationen direkt
        transform.localRotation = Quaternion.Euler(new Vector3(0f, 0f, currentRotation)); //�ndrar rotationen
    }

    public void BasicAttack()
    {
        if (transform.position.y < -4 && VerticalDirection == 1)
        {
            VerticalDirection = -1; // noterar n�r den �r n�ra den nedre kanten av sk�rmen och v�nder den om i fall att den �r det
            isAttacking = false;
        }


        attacktimer += Time.deltaTime;
        if (attacktimer > attackintervall) // r�knar upp till 15 sekunder och f�r fienden att attackera 
        {
            if(Random.Range(0,2) == 0)
            {
                VerticalDirection = 1; // ser till att fienden f�rdas i r�tt riktning 

                transform.position -= new Vector3(0, 0.1f, 0); //flyttar ner objektet lite vilket f�r den att b�rja �ka ner

                attacktimer = 0; //nollst�ller r�knaren.

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
        ScoreManager.current.AddScorePoints(pointValue, transform.position);//l�gger till po�ng
        Instantiate(deadparticle, transform.position, Quaternion.identity);//skapar explotionen
        Destroy(gameObject); //tar bort fiende objektet
    }
}
