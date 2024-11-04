using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Player : Agent
{
    [Header("Setting")]
    public float moveSpeed;
    public float jumpPower;
    public float dashPower;
    public float gravity;
    public float dashTime;
    public float jumpCnt;

    private float _currentJumpCnt;
    public bool CanJump => _currentJumpCnt > 0;

    public InputReader inputReader;
    public IPlayerMovement PlayerMovementCompo { get; private set; }
    //[HideInInspector]public Weapon currentWeapon;
    
 
    public PlayerStateMachine StateMachine { get; protected set; }


    protected override void Awake()
    {
        _currentJumpCnt = jumpCnt;
        base.Awake();
        StateMachine = new PlayerStateMachine();
        PlayerMovementCompo = GetComponent<IPlayerMovement>();
        foreach (PlayerStateEnum stateEnum in Enum.GetValues(typeof(PlayerStateEnum)))
        {
            string typeName = stateEnum.ToString();

            try
            {
                Type t = Type.GetType($"Player{typeName}State");
                PlayerState state = Activator.CreateInstance(
                    t, this, StateMachine, typeName) as PlayerState;
                StateMachine.AddState(stateEnum, state);
                
            }catch(Exception ex)
            {
                Debug.LogError($"{typeName} is loading error! check Message");
                Debug.LogError(ex.Message);
            }
        }
        StateMachine.Initialize(PlayerStateEnum.Idle,this);
        //SetWeaon();
    }

    public void ResetJumpCnt()
    {
        _currentJumpCnt = jumpCnt;
    }

    public void DecreaseJumpCount()
    {
        _currentJumpCnt--;
    }

    public void Update()
    {
        StateMachine.CurrentState.UpdateState();
    }

    public override void Attack()
    {
        DamageCasterCompo.DamageCast();
    }

    public void Delay(Action action, float delay)
    {
        StartCoroutine(DelayCoroutine(action, delay));
    }

    private IEnumerator DelayCoroutine(Action action, float delay)
    {
        yield return new WaitForSeconds(delay);
        action?.Invoke();
    }


}
