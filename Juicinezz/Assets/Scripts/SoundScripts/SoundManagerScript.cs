using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManagerScript : MonoBehaviour
{
    public static AudioClip Damage, GameDeath, KillSound, LobbyClick, PowerUp, Shoot, StartRound; //Definerar som audiclip /Theo
    static AudioSource audioSrc;




    void Start() //Parar ihop r�tt variabel med r�tt audioclip
    {
        Damage = Resources.Load<AudioClip>("Damage");
        GameDeath = Resources.Load<AudioClip>("Death");
        KillSound = Resources.Load<AudioClip>("Kill");
        LobbyClick = Resources.Load<AudioClip>("Click");
        PowerUp = Resources.Load<AudioClip>("1Up");
        Shoot = Resources.Load<AudioClip>("Shoot");
        StartRound = Resources.Load<AudioClip>("Start");

        audioSrc = GetComponent<AudioSource>();
    }
    void Update()
    {

    }

    public static void PlaySound(string clip) //Anv�nder clip string value som en paramiter d�r den parar ihop "Damage" med korrekt ljudfil /Theo
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
        }
    }
}