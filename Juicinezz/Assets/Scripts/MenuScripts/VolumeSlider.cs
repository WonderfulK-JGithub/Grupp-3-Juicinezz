using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsScript : MonoBehaviour //Kunna sänka/Höja volymen och att den sparas så att man inte måste sänka varje gång man spelar det. /Theo
{
    [SerializeField] Slider VolumeSlider;

    private void Start()
    {
        if (!PlayerPrefs.HasKey("musicVolume"))
        {
            PlayerPrefs.SetFloat("musicVolume", 1);
            Load();
        }

        else
        {
            Load();
        }
    }
    public void ChangeVolume() 
    {
        AudioListener.volume = VolumeSlider.value;
        Save();
    }

    private void Load() 
    {
        VolumeSlider.value = PlayerPrefs.GetFloat("musicVolume");
    }
    private void Save() //För att kunna spara volymen så att man inte måste sänka den varje gång man spelar spelet.
    {
        PlayerPrefs.SetFloat("musicVolume", VolumeSlider.value);
    }
}
