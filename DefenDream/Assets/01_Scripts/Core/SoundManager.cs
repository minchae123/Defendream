using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoSingleton<SoundManager>
{
    private AudioSource audioSource;
    private AudioSource bgmAudioSource;

    private string bgmKey = "BGMVolume";
    private string effectKey = "EffectVolume";

    [Header("Player")]
    [Header("Enemy")]
    [Header("Skill")]
    [Header("UI")]
    [SerializeField] private AudioClip cardSelectSound;
    //[Header("ETC")]

    private void Awake()
    {
        bgmAudioSource = GameManager.instance.mainCam.GetComponent<AudioSource>();
        audioSource = GetComponent<AudioSource>();
    }
    private void Start()
    {
        float bgmVolume = PlayerPrefs.GetFloat(bgmKey, 0.1f); // 있으면 해당 키값으로 없으면 기본값 (0.1)
        float effectVolume = PlayerPrefs.GetFloat(effectKey, 0.4f);

        bgmAudioSource.loop = true;
        bgmAudioSource.volume = bgmVolume;
        audioSource.volume = effectVolume;
    }

    // 볼륨 조절 호출 함수
    public void SetBGMVolume(float value)
    {
        bgmAudioSource.volume = value;
        PlayerPrefs.SetFloat(bgmKey, value);
    }
    public void SetEffectVolume(float value)
    {
        audioSource.volume = value;
        PlayerPrefs.SetFloat(effectKey, value);
    }

    public void PlayCardSelectSound()
    {
        audioSource.PlayOneShot(cardSelectSound);
    }
}
