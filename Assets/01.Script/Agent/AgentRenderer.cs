using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgentRenderer : MonoBehaviour
{

    private Animator _animator;

    protected virtual void Awake()
    {
        _animator = transform.GetComponentInChildren<Animator>();
    }

    public void SetParam(AnimParamSO param, bool value) => _animator.SetBool(param.hashValue, value);
    public void SetParam(AnimParamSO param, float value) => _animator.SetFloat(param.hashValue, value);
    public void SetParam(AnimParamSO param, int value) => _animator.SetInteger(param.hashValue, value);
    public void SetParam(AnimParamSO param) => _animator.SetTrigger(param.hashValue);

    private void Update()
    {
        
    }
}
