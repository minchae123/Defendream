using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "SO/MercenaryInfo")]
public class MercenaryInfo : ScriptableObject
{
    public string MercenaryName;
    public Sprite MercenarySprite;

    [TextArea]
    public string MercenaryExplain;

    public int Price;
    public string MercenaryPrice;
}
