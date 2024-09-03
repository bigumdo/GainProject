using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IMovement
{
    public void SetMovement(Vector2 movement);
    public bool IsGorund { get; }
    public void Initialize(Agent agent);
    public void Knockback(float power);
}
