using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{
    public static SceneTransition current = null;


    [Range(-1f,1f)]
    public float time = 0f;


    [SerializeField] Image overlayImage = null;
    Animator anim = null;

    int targetScene = 0;

    private void Awake()
    {
        current = this;
        anim = GetComponent<Animator>();
    }


    void Update()
    {
        overlayImage.material.SetFloat("Vector1_7978148B", time);
    }


    public void EnterScene(int index)
    {
        anim.Play("Transition_Leave");
        targetScene = index;
    }

    void ChangeScene()
    {
        anim.speed = 0;
        SceneManager.LoadScene(targetScene);
    }
}
