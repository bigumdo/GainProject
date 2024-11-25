using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using Unity.VisualScripting;

public class GameOverPanel : MonoBehaviour
{
    private CanvasGroup _canvasGroup;

    private void Awake()
    {
        _canvasGroup = GetComponent<CanvasGroup>();
    }

    //private void OnEnable()
    //{   
    //    int alpha = 0;
    //    DOTween.To(() => alpha, x => alpha = x, 1, 1);
    //    _canvasGroup.alpha = alpha;
    //}

    private void Update()
    {
        //if (_canvasGroup.alpha >=1)
        //{
        //    _canvasGroup.blocksRaycasts = true;
        //}
    }

    //private void OnDisable()
    //{
    //    _canvasGroup.alpha = 1;
    //    _canvasGroup.blocksRaycasts = false;
    //}

}
