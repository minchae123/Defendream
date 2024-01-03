using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnim : MonoBehaviour
{
    Animator _anim;
    // Start is called before the first frame update
    void Start()
    {
        _anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void WalkAnim(bool isWalk)
    {
        _anim.SetBool("walk", isWalk);
    }

    public void DieAnim()
    {
        _anim.SetTrigger("die");
    }
}
