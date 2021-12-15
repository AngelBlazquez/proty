using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

///<summary>
/// menu of settings ( volume and resolution )
/// by Guyot Vincent
///<summary>
public class SettingsMenu : MonoBehaviour
{
    public AudioMixer audioMixer;

    public Slider slider;

    public Dropdown resolutionDropdown;

    Resolution[] resolutions;

    ///<summary>
    /// lists all the resolutions of the actual screen
    ///<summary>
    void Start()
    {
        slider.value = PlayerPrefs.GetFloat("VolumeSave");

        resolutions = Screen.resolutions;

        resolutionDropdown.ClearOptions();

        List<string> options = new List<string>();

        int currentResolutionIndex = 0;
        for (int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + " x " + resolutions[i].height;
            options.Add(option);

            if (resolutions[i].width == Screen.currentResolution.width
                && resolutions[i].height == Screen.currentResolution.height)
            {
                currentResolutionIndex = i;
            }
        }

        resolutionDropdown.AddOptions(options);
        resolutionDropdown.value = currentResolutionIndex;
        resolutionDropdown.RefreshShownValue();
    }

    ///<summary>
    /// change the volume of the game
    ///<summary>
    public void setVolume (float volume)
    {
        audioMixer.SetFloat("volume", volume);
    }

    ///<summary>
    /// change the resolution of the game
    ///<summary>
    public void SetResolution (int resolutionIndex)
    {
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }

    ///<summary>
    /// save the options
    ///<summary>
    public void SaveOptions()
    {
        float value;
        audioMixer.GetFloat("volume", out value);
        PlayerPrefs.SetFloat("VolumeSave", value);
        PlayerPrefs.Save();
    }
}
