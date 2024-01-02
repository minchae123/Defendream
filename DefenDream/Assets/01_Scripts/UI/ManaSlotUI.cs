using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ManaSlotUI : MonoBehaviour
{
    [SerializeField] private Image manaImage;

    public void WaitUpdating(float scale)
    {
        manaImage.color = Color.gray;
        transform.localScale = new Vector3(scale, 1, 1);
    }
    public void CleanUpSlot()
    {
        transform.localScale = Vector3.zero;
    }
    public void UpdateSlot(int currentMana, int slotNum)
    {
        if(currentMana < slotNum + 1)
        {
            return;
        }
        transform.localScale = Vector3.one;

        // »ö±òÁöÁ¤
        switch (slotNum)
        {
            case 0:
            case 1:
            case 2:
                manaImage.color = Color.green;
                break;
            case 3:
            case 4:
            case 5:
                manaImage.color = Color.yellow;
                break;
            case 6:
            case 7:
                manaImage.color = new Vector4(255f / 255f, 150f / 255f, 0f, 255f / 255f);
                break;
            case 8:
            case 9:
                manaImage.color = Color.red;
                break;
            default:
                break;
        }
    }
}
