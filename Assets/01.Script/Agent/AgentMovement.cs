using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgentMovement : MonoBehaviour,IMovement
{

    private bool _isGround;
    private Agent _agent;
    private Vector2 _movement;
    private Rigidbody2D _rigid;

    public bool IsGorund => _isGround;

    public void Initialize(Agent agent)
    {
        _agent = agent;
        _rigid = GetComponent<Rigidbody2D>();
    }

    public void Movement()
    {
        _rigid.velocity = _movement;
    }

    public void Knockback(float power)
    {
        
    }

    public void SetMovement(Vector2 movement)
    {
        _movement = movement;
    }
}
