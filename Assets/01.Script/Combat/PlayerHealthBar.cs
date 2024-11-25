using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthBar : HealthBar
{
    [SerializeField] private TextMeshProUGUI _hpText;
    [SerializeField] private GameObject _gameOverPanel;

    protected override void HandleHitEvent()
    {
        base.HandleHitEvent();
        _hpText.text = $"{_owner.HealthCompo.CurrentHealth}/{_owner.Stat.maxHealth.GetValue()}";

    }

    protected override void Start()
    {
        base.Start();
        _hpText.text = $"{_owner.HealthCompo.CurrentHealth}/{_owner.Stat.maxHealth.GetValue()}";

    }

    protected override void HandleDieEvent()
    {
        base.HandleDieEvent();
        _gameOverPanel.SetActive(true);
    }
}
