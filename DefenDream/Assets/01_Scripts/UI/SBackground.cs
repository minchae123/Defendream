using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class SBackground : MonoBehaviour
{
    public SpriteRenderer sp;
    public float speed;

    public GameObject[] cloud;
    public float x, y , yy;

	private void Start()
	{
		StartCoroutine(Cloud());
		StartCoroutine(Cloud());
	}

	private void Update()
    {
        Vector2 offset = Vector2.left * speed * Time.deltaTime + sp.material.mainTextureOffset;
        sp.material.SetTextureOffset("_MainTex", offset);
    }

    IEnumerator Cloud()
	{
        while(true)
		{
            int r = Random.Range(0,1);
            float ry = Random.Range(y, yy);
			GameObject c = Instantiate(cloud[r], new Vector3(x, ry, 81.5f), Quaternion.identity);

            float rr = Random.Range(5, 8);
            c.transform.DOMoveX(-140, rr);

            Destroy(c, rr);

            int t = Random.Range(2, 5);
            yield return new WaitForSeconds(t);
		}
    }
}
