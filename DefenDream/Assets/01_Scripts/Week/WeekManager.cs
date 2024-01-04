using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class WeekManager : MonoSingleton<WeekManager>
{
    [Header("Time")]
    [SerializeField] private float _dayTime;
    private float _curTime;
    private bool _isEnded;

    private float _lateUpdateTime = 0;
    [SerializeField] private float _decreaseCycle = 0;

    [Header("TimeUI")]
    [SerializeField] private TextMeshProUGUI timeText;
    [SerializeField] private Image timeFillImage;

    [Header("Stress")]
    private int _stressValue = 0;
    [SerializeField] private Image _stressUI;
    [SerializeField] private Sprite[] _stress;
    [Header("Week")]
    public List<bool> _goodNights;

    [SerializeField] private TextMeshProUGUI _dayText;
    private readonly string[] weeks = { "일요일", "월요일", "화요일", "수요일", "목요일", "금요일", "토요일" };
    private int _weekIndex = 0;

    [SerializeField] private Image _fadeImage;

    public List<PoolableMono> activeObjects = new();

    [SerializeField] private GameObject bedLight;

    void Start()
    {
        //디버깅용 나중에 씬 체인지하고는 어떻게 할지 모름
        Time.timeScale = 0;
        _isEnded = true;
        MercenaryCollected.Instance.ActiveStore();
    }
    void Update()
    {
        if (_weekIndex == 7 && _isEnded)
            SceneManager.LoadScene(2);


        if (_isEnded)
            return;

        CheckTimer();
        StressCheck();
        SetTimerText();
        _lateUpdateTime += Time.deltaTime;
        if (_lateUpdateTime > _decreaseCycle)
        {
            StressDown();
        }

        if(Input.GetKeyDown(KeyCode.M))
        {
            Cheat();
        }
    }

    private void StressCheck()
    {
        if (_stressValue >= 10)
            _stressUI.sprite = _stress[0];
        else if (_stressValue >= 8)
            _stressUI.sprite = _stress[1];
        else if (_stressValue >= 6)
            _stressUI.sprite = _stress[2];
        else if (_stressValue >= 4)
            _stressUI.sprite = _stress[3];
        else if (_stressValue >= 2)
            _stressUI.sprite = _stress[4];
        else
            _stressUI.sprite = _stress[5];
    }
    private void CheckTimer()
    {
        if (0 < _curTime)
        {
            _curTime -= Time.deltaTime;
            //Debug.Log(_curTime);
        }
        else if (!_isEnded)
        {
            EndTimer();
        }
    }
    private void EndTimer()
    {
        _curTime = 0;
        _isEnded = true;
        //스트레스 수치 따라 _week바꾸기
        if (_stressValue >= 6)
            _goodNights.Add(false);
        else
            _goodNights.Add(true);

        if (_weekIndex < 7)
            _weekIndex++;
        _stressValue = 0;

        //다음날 직전(상점창) +++++++ 여기서 적이랑 우리팀 다 사라지는거 해야함
        for (int i = activeObjects.Count - 1; i >= 0; i--)
            PoolManager.Instance.Push(activeObjects[i]);

        activeObjects.Clear();
        _fadeImage.gameObject.SetActive(true);
        _fadeImage.DOFade(1, 1).OnComplete(() =>
        {
            MercenaryCollected.Instance.ActiveStore();
            Time.timeScale = 0;
        });

    }

    //다음날 넘어가면
    public void ResetTimer()
    {
        StartCoroutine(NextDay());
    }

    private IEnumerator NextDay()
    {
        Time.timeScale = 1;
        MercenaryCollected.Instance.InactiveStoreAndInventory();
        _dayText.enabled = true;
        _dayText.text = weeks[_weekIndex];
        yield return new WaitForSeconds(1.5f);
        _curTime = _dayTime;
        _isEnded = false;

        _dayText.enabled = false;
        _fadeImage.DOFade(0, 1).OnComplete(() =>
        {
            _fadeImage.gameObject.SetActive(false);
        });
    }

    public void StressUp()
    {
        _stressValue++;
        bedLight.SetActive(true);
        StartCoroutine(Off());
        _lateUpdateTime = 0;
    }

    public void Cheat()
    {
        _curTime -= 30;
    }

    private IEnumerator Off()
    {
        yield return new WaitForSeconds(0.5f);
        bedLight.SetActive(false);
    }

    public void StressDown()
    {
        if (_stressValue > 0)
            _stressValue--;
    }

    private void SetTimerText()
    {
        timeText.text = $"{(int)_curTime}";
        timeFillImage.fillAmount = _curTime / _dayTime;
    }
}
