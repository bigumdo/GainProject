using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum NormalSickleEnum
{
    Idle,
    Attack,
}


public class NormalSickle : Weapon
{
    private bool _isAttack;
    private int _isAttackCombo;
    private float time;

    public WeaponStateMachine<NormalSickleEnum> WeaponStateMachine { get; private set; }

    protected override void Awake()
    {
        base.Awake();
        WeaponStateMachine = new WeaponStateMachine<NormalSickleEnum>();
        foreach (NormalSickleEnum i in Enum.GetValues(typeof(NormalSickleEnum)))
        {
            string typeName = i.ToString();
            Type type = Type.GetType($"NormalSickle{typeName}State");

            try
            {
                WeaponState<NormalSickleEnum> state = Activator.CreateInstance( type,
                    Owner,this, WeaponStateMachine,typeName) as WeaponState<NormalSickleEnum>;
                WeaponStateMachine.AddState(i, state);
            }
            catch(Exception e)
            {
                Debug.LogError(typeName + "¾ø¾î" + e.Message);
                //Debug.LogError(e.Message);
            }

        }
        WeaponStateMachine.Initialize(NormalSickleEnum.Idle,Owner);
    }

    private void FixedUpdate()
    {
        WeaponStateMachine.CurrentState.StateUpdate();
    }

    public override void Attack()
    {
        Owner.Attack();
    }

    public override void AnimationEnd()
    {
        WeaponStateMachine.CurrentState.AnimationEndTrigger();
    }

    public override void AnimationAttack()
    {
        WeaponStateMachine.CurrentState.AnimationAttack();
    }
}
