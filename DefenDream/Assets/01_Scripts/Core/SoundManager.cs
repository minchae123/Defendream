using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoSingleton<SoundManager>
{
    private AudioSource audioSource;
    private AudioSource bgmAudioSource;

    private string bgmKey = "BGMVolume";
    private string sfxKey = "SFXVolume";

    [Header("Player")]
    [Header("Enemy")]
    [Header("Skill")]
    [Header("UI")]
    [SerializeField] private AudioClip cardSelectSound;
    //[Header("ETC")]

    private void Awake()
    {
        bgmAudioSource = Camera.main.GetComponent<AudioSource>();
        audioSource = GetComponent<AudioSource>();

        float bgmVolume = PlayerPrefs.GetFloat(bgmKey, 0.1f);
        float sfxVolume = PlayerPrefs.GetFloat(sfxKey, 0.4f);
        bgmAudioSource.volume = bgmVolume;
        audioSource.volume = sfxVolume;
    }
    private void Start()
    {
        bgmAudioSource.Play();
        bgmAudioSource.loop = true;
    }

    // 볼륨 조절 호출 함수
    public void SetBGMVolume(float value)
    {
        bgmAudioSource.volume = value;
        PlayerPrefs.SetFloat(bgmKey, value);
    }
    public void SetSFXVolume(float value)
    {
        audioSource.volume = value;
        PlayerPrefs.SetFloat(sfxKey, value);
    }

    public void PlayCardSelectSound()
    {
        audioSource.PlayOneShot(cardSelectSound);
    }
}
