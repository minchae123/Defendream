using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeekManager : MonoBehaviour
{
    [Header("Time")]
    [SerializeField] private float _dayTime;
    private float _curTime;
    private bool _isEnded;

    [Header("Stress")]
    private int _stressValue = 0;
    [SerializeField] private Image _stressUI;
    [SerializeField] private Sprite[] _stress;
    [Header("Week")]
    [SerializeField] private Image[] _week;
    [SerializeField] private Sprite[] _OX;

    //JSON해줘만채야(일월화수목금토)
    private int _weekIndex;


    void Start()
    {
        ResetTimer();
    }
    void Update()
    {
        if (_isEnded)
            return;

        CheckTimer();

        StressCheck();
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
        Debug.Log(_week[_weekIndex].sprite);
        Debug.Log("End");
        Debug.Log(_curTime);
        _isEnded = true;
        //스트레스 수치 따라 _week바꾸기
        if (_stressValue >= 6)
            _week[_weekIndex].sprite = _OX[0];
        else
            _week[_weekIndex].sprite = _OX[1];
        //컷씬

        //다음날 직전(상점창)
        _weekIndex++;
        Debug.Log(_week[_weekIndex].sprite);
        _stressValue = 0;
    }

    //다음날 넘어가면
    public void ResetTimer()
    {
        _curTime = _dayTime;
        Debug.Log(_curTime);
        _isEnded = false;
        Debug.Log("Start");
    }

    public void StressUp()
    {
        _stressValue++;
    }
}
