using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wolf : Enemy
{
    public WolfPowerChargeBar powerChargeBar;
    public GameObject powerCharge;
    private EnemyCast _enemyCast;
    public WolfMovement WolfMoveCompo { get; private set; }
    //public WolfMovement ;


    protected override void Awake()
    {
        WolfMoveCompo = GetComponent<WolfMovement>();
        base.Awake();
        powerChargeBar.gameObject.SetActive(false);
        _enemyCast = GetComponent<EnemyCast>();
    }

    public bool AttackCast()
    {
        return _enemyCast.CheckRange();
    }

}
