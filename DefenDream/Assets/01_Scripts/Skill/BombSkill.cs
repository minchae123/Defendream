using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombSkill : MonoBehaviour
{
    private Animator anim;
    private Rigidbody rb;

    [SerializeField] private GameObject bombTex;
    [SerializeField] private GameObject bomb;

    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();

        Invoke(nameof(Shaking), 1.5f);
        rb.AddForce(new Vector3(0,7,0), ForceMode.Impulse);
    }

    void Shaking()
    {
        anim.enabled = true;
        Invoke(nameof(Bomb), 1.5f);
    }

    void Bomb()
    {
        bombTex.SetActive(false);
        Instantiate(bomb, transform);
        Destroy(gameObject, 1f);
    }
}
