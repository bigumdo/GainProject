using asd;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Agent : MonoBehaviour
{
    [field: SerializeField] public AgentStat Stat { get; protected set; }
    
    public IMovement MovementCompo { get; protected set; }
    public Animator AnimatorCompo { get; protected set; }
    public SpriteRenderer SpriteRendererCompo { get; protected set; }
    public Health HealthCompo { get; protected set; }
    public DamageCaster DamageCasterCompo  { get; protected set; }
    public Collider2D Collider { get; private set; }

    [HideInInspector]public bool isDead;
    public StateMachine stateMachine;


    protected virtual void Awake()
    {
        Transform visual = transform.Find("Visual");
        AnimatorCompo = visual.GetComponent<Animator>();
        SpriteRendererCompo = visual.GetComponent<SpriteRenderer>();
        Collider = GetComponent<Collider2D>();

        DamageCasterCompo = transform.GetComponentInChildren<DamageCaster>();
        if(DamageCasterCompo != null)
            DamageCasterCompo.InitCaster(this);

        MovementCompo = GetComponent<IMovement>();
        MovementCompo.Initialize(this);
        if(Stat != null)
        {
            Stat = Instantiate(Stat);
            Stat.SetOwner(this);
        }

        HealthCompo = GetComponent<Health>();
        HealthCompo.Initialize(this);
    } 

    public virtual void Attack()
    {

    }

    public virtual void Die()
    {
        
    }
}
