using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

//av K-J
public class SpawnedText : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI text = null;
    [SerializeField] float speed = 0f; //hur snabbt texten �ker upp�t
    public void ChangeText(string newText)
    {
        text.text = newText;
    }

    private void Update()
    {
        transform.position += Vector3.up * speed * Time.deltaTime;
    }
}
