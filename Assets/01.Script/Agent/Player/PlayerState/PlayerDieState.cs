using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerDieState : AgentState
{
    private Player _player;
    public PlayerDieState(Agent agent, AnimParamSO animParam) : base(agent, animParam)
    {
        _player = agent as Player;
    }

    public override void Enter()
    {
        base.Enter();
        _player.isDead = true;
        _player.StopMove();
    }

    public override void Update()
    {
        base.Update();
        if (_isTriggerCall)
        {
            _player.gameObject.SetActive(false);
        }
    }
}
