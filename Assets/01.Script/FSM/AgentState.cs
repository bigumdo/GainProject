using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.EventSystems.EventTrigger;

public abstract class AgentState
{
    protected Agent _agent;

    protected AnimParamSO _animParam;
    protected AgentRenderer _renderer;
    protected bool _isTriggerCall;

    public AgentState(Agent agent, AnimParamSO animParam)
    {
        _agent = agent;
        _animParam = animParam;
    }

    public virtual void Enter()
    {
        _renderer.SetParam(_animParam, true);
        _isTriggerCall = false;
    }

    public virtual void Update() { }

    public virtual void Exit()
    {
        _renderer.SetParam(_animParam, false);
    }

    public virtual void AnimationEndTrigger()
    {
        _isTriggerCall = true;
    }
}
