using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MercenaryContent : MonoBehaviour, IPointerClickHandler
{
    private MercenaryCollected mercenaryCollected;
    public MercenaryInfo info;
    [SerializeField] private Image mercenaryImage;
    public bool isCanClick = false;

    private void Awake()
    {
        mercenaryCollected = FindObjectOfType<MercenaryCollected>();
    }

    private void Start()
    {
        mercenaryImage.sprite = info.MercenarySprite;
        info.MercenaryPrice = info.Price.ToString() + "¿ø";
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (isCanClick)
        {
            mercenaryCollected.ShowChange(info);
        }
    }
}
