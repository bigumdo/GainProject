using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="SO/FSM/StateListSO")]
public class StateListSO : ScriptableObject
{
    public List<StateSO> stateList;
}
