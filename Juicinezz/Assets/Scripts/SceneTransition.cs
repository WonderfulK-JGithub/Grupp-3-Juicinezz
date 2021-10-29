using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour//av K-J
{
    public static SceneTransition current = null;


    [Range(-1f,1f)]
    public float time = 0f;//time är en variabel i shadern. Är den på -1 har bilden helt dissolvats och är den på 1 är den hel


    [SerializeField] Image overlayImage = null;//bilden som ska dissolvas
    Animator anim = null;//reference till animator

    int targetScene = 0;//vilken scene som ska laddas

    private void Awake()
    {
        Screen.SetResolution(1080, 1080,true);
        current = this;
        anim = GetComponent<Animator>();
    }


    void Update()
    {
        overlayImage.material.SetFloat("Vector1_7978148B", time);//Ger variabeln time på shadern rätt värde. Time heter Vector1_7978148B eftersom jag glömde ändra den
    }


    public void EnterScene(int index)
    {
        anim.Play("Transition_Leave");//spelar animationen som sker när man lämnar scenen
        targetScene = index;
    }

    void ChangeScene()//kallas av ett event i animationen Transition_Leave
    {
        SceneManager.LoadScene(targetScene);//laddar scenen
    }
}
