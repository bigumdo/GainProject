
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : AgentMovement
{
    public Player _player;

    private void Awake()
    {
        _player._inputReader.MovementEvent += HandleMoveEvnet;
    }

    private void OnDestroy()
    {
        _player._inputReader.MovementEvent -= HandleMoveEvnet;
    }

    private void HandleMoveEvnet(Vector2 obj)
    {
        _movement = obj.x;
    }

    public override void SetMovement(float movement)
    {
        base.SetMovement(movement);
    }
}
