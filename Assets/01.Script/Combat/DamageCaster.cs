using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public abstract class DamageCaster : MonoBehaviour
{
    public LayerMask targetLayer;
    protected Agent _owner;

    public UnityEvent OnDamageCastEvent;

    public virtual void  InitCaster(Agent agent)
    {
        _owner = agent;
    }

    public abstract bool DamageCast();


}
