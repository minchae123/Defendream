using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoisonSkill : MonoBehaviour
{
    void Start()
    {
        Destroy(gameObject, 5);
    }

}
