using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum NormalSickleEnum
{
    Idle,
    Up,
    Attack,
    Special
}


public class NormalSickle : Weapon, IWeapon
{

    //private readonly int _attack = Animator.StringToHash("Attack");
    //private readonly int _idle = Animator.StringToHash("Idle");
    //private readonly int _attackCombo = Animator.StringToHash("AttackCombo");

    private bool _isAttack;
    private int _isAttackCombo;
    private float time;

    public WeaponStateMachine<NormalSickleEnum> WeaponStateMachine { get; private set; }

    private void Awake()
    {
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
                Debug.LogError(typeName + "¾ø¾î");
                Debug.LogError(e.Message);
            }

        }
        WeaponStateMachine.Initialize(NormalSickleEnum.Idle,Owner);

    }

    //private void OnEnable()
    //{
    //    Owner.inputReader.MouseAttackEvent += HandleAttackEvent;
    //    Owner.inputReader.MouseSpecialEvent += HandleSpecialEvent;
    //}

    //private void OnDisable()
    //{
    //    Owner.inputReader.MouseAttackEvent -= HandleAttackEvent;
    //    Owner.inputReader.MouseSpecialEvent -= HandleSpecialEvent;
    //}

    //private void HandleSpecialEvent()
    //{
    //    Animator.SetBool(_idle, true);
    //}

    //private void Update()
    //{
    //    if (_isAttack)
    //    {
    //        time += Time.deltaTime;
    //        if (time >= 0.8f)
    //        {
    //            _isAttack = false;
    //            Animator.SetBool(_idle, true);
    //            Animator.SetBool(_attack, _isAttack);
    //            _isAttackCombo = 0;
    //            time = 0;
    //        }
    //    }


    //}

    private void AttackEndTrigger()
    {
        _isAttackCombo++;
    }

    //public void HandleAttackEvent()
    //{
    //    if (_isAttackCombo > 1)
    //        _isAttackCombo = 0;
    //    time = 0;
    //    _isAttack = true;
    //    Animator.SetBool(_idle, false);
    //    Animator.SetBool(_attack, _isAttack);
    //    Animator.SetInteger(_attackCombo, _isAttackCombo);
    //}

    public void Attack()
    {
        Owner.Attack();
    }
}
