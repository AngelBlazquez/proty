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
    [SerializeField]
    private AudioMixer audioMixer;

    [SerializeField]
    private Slider slider;

    [SerializeField]
    private Dropdown resolutionDropdown;

    private Resolution[] resolutions;

    private List<Resolution> resolutionVoulu;

    [SerializeField]
    private GameObject keyConfigRef;
    [SerializeField]
    private GameObject fullScreenRef;
    [SerializeField]
    private GameObject resolutionRef;
    [SerializeField]
    private GameObject resolutionTextRef;



    /// <summary>
    /// Show the PC items if the platform isn't Android
    /// </summary>
    private void OnEnable()
    {
#if PLATFORM_ANDROID
#else
            if (keyConfigRef != null)
            {
                keyConfigRef.SetActive(true);
            }
            if (fullScreenRef != null)
            {
                fullScreenRef.SetActive(true);
            }
            if (resolutionRef != null)
            {
                resolutionRef.SetActive(true);
            }
            if (resolutionTextRef != null)
            {
                resolutionTextRef.SetActive(true);
            }
#endif
    }
    ///<summary>
    /// lists all the resolutions of the actual screen
    ///<summary>
    ///
    void Start()
    {

#if PLATFORM_ANDROID
        slider.value = PlayerPrefs.GetFloat("VolumeSave");
#else
        slider.value = PlayerPrefs.GetFloat("VolumeSave");
        Debug.Log("test");
            resolutions = Screen.resolutions;

            resolutionDropdown.ClearOptions();

            List<string> options = new List<string>();
            resolutionVoulu = new List<Resolution>();

            int currentResolutionIndex = 0;
            string option = resolutions[0].width + " x " + resolutions[0].height;
            options.Add(option);
            resolutionVoulu.Add(resolutions[0]);

            for (int i = 1; i < resolutions.Length; i++)
            {
                if (resolutions[i].width != resolutions[i - 1].width || resolutions[i].height != resolutions[i - 1].height)
                {
                    option = resolutions[i].width + " x " + resolutions[i].height;
                    options.Add(option);

                    resolutionVoulu.Add(resolutions[i]);
                }

                if (resolutions[i].width == Screen.currentResolution.width
                    && resolutions[i].height == Screen.currentResolution.height)
                {
                    currentResolutionIndex = i;
                }
            }

            resolutionDropdown.AddOptions(options);
            resolutionDropdown.value = currentResolutionIndex;
            resolutionDropdown.RefreshShownValue();
#endif
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
        Resolution resolution = resolutionVoulu[resolutionIndex];
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

    ///<summary>
    /// change to fullscreen or not
    ///<summary>
    public void SetFullscreen(bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
    }
}
