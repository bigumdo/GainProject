using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerHealthBar : HealthBar
{
    [SerializeField] private TextMeshProUGUI _hpText;

    protected override void HandleHitEvent()
    {
        base.HandleHitEvent();
        _hpText.text = $"{_owner.Stat.maxHealth.GetValue()}/{_owner.HealthCompo.CurrentHealth}";

    }

    protected override void Start()
    {
        base.Start();
        _hpText.text = $"{_owner.Stat.maxHealth.GetValue()}/{_owner.HealthCompo.CurrentHealth}";

    }
}
