using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="SO/Week")]
public class CheckWeekSO : ScriptableObject
{
    public List<bool> goodOrBad;
    public void ResetList()
    {
        goodOrBad.Clear();
    }
}
