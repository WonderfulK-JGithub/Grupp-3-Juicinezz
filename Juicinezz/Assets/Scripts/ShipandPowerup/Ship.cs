using UnityEngine;

public class Ship : MonoBehaviour
{  
   public static float baseSpeed =10;
   public static float speed;
   public float HP = 3;

   public Animator anim;
    public bool invincibility = false;
    public float countDown = 5;
    float timer;

    public bool HitTheGas;
    public float slowcountDown = 15;
    public float speedtimer;

    public static Ship current;
    public Blaster blast;
    
    void Start()
    {
        current = this;
        speed = baseSpeed;
        blast = GetComponentInChildren<Blaster>();
    }


    public virtual void Update()
    {
        if(ScoreManager.current.gameIsOngoing)
        {
            // Kontroller för att styra spelaren. Mattias.
            if (Input.GetKey(KeyCode.W))
            {
                transform.position += new Vector3(0, speed, 0) * Time.deltaTime;
            }

            if (Input.GetKey(KeyCode.S))
            {
                transform.position += new Vector3(0, -speed, 0) * Time.deltaTime;
            }
            int dir = 0; // Styr animatorn. Mattias.
            if (Input.GetKey(KeyCode.A))
            {
                transform.position += new Vector3(-speed, 0, 0) * Time.deltaTime;
                dir -= 1;
            }

            if (Input.GetKey(KeyCode.D))
            {
                transform.position += new Vector3(speed, 0, 0) * Time.deltaTime;
                dir += 1;
            }

            anim.SetInteger("Dir", dir);
            if (invincibility) //Gör spelaren odödlig en liten stund och spelar en animation. Mattias.
            {
                anim.Play("Ship_Invincible");

                timer += Time.deltaTime;
                if (timer >= countDown)
                {

                    if (HP == 3)
                    {
                        anim.Play("Ship_idle");
                    }
                    else if (HP == 2)
                    {
                        anim.Play("Ship_Hurt1");
                    }
                    else if (HP == 1)
                    {
                        anim.Play("Ship_Hurt2");
                    }

                    timer = 0;
                    invincibility = false;
                }
            }
            if (HitTheGas)
            {
                speed = baseSpeed * 2;

                speedtimer += Time.deltaTime;
                if (speedtimer >= slowcountDown)
                {
                    speed = baseSpeed;
                    speedtimer = 0;
                    HitTheGas = false;
                }
            }
        }
        
        
    }
    public void TakeDamage(int damage)
    {
        if (!invincibility)
        {
            SoundManagerScript.PlaySound("Damage");
            HP -= damage;

            if(HP == 2)
            {
                anim.Play("Ship_Hurt1");
            }
            else if(HP == 1)
            {
                anim.Play("Ship_Hurt2");
            }
            else if (HP <= 0)
            {
                
                
                anim.Play("Ship_Expolde");
                SoundManagerScript.PlaySound("Explosion");
                enabled = false;
                GetComponent<BoxCollider2D>().enabled = false;
            }

            CameraController.current.ScreenShake();
        }
        

    }

    void AnimDestroy()
    {
        Destroy(gameObject);
        ScoreManager.current.GameOver();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Fiende"))
        {
            Destroy(collision.gameObject);
            TakeDamage(1);
        }
    }
}