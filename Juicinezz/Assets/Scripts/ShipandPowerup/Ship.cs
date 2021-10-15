using UnityEngine;

public class Ship : MonoBehaviour
{
    [SerializeField]
    float speed = 5;
    float HP = 1;

    Animator anim;
    public bool invincibility = false;
    public float countDown = 5;
    float timer;

    public bool HitTheGas;
    public float slowcountDown = 15;
    float speedtimer;
    void Start()
    {
        anim = GetComponent<Animator>();
    }


    public virtual void Update()
    {// Kontroller för att styra spelaren. Mattias.
        if (Input.GetKey(KeyCode.W))
        {
            transform.position += new Vector3(0, speed, 0) * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.S))
        {
            transform.position += new Vector3(0, -speed, 0) * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.A))
        {
            transform.position += new Vector3(-speed, 0, 0) * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.D))
        {
            transform.position += new Vector3(speed, 0, 0) * Time.deltaTime;
        }
        if(invincibility)
        {
            anim.SetBool("Invicible", true);

            timer += Time.deltaTime;
            if (timer >= countDown)
            {
                anim.SetBool("Invicible", false);
                timer = 0;
                invincibility = false;
            }
        }
        if (HitTheGas)
        {
           speed *= 2;
            
            speedtimer += Time.deltaTime;
            if (speedtimer >= slowcountDown)
            {
              speed /= 2;
                speedtimer = 0;
                HitTheGas = false;
            }
        }
        
    }
    public void TakeDamage(int damage)
    {
        if (!invincibility)
        {
            HP -= damage;

            if (HP <= 0)
            {
                Destroy(gameObject);
            }
        }
        

    }
}