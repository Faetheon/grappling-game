using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class TweenInterface
{
    private Tween _tween;

    public static readonly TweenInterface Null = new TweenInterface(null);

    public TweenInterface(Tween tween)
    {
        _tween = tween;
    }
    public bool IsNull()
    {
        return _tween == null;
    }
    public TweenInterface OnComplete(TweenCallback onComplete)
    {
        if (_tween != null)
        {
            _tween.OnComplete(onComplete);
        }
        return this;
    }
}
