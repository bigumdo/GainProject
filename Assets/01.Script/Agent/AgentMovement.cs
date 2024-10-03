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

    private Transform _groundCheck;

    public void Initialize(Agent agent)
    {
        _groundCheck = transform.Find("GroundCheck");
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
                _agent.transform.localScale = Vector3.one;
            else if(movement < 0)
            {
                _agent.transform.localScale = new Vector3(-1,1,1);
            }
        }
    }

    public virtual void SetMovement(float movement)
    {
        _movement = movement ;
    }
    
    public void Update()
    {
        if(Physics2D.Raycast(_groundCheck.position, Vector2.down,0.2f,_groundMask))
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
        if(_groundCheck != null)
        {
            Gizmos.color = Color.green;
            Gizmos.DrawRay(_groundCheck.position, Vector2.down * 0.2f);
        }
    }
}
