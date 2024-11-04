using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalSickleAttackState : WeaponState<NormalSickleEnum>
{
    private float _listAttackTime;
    private float _comboTime = 2;
    private int _comboCnt;
    private float _currnetTime;
    private int animationHash = Animator.StringToHash("AttackCombo");
    public NormalSickleAttackState(Player owner, Weapon weapon, WeaponStateMachine<NormalSickleEnum> stateMachine, string animaHash) : base(owner, weapon, stateMachine, animaHash)
    {
        _comboCnt = 0;
    }

    public override void Enter()
    {
        base.Enter();
        if( _comboCnt > 1)
        {
            
            _comboCnt = 0;
        }
        _weapon.AnimatorCompo.SetInteger(animationHash, _comboCnt);
        _owner.inputReader.AttackEvent += HandleAttackEvent;
        
    }

    public override void Exit()
    {
        _owner.inputReader.AttackEvent -= HandleAttackEvent;
        base.Exit();
    }

    private void HandleAttackEvent()
    {
        if(_isEndTrigger)
            _stateMachine.ChangeState(NormalSickleEnum.Attack);
    }

    public override void StateUpdate()
    {
        base.StateUpdate();
        _currnetTime += Time.deltaTime;
        if (_currnetTime >= _comboTime)
        {
            _currnetTime = 0;
            _comboCnt = 0;
            _stateMachine.ChangeState(NormalSickleEnum.Idle);
            //_weapon.Owner.Delay(() => _stateMachine.ChangeState(NormalSickleEnum.Idle), _weapon.attackDelay);
        }
    }

    public override void AnimationEndTrigger()
    {
        base.AnimationEndTrigger();
        _owner.Attack();
        _comboCnt++;
        _currnetTime = 0;

    }


}
