using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="SO/FSM/ParamSO")]
public class AnimParamSO : ScriptableObject
{
    public enum ParamType

    {
        Boolean, Float, Integer, Trigger
    }

    public string paramName;
    public ParamType paramType;
    public int hashValue;

    //�ν����� ������ ���
    private void OnValidate()
    {
        hashValue = Animator.StringToHash(paramName);
    }
}
