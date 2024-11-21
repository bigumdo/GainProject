using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using Random = UnityEngine.Random;
namespace asd
{
    [CreateAssetMenu(menuName = "SO/Stat")]
    public class AgentStat : ScriptableObject
    {
        public Stat strength;
        public Stat agility;
        public Stat damage;
        public Stat maxHealth;
        public Stat criticalChance;
        public Stat criticalDamage;
        public Stat armor;

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

        public int ArmorDamage(int damage)
        {
            return damage - Mathf.FloorToInt(armor.GetValue() * 0.5f);
        }

        public int GetDamage()
        {
            return damage.GetValue() + strength.GetValue() * 2;
        }

        public bool IsCritical(ref int damage)
        {
            if (IsCriticalPersent(criticalChance.GetValue()))
            {
                damage = damage * criticalDamage.GetValue();
                return true;
            }
            else
                return false;
        }

        private bool IsCriticalPersent(int persent)
        {
            int rPersent = Random.Range(0, 101);
            if (rPersent < persent)
                return true;
            else
                return false;
        }
    }
}
