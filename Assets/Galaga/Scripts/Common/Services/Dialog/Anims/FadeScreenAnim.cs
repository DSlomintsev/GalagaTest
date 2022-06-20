using DG.Tweening;
using UnityEngine;


public class FadeScreenAnim : UIAnim
{
    [SerializeField] private CanvasGroup canvasGroup;
    [SerializeField] private Ease ease;
    [SerializeField] private float duration;
    [SerializeField] private float startValue;
    [SerializeField] private float endValue;

    private Tween _anim;
    public override void Play()
    {
        canvasGroup.alpha = startValue;
        _anim=canvasGroup.DOFade(endValue, duration);
        _anim.SetEase(ease);
        _anim.onComplete += OnComplete;
        _anim.Play();
    }
    
    public override void Stop()
    {
        if (_anim != null)
        {
            _anim.onComplete -= OnComplete;
            _anim.Kill();
        }
    }

    public override bool DeInit()
    {
        var result = base.DeInit();
        if (result)
        {
            
        }
        return result;
    }
    
    private void OnComplete()
    {
        _anim.onComplete -= OnComplete;
        Complete();
    }
}