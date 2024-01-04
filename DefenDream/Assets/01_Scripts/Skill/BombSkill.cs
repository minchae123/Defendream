using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BombSkill : PoolableMono
{
    private Animator anim;
    private Rigidbody rb;

    [SerializeField] private GameObject bombTex;
    [SerializeField] private GameObject bomb;

    void Awake()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
    }

    public override void Init()
    {
        transform.rotation = Quaternion.Euler(Vector3.zero);
        bombTex.SetActive(true);
    }

    private void OnEnable()
    {
        StartCoroutine(Bomb());
    }

    private IEnumerator Bomb()
    {
        rb.AddForce(new Vector3(0, 7, 0), ForceMode.Impulse);
        yield return new WaitForSeconds(1.5f);
        anim.enabled = true;
        yield return new WaitForSeconds(1.5f);
        transform.rotation = Quaternion.Euler(Vector3.zero);
        bombTex.SetActive(false);
        anim.enabled = false;
        Explosion explosion = PoolManager.Instance.Pop("Explosion") as Explosion;
        explosion.transform.position = transform.position;
        yield return new WaitForSeconds(1.5f);
        PoolManager.Instance.Push(this);
    }
}
