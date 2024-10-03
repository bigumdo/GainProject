using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalSickle : MonoBehaviour
{
    private Agent _owner;
    private Animator _animator;

    //private readonly string

    private void Awake()
    {
        _owner = transform.root.GetComponent<Agent>();
        _animator = GetComponent<Animator>();
    }


}
