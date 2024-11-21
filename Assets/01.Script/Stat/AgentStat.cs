
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace stat
{
    public class AgentStat : MonoBehaviour
    {
        [SerializeField] private StatOverride[] _statOverrides;
        private StatSO[] _stats;

        public Agent Owner { get; private set; }
        
        public void Initialize(Agent agnet)
        {
            Owner = agnet;

            _stats = _statOverrides.Select(x => x.CreateStat()).ToArray();
        }

        public StatSO GetStat(StatSO stat)
        {
            return _stats.FirstOrDefault(x => x.statName == stat.statName);
        }

        public void SetBaseValue(StatSO stat, float value)
            => GetStat(stat).BaseValue = value;

        public float GetBaseValue(StatSO stat)
            => GetStat(stat).BaseValue;

        public void IncreaseBaseValue(StatSO stat, float value)
            => GetStat(stat).BaseValue += value;

        public void AddModifier(StatSO stat, string key, float value)
            => GetStat(stat).AddModifier(key, value);
        public void RemoveModifier(StatSO stat, string key)
            => GetStat(stat).RemoveModifier(key);

    }
}
