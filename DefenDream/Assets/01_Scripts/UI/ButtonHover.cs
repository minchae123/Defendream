using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class ButtonHover : MonoBehaviour
{
	public void Hover()
	{
		transform.DOScale(Vector3.one * 1.1f, 0.5f);
	}

	public void ResetScale()
	{
		transform.DOScale(Vector3.one, 0.5f);
	}
}
