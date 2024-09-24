using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Serialization;

public class AgentMovement : MonoBehaviour,IMovement
{
    [FormerlySerializedAs("_playerMask")] [SerializeField]
    private LayerMask _groundMask;
    
    private bool _isGround;
    private Agent _agent;
    protected float _movement;
    private Rigidbody2D _rigid;
    public Rigidbody2D Rigid => _rigid;

    public bool IsGorund => _isGround;

    public void Initialize(Agent agent)
    {
        _agent = agent;
        _rigid = GetComponent<Rigidbody2D>();
    }
    

    public void Movement()
    {
        _rigid.velocity = new Vector2(_movement,_rigid.velocity.y);
    }

    public void Jump(float power)
    {
        StopImmediately();
        _rigid.AddForce(Vector2.up * power, ForceMode2D.Impulse);
    }

    public void Knockback(float power)
    {
        
    }

    public void StopImmediately()
    {
        _rigid.velocity = Vector2.zero;
    }

    public void MoveDirection(float movement)
    {
        if (movement != 0)
        {
            if(movement > 0)
                _agent.SpriteRendererCompo.flipX = false;
            else if(movement < 0)
            {
                _agent.SpriteRendererCompo.flipX = true;
            }
        }
    }

    public virtual void SetMovement(float movement)
    {
        _movement = movement ;
    }
    
    public void Update()
    {
        if(Physics2D.Raycast(transform.position, Vector2.down,1,_groundMask))
        {
            _isGround = true;
        }
        else
        {
             _isGround = false;
        }
    }

    private void FixedUpdate()
    {
        Movement();
        MoveDirection(_movement);

    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawRay(transform.position,Vector2.down * 1);
    }
}
