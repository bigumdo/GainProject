using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalSickle : MonoBehaviour, IWeapon
{
    private Player _owner;
    private Animator _animator;
    private SpriteRenderer _spriteRenderer;

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
    }

    private void OnEnable()
    {
        _owner.inputReader.MouseAttackEvent += HandleAttackEvent;
        _owner.inputReader.MouseSpecialEvent += HandleSpecialEvent;
    }

    private void OnDisable()
    {
        _owner.inputReader.MouseAttackEvent -= HandleAttackEvent;
        _owner.inputReader.MouseSpecialEvent -= HandleSpecialEvent;
    }

    private void HandleSpecialEvent()
    {
        _animator.SetBool(_idle, true);
    }

    private void Update()
    {
        if (_isAttack)
        {
            time += Time.deltaTime;
            if (time >= 0.8f)
            {
                _isAttack = false;
                _animator.SetBool(_idle, true);
                _animator.SetBool(_attack, _isAttack);
                _isAttackCombo = 0;
                time = 0;
            }
        }


    }

    private void AttackEndTrigger()
    {
        _isAttackCombo++;
    }

    public void HandleAttackEvent()
    {
        if (_isAttackCombo > 1)
            _isAttackCombo = 0;
        time = 0;
        _isAttack = true;
        _animator.SetBool(_idle, false);
        _animator.SetBool(_attack, _isAttack);
        _animator.SetInteger(_attackCombo, _isAttackCombo);
    }

    public void Attack()
    {
        _owner.Attack();
    }
}
