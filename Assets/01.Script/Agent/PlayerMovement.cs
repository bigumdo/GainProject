using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : AgentMovement, IPlayerMovement
{

        
    public bool IsOnDash { get; set ; }
    public bool IsDash { get ; set ; } = true;

    [SerializeField] private float _dashCoolTime;

    private float _currentDashCoolTime;
    private Player _player;

    private void Awake()
    {
        _currentDashCoolTime = _dashCoolTime;
        _player = _agent as Player;
    }


    public override void Movement()
    {
        if(!IsOnDash && _player.OnMove)
            base.Movement();
    }

    public void Jump(float power)
    {
        StopImmediately();
        _rigid.AddForce(Vector2.up * power, ForceMode2D.Impulse);
    }

    public void Dash(float dashPower)
    {
        StopImmediately();
        IsDash = false;
        Vector2 dir = GameManager.Instance.MouseDir;
        Rigid.gravityScale = 0;
        _rigid.velocity = dir * dashPower;
    }

    public override void Update()
    {
        base.Update();
        if (!IsDash && _currentDashCoolTime > 0)
        {
            _currentDashCoolTime -= Time.deltaTime;
        }
        else if(_currentDashCoolTime <= 0)
        {
            IsDash = true;
            _currentDashCoolTime = _dashCoolTime;
        }

    }
}
