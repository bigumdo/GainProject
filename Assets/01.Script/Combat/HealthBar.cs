using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.Rendering;

public class HealthBar : MonoBehaviour
{
    private Agent _owner;
    [SerializeField] private Image _healthbarImage;
    private CanvasGroup _canvasGroup;

    private void Awake()
    {
        _canvasGroup = GetComponent<CanvasGroup>();
        _owner = transform.root.GetComponent<Agent>();

    }


    private void Start()
    {
        _owner.HealthCompo.OnHitEvent.AddListener(HandleHitEvent);
        _owner.HealthCompo.OnDeadEvent.AddListener(HandleDieEvent);
    }



    private void HandleHitEvent()
    {
        float fillAmount = _owner.HealthCompo.GetNormalizeHealth();
        _healthbarImage.fillAmount = fillAmount;
    }

    private void HandleDieEvent()
    {
        _owner.Die();
        _canvasGroup.DOFade(0, 1);
    }
}
