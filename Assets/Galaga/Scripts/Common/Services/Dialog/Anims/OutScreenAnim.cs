using DG.Tweening;
using UnityEngine;


public class OutScreenAnim : UIAnim
{
    [SerializeField] private float duration;
    [SerializeField] private Ease ease;
    [SerializeField] private OutScreenAnimPosType startPos;
    [SerializeField] private OutScreenAnimPosType endPos;
    
    private Vector2 _startPos;
    private Vector2 _endPos;
    
    private Tween _anim;
    public override void Play()
    {
        Item.anchoredPosition = _startPos;
        _anim=Item.DOAnchorPos(_endPos, duration);
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

    private Vector2 GetPos(OutScreenAnimPosType posType)
    {
        return posType switch
        {
            OutScreenAnimPosType.IN => Item.anchoredPosition,
            OutScreenAnimPosType.OUT => Item.anchoredPosition + new Vector2(CanvasRectTransform.rect.width, 0),
        };
    }

    public override bool Init(RectTransform canvasRectTransform)
    {
        var result = base.Init(canvasRectTransform);
        if (result)
        {
            _startPos = GetPos(startPos);
            _endPos = GetPos(endPos);
        }
        return result;
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

public enum OutScreenAnimPosType
{
    IN,
    OUT
}