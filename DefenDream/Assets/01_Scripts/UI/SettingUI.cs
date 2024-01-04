using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SettingUI : MonoSingleton<SettingUI>
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
                Off();
            }
            else
            {
                On();
            }
        }
    }
    public void Off()
    {
        Time.timeScale = 1;
        settingPanel.SetActive(false);
        isSetting = false;
    }
    public void On()
	{
        Time.timeScale = 0;
        settingPanel.SetActive(true);
        isSetting = true;
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
        On();    
    }
    public void OnClickContinueButton()
    {
        Off();
    }
    public void OnClickRestartButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void OnClickTitleSceneButton()
    {
        SceneManager.LoadScene(0); // Ã¹¹øÂ°
    }
}
