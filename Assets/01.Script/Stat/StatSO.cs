using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="SO/Stat/StatSO")]
public class StatSO : ScriptableObject
{

    public delegate void ValueChangeHandler(StatSO stat, float current, float previous);
    public event ValueChangeHandler OnValueChange;    

    public string statName;
    [SerializeField] private float _baseValue, _minValue, _maxValue;
    private Dictionary<string, float> _modifyValueKey = new Dictionary<string, float>();
    private float _modifyValue;

    public float MaxValue
    {
        get => _maxValue;
        set => _maxValue = value;
    }

    public float minValue
    {
        get => _minValue;
        set => _minValue = value;
    }

    public float Value => Mathf.Clamp(_baseValue + _modifyValue, _minValue, _maxValue);

    public bool IsMax => Mathf.Approximately(Value, _maxValue);
    public bool IsMin => Mathf.Approximately(Value, _minValue);

    public float BaseValue
    {
        get => _baseValue;

        set
        {
            float prevValue = Value;
            _baseValue = Mathf.Clamp(value, _minValue, _maxValue);
            TryInvokeValueChangedEvent(Value, prevValue);
        }
    }

    public void AddModifier(string key, float value)
    {
        //ContainsKey Key가 존재하는지
        if (_modifyValueKey.ContainsKey(key)) return;
        float prevValue = Value;
        _modifyValue += value;
        _modifyValueKey.Add(key, value);
        TryInvokeValueChangedEvent(Value, prevValue);
    }

    public void RemoveModifier(string key)
    {
        if (_modifyValueKey.TryGetValue(key, out float value))
        {
            float prevValue = Value;
            _modifyValue -= value;
            _modifyValueKey.Remove(key);
            TryInvokeValueChangedEvent(Value, prevValue);
        }
    }

    private void TryInvokeValueChangedEvent(float value, float prevValue)
    {
        if (Mathf.Approximately(prevValue, value) == false)
            OnValueChange?.Invoke(this, value, prevValue);
    }

    public StatSO Clone()
    {
        return Instantiate(this);
    }
}
