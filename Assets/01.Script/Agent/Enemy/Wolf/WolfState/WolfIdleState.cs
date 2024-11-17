using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WolfIdleState : AgentState
{
    private Wolf _wolf;
    public WolfIdleState(Agent agent, AnimParamSO animParam) : base(agent, animParam)
    {
        _wolf = agent as Wolf;
    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void Exit()
    {

        base.Exit();
    }

    public override void Update()
    {
        base.Update();
        if(_wolf.AttackCast())
        {
            _wolf.powerChargeBar.gameObject.SetActive(true);

            if (_wolf.powerChargeBar.PowerCharge())
            {
                _wolf.stateMachine.ChangeState(FSMState.Attack);

            }
        }
        else
            _wolf.powerChargeBar.gameObject.SetActive(false);


    }
}
