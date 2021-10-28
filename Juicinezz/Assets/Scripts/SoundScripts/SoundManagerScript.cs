using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManagerScript : MonoBehaviour
{
    public static AudioClip Damage, GameDeath, KillSound, LobbyClick, PowerUp, Shoot, StartRound, Explosion, SpeedBoost, EnemyShoot; //Definerar som audiclip /Theo
    static AudioSource audioSrc;




    void Start() //Parar ihop rätt variabel med rätt audioclip /Theo
    {
        Damage = Resources.Load<AudioClip>("Damage");
        GameDeath = Resources.Load<AudioClip>("Death");
        KillSound = Resources.Load<AudioClip>("KillSound");
        LobbyClick = Resources.Load<AudioClip>("LobbyClick");
        PowerUp = Resources.Load<AudioClip>("1Up");
        Shoot = Resources.Load<AudioClip>("Shoot");
        StartRound = Resources.Load<AudioClip>("Startsound");
        Explosion = Resources.Load<AudioClip>("Explosion");
        SpeedBoost = Resources.Load<AudioClip>("Speed");
        EnemyShoot = Resources.Load<AudioClip>("EnemyShoot");

        audioSrc = GetComponent<AudioSource>();
    }
    void Update()
    {

    }

    public static void PlaySound(string clip) //Använder clip string value som en paramiter där den parar ihop "Damage" med korrekt ljudfil /Theo
    {
        switch (clip)
        {
            case "Damage":
                audioSrc.PlayOneShot(Damage);
                break;
            case "Death":
                audioSrc.PlayOneShot(GameDeath);
                break;
            case "Kill":
                audioSrc.PlayOneShot(KillSound);
                break;
            case "Click":
                audioSrc.PlayOneShot(LobbyClick);
                break;
            case "1Up":
                audioSrc.PlayOneShot(PowerUp);
                break;
            case "Shoot":
                audioSrc.PlayOneShot(Shoot);
                break;
            case "Start":
                audioSrc.PlayOneShot(StartRound);
                break;
            case "Explosion":
                audioSrc.PlayOneShot(Explosion);
                break;
            case "Speed":
                audioSrc.PlayOneShot(SpeedBoost);
                break;
            case "OppShoot":
                audioSrc.PlayOneShot(EnemyShoot);
                break;
        }
    }
}
// För att spela ljuden SoundManagerScript.PlaySound ("InsertName"); /Theo