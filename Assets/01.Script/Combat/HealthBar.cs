using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.Rendering;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Agent _owner;
    [SerializeField] private Image _healthbarImage;
    private CanvasGroup _canvasGroup;

    private void Awake()
    {
        _canvasGroup = GetComponent<CanvasGroup>();

    }


    private void Start()
    {
        _owner.HealthCompo.OnHitEvent.AddListener(HandleHitEvent);
        _owner.HealthCompo.OnDeadEvent.AddListener(HandleDieEvent);
    }



    private void HandleHitEvent()
    {
        Debug.Log(1);
        float fillAmount = _owner.HealthCompo.GetNormalizeHealth();
        _healthbarImage.fillAmount = fillAmount;
    }

    private void HandleDieEvent()
    {
        _owner.Die();
        if(!(_owner is Player))
            _canvasGroup.DOFade(0, 1);
    }
}
