using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Agent : MonoBehaviour
{
    public IMovement MovementCompo { get; private set; }
    public Animator AnimatorCompo { get; private set; }

    protected virtual void Awake()
    {
        Transform visual = transform.Find("Visual");
        AnimatorCompo = visual.GetComponent<Animator>();
        MovementCompo = GetComponent<IMovement>();
        MovementCompo.Initialize(this);
    }
}
