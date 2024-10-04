using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalSickle : MonoBehaviour
{
    private Player _owner;
    private Animator _animator;

    private readonly int _attack = Animator.StringToHash("Attack");
    private readonly int _idle = Animator.StringToHash("Idle");
    private readonly int _attackCombo = Animator.StringToHash("AttackCombo");

    private bool _isAttack;
    private int _isAttackCombo;
    private float time;

    private void Awake()
    {
        _owner = transform.root.GetComponent<Player>();
        _animator = GetComponent<Animator>();
        _owner.inputReader.MouseAttackEvent += HandleAttack;
    }

    private void OnDestroy()
    {
        _owner.inputReader.MouseAttackEvent -= HandleAttack;
    }

    private void Update()
    {
        //if (!_isAttack)
        //{
        //    time += Time.deltaTime;
        //    if (time >= 3)
        //    {
        //        _animator.SetBool(_idle, true);
        //        time = 0;
        //    }
        //}


    }

    private void HandleAttack()
    {
        time = 0;
        _isAttack = true;
        _animator.SetBool(_idle, false);
        _animator.SetBool(_attack, _isAttack);
        _animator.SetInteger(_attackCombo, _isAttackCombo);
    }

    private void AttackEndTrigger()
    {
        _isAttackCombo++;
        //_isAttack = false;
        //_animator.SetBool(_idle, true);
    }

}
