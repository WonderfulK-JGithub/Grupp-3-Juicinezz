using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayScript : MonoBehaviour
{
    public void Scene1()
    {
        SceneManager.LoadScene("Scene1");
        SoundManagerScript.PlaySound("Start");
    }
}
