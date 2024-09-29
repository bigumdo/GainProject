using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Agent : MonoBehaviour
{
    [field: SerializeField] public AgentStat Stat { get; protected set; }
    
    public IMovement MovementCompo { get; private set; }
    public Animator AnimatorCompo { get; private set; }
    public SpriteRenderer SpriteRendererCompo { get; private set; }
    public bool isDead;
    

    protected virtual void Awake()
    {
        Transform visual = transform.Find("Visual");
        AnimatorCompo = visual.GetComponent<Animator>();
        SpriteRendererCompo = visual.GetComponent<SpriteRenderer>();
        MovementCompo = GetComponent<IMovement>();
        MovementCompo.Initialize(this);
        
        Stat = Instantiate(Stat);
        Stat.SetOwner(this);
    }
}
