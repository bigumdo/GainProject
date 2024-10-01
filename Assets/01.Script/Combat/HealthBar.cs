using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

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
        _owner.HealthCompo.OnDeadEvent.AddListener(HandleDeadEvent);
    }



    private void HandleDeadEvent()
    {
        float fillAmount = _owner.HealthCompo.GetNormalizeHealth();
        _healthbarImage.fillAmount = fillAmount;
    }

    private void HandleHitEvent()
    {
        _canvasGroup.DOFade(0, 1);
    }
}
