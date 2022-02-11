using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class BtnScaleTween : MonoBehaviour
{
    public Ease ease;
    public LoopType loopType;
    public RectTransform rectTransform;

    private void Start()
    {
        rectTransform = GetComponent<RectTransform>();

    }
    public void BtnScale()
    {
        rectTransform.DOScale(1.1f, 0.25f).OnComplete(ResetScale);


    }

    public void ResetScale()
    {
        rectTransform.DOScale(1f, 0.1f);
    }
}
