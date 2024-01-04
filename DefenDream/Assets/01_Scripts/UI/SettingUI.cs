using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingUI : MonoBehaviour
{
    [Header("SettingPanel")]
    [SerializeField] private GameObject settingPanel;
    [Header("SoundUI")]
    [SerializeField] private Slider bgmSlider;
    [SerializeField] private Slider sfxSlider;

    private string bgmKey = "BGMVolume";
    private string sfxKey = "SFXVolume";

    private bool isSetting = false;

    private void Start()
    {
        isSetting = false;
        settingPanel.SetActive(false);

        float bgmVolume = PlayerPrefs.GetFloat(bgmKey);
        float sfxVolume = PlayerPrefs.GetFloat(sfxKey);

        bgmSlider.value = bgmVolume;
        sfxSlider.value = sfxVolume;
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if (isSetting)
            {
                settingPanel.SetActive(false);
                Time.timeScale = 0;
                isSetting = false;  
            }
            else
            {
                Time.timeScale = 1;
                settingPanel.SetActive(true);
                isSetting = true;
            }
        }
    }

    public void BGMSliderChangedVolume()
    {
        float bgmVolume = bgmSlider.value;

        SoundManager.Instance.SetBGMVolume(bgmVolume);
        PlayerPrefs.SetFloat(bgmKey, bgmVolume);
    }

    public void SFXSliderChangedVolume()
    {
        float sfxVolume = sfxSlider.value;

        SoundManager.Instance.SetSFXVolume(sfxVolume);
        PlayerPrefs.SetFloat(sfxKey, sfxVolume);
    }

    public void OnClickSettingButton()
    {
        isSetting = true;
        settingPanel.SetActive(isSetting);
    }
    public void OnClickContinueButton()
    {
        isSetting = false;
        settingPanel.SetActive(isSetting);
    }
    public void OnClickRestartButton()
    {
        print("다시시작");
    }
    public void OnClickTitleSceneButton()
    {
        print("시작으로");
    }
}
