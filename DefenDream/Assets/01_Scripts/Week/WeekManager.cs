using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeekManager : MonoSingleton<WeekManager>
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

    //JSON���ุä��(�Ͽ�ȭ�������)
    private int _weekIndex;

    [SerializeField] private Image _fadeImage;


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
        //Debug.Log(_week[_weekIndex].sprite);
        //Debug.Log("End");
        //Debug.Log(_curTime);
        _isEnded = true;
        //��Ʈ���� ��ġ ���� _week�ٲٱ�
        if (_stressValue >= 6)
            _week[_weekIndex].sprite = _OX[0];
        else
            _week[_weekIndex].sprite = _OX[1];
        //�ƾ�

        _weekIndex++;
        //Debug.Log(_week[_weekIndex].sprite);
        _stressValue = 0;

        //������ ����(����â) +++++++ ���⼭ ���̶� �츮�� �� ������°� �ؾ���
        _fadeImage.gameObject.SetActive(true);
        _fadeImage.DOFade(1, 1).OnComplete(() =>
        {
            print("dulrllllllllllll");
            MercenaryCollected.Instance.ActiveStore();
        });

    }

    //������ �Ѿ��
    public void ResetTimer()
    {
        _curTime = _dayTime;
        _isEnded = false;

        MercenaryCollected.Instance.InactiveStoreAndInventory();
        _fadeImage.DOFade(0, 1).OnComplete(() =>
        {
            _fadeImage.gameObject.SetActive(false);
        });
    }

    public void StressUp()
    {
        _stressValue++;
    }
}
