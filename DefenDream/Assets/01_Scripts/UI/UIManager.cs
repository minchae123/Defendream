using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject settingPanel;

    private void Start()
    {
        settingPanel.SetActive(false);
    }
    public void ClickSettingOnButton()
    {
        settingPanel.SetActive(true);
    }
    public void ClickSettingOffButton()
    {
        settingPanel.SetActive(false);
    }
}
