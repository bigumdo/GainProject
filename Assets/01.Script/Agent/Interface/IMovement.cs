using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IMovement
{
    public void SetMovement(float movement);
    public bool IsGorund { get; }
    public void Initialize(Agent agent);
    public void Knockback(float power);
    public void StopImmediately();
    public void MoveDirection(float movement);
    public void Jump(float power);
    public Rigidbody2D Rigid {  get; }
}
