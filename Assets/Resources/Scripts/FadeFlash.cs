using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class FadeFlash : MonoBehaviour
{
    public static FadeFlash instance;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    public CanvasGroup canvasGroup;

    public void FadeOut()
    {
        canvasGroup.blocksRaycasts = true;
        canvasGroup.DOFade(1, 0.2f)
        .OnComplete(() => canvasGroup.blocksRaycasts = false);
    }
    public void FadeIn()
    {
        canvasGroup.blocksRaycasts = true;
        canvasGroup.DOFade(0, 0.2f)
        .OnComplete(() => canvasGroup.blocksRaycasts = false);
    }

    public void FadeFlashToIn(TweenCallback action)
    {
        canvasGroup.blocksRaycasts = true;
        canvasGroup.DOFade(1, 0.1f)
        .OnComplete(() => {
            action();
            FadeIn();
        });
    }
}
