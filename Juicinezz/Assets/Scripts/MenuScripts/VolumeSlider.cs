using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeSlider : MonoBehaviour //Kunna s�nka/H�ja volymen och att den sparas s� att man inte m�ste s�nka varje g�ng man spelar det. /Theo
{
    [SerializeField] Slider volumeSlider;

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
        AudioListener.volume = volumeSlider.value;
        Save();
    }

    private void Load() 
    {
        volumeSlider.value = PlayerPrefs.GetFloat("musicVolume");
    }
    private void Save() //F�r att kunna spara volymen s� att man inte m�ste s�nka den varje g�ng man spelar spelet.
    {
        PlayerPrefs.SetFloat("musicVolume", volumeSlider.value);
    }
}
