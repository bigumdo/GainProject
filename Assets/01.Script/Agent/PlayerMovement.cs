using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : AgentMovement, IPlayerMovement
{

        
    public bool IsOnDash { get; set ; }
    public bool IsDash { get ; set ; } = true;

    [SerializeField] private float _dashCoolTime;

    private float _currentDashCoolTime;

    private void Awake()
    {
        _currentDashCoolTime = _dashCoolTime;
    }


    public override void Movement()
    {
        if(!IsOnDash)
            base.Movement();
    }

    public void Jump(float power)
    {
        StopImmediately();
        _rigid.AddForce(Vector2.up * power, ForceMode2D.Impulse);
    }

    public void Dash(float dashPower)
    {
        //StopImmediately();
        IsDash = false;
        _rigid.AddForce(new Vector2((transform.localScale.x > 0 ? 1 : -1) * dashPower, 0));
        //Debug.Log((transform.localScale.x > 0 ? Vector2.right : Vector2.left));
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
