using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


public class Enemy : Agent
{
    [Header("Setting")]
    public float damage;
    public float moveSpeed;
    public float hp;



    protected override void Awake()
    {
        base.Awake();

        foreach(EnemyStateEnum enemyType in Enum.GetValues( typeof(EnemyStateEnum)))
        {
            string typeName = enemyType.ToString();
            try
            {
                Type t = Type.GetType($"Enemy{typeName}State");
                Enemy


            }
            catch(Exception ex)
            {
                Debug.LogError($"{typeName} is loading error! check Message");
                Debug.LogError(ex.Message);
            }
        }    
    }

}
