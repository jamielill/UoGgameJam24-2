using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using TMPro;
using Unity.VisualScripting;

public class Optionsmenuscript : MonoBehaviour
{
    Resolution[] resolutions;
    public GameObject OptionsMenu;
    public GameObject MainMenu;
    public TMP_Dropdown Resolution;
    public TMP_Dropdown textureDropdown;
    public TMP_Dropdown qualityDropdown;
    public TMP_Dropdown aaDropdown;
    public AudioMixer MasterMix;
    public GameObject Controls;
    public GameObject Options;

    private void Start()
    {
        resolutions = Screen.resolutions;

        Resolution.ClearOptions();

        List<string> options = new List<string>();

        int currentResolution = 0;

        for (int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + " x " + resolutions[i].height;
            options.Add(option);

            if (resolutions[i].width == Screen.currentResolution.width && resolutions[i].height == Screen.currentResolution.height)
            {
                currentResolution = i;
            }
        }

        Resolution.AddOptions(options);
        Resolution.value = currentResolution;
        Resolution.RefreshShownValue();

    }


    public void SetAntiAliasing(int aaIndex)
    {
        QualitySettings.antiAliasing = aaIndex;
        //qualityDropdown.value = 6;
    }
    public void SetTextureQuality(int textureIndex)
    {
        QualitySettings.globalTextureMipmapLimit = textureDropdown.value;
        //qualityDropdown.value = 6;
    }
    public void SetResolution(int resolutionIndex)
    {
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }

    public void Back()
    {
        OptionsMenu.SetActive(false);
        MainMenu.SetActive(true);
    }
    public void SetFullscreen(bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
    }
    public void DebugButton()
    {
        Debug.Log("texture quality is " + QualitySettings.globalTextureMipmapLimit);
        Debug.Log(textureDropdown.value);
    }

    public void MainVolume(float slidervalue)
    {
        MasterMix.SetFloat("MainMix", Mathf.Log10(slidervalue) * 20);
        Debug.Log(slidervalue);
    }

    public void SetMusicLvl(float musicLvl)
    {
        MasterMix.SetFloat("Music", Mathf.Log10(musicLvl) * 20);
    }

    public void SetSFXLevel(float sfxlevel)
    {
        MasterMix.SetFloat("SoundEffects", sfxlevel);
    }

    public void ShowControls()
    {
        Options.SetActive(false);
        Controls.SetActive(true);
    }

    public void HideControls()
    {
        Options.SetActive(true);
        Controls.SetActive(false);
    }
}
