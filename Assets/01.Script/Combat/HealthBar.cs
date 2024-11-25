using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.Rendering;
using TMPro;

public class HealthBar : MonoBehaviour
{
    [SerializeField] protected Agent _owner;
    [SerializeField] protected Image _healthbarImage;
    private CanvasGroup _canvasGroup;

    private void Awake()
    {
        _canvasGroup = GetComponent<CanvasGroup>();

    }


    protected virtual void Start()
    {
        _owner.HealthCompo.OnHitEvent.AddListener(HandleHitEvent);
        _owner.HealthCompo.OnDeadEvent.AddListener(HandleDieEvent);
    }



    protected virtual void HandleHitEvent()
    {
        float fillAmount = _owner.HealthCompo.GetNormalizeHealth();
        _healthbarImage.fillAmount = fillAmount;
    }

    protected virtual void HandleDieEvent()
    {
        _owner.Die();
        if(!(_owner is Player))
            _canvasGroup.DOFade(0, 1);
    }
}
