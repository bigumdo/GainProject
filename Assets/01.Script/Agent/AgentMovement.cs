using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Serialization;

public class AgentMovement : MonoBehaviour,IMovement


{
    [FormerlySerializedAs("_playerMask")] 
    [SerializeField] protected LayerMask _groundMask;

    protected bool _isGround;
    protected Agent _agent;
    protected float _movement;
    protected Rigidbody2D _rigid;
    public Rigidbody2D Rigid => _rigid;

    public bool IsGorund => _isGround;

    protected Transform _groundCheck;

    public virtual void Initialize(Agent agent)
    {
        _groundCheck = transform.Find("GroundCheck");
        _agent = agent;
        _rigid = GetComponent<Rigidbody2D>();
    }
    

    public virtual void Movement()
    {
        _rigid.velocity = new Vector2(_movement,_rigid.velocity.y);
    }


    public virtual void Knockback(float power)
    {
        
    }

    public void ResetJumpCnt()
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
            {
                //_agent.SpriteRendererCompo.flipX = false;
                //_agent.transform.localScale = Vector3.one;
            }
            else if(movement < 0)
            {
                //_agent.SpriteRendererCompo.flipX = true;
                //_agent.transform.localScale = new Vector3(-1,1,1);
            }
        }
    }

    public virtual void SetMovement(float movement)
    {
        _movement = movement ;
        MoveDirection(movement);
    }
    
    public virtual void Update()
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

    protected virtual void FixedUpdate()
    {
        Movement();
        SetMovement(_movement);

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
