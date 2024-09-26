using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

[CreateAssetMenu(menuName = "SO/Stat")]
public class AgentStat : ScriptableObject
{
    Stat     Strength;
    Stat     Agility;
    Stat     Damage;
    Stat     MaxHealth;
    Stat     CriticalChance;
    Stat     CriticalDamage;
    Stat     Armor;

    protected Agent _owner;
    protected Dictionary<StatType, Stat> _statDictionary;

    public void SetOwner(Agent owner)
    {
        _owner = owner;
    }

    private void OnEnable()
    {
        _statDictionary = new Dictionary<StatType, Stat>();

        Type t = typeof(AgentStat);

        foreach (StatType type in Enum.GetValues(typeof(StatType)))
        {
            try
            {
                string name = LowerFirstChar(type.ToString());
            FieldInfo statField = t.GetField(name);
                _statDictionary.Add(type, statField.GetValue(this) as Stat); 
            }
            catch (Exception ex)
            {
                Debug.LogError(type.ToString() + "Stat¾øÀ½ " + ex.Message);
            }
        }
    }

    private string LowerFirstChar(string input)
    => $"{char.ToLower(input[0])}{input.Substring(1)}";
}
