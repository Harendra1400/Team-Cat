using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class soundmanager : MonoBehaviour
{
    [SerializeField] Slider volumeslider;
    // Start is called before the first frame update
    void Start()
    {
        if (!PlayerPrefs.HasKey("musicVolume"))
        {
            PlayerPrefs.SetFloat("musicVOlume", 1);
            Load();
        }
        else
        {
            Load();
        }
    }

    public void ChangeVolume()
    {
        AudioListener.volume = volumeslider.value;
        Save();
    }

    private void Load()
    {
        volumeslider.value = PlayerPrefs.GetFloat("musicVOlume");
    }

    private void Save()
    {
        PlayerPrefs.SetFloat("musicVolume",volumeslider.value);
    }
}
