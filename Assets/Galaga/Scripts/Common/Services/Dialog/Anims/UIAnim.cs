using System;
using Galaga.Common.Utils;
using UnityEngine;


public class UIAnim : MonoBehaviour
{
    [SerializeField] private RectTransform item;
    protected RectTransform Item => item;
    
    protected RectTransform CanvasRectTransform;

    public event Action AnimEndEvent;
    
    private bool _isInited;

    public virtual bool Init(RectTransform canvasRectTransform)
    {
        var isResult = false;
        
        if (!_isInited)
        {
            _isInited = true;
            CanvasRectTransform = canvasRectTransform;
            isResult = true;
        }

        return isResult;
    }
    
    public virtual bool DeInit()
    {
        var isResult = false;
        
        if (_isInited)
        {
            _isInited = false;
            isResult = true;
        }

        return isResult;
    }

    protected void Complete()
    {
        AnimEndEvent.Call();
    }

    public virtual void Play()
    {
        
    }

    public virtual void Stop()
    {
        
    }
}
