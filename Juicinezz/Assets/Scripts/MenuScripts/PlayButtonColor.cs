using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ColorActivity : MonoBehaviour
{
    private Button PlayButton;

    private ColorBlock theColor;

    void Awake()
    {
        PlayButton = GetComponent<Button>();
        theColor = GetComponent<Button>().colors;
    }


    public void ButtonTransitionColors()
    {

        theColor.highlightedColor = Color.blue;
        theColor.normalColor = Color.cyan;
        theColor.pressedColor = Color.green;

        PlayButton.colors = theColor;
        print("Cliked");
    }
}