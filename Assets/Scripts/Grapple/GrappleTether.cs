using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class GrappleTether : MonoBehaviour
{
    [SerializeField]
    private Grapple _grapple;
    [SerializeField]
    private LineRenderer _line;

    private Vector3[] _linePositions = new Vector3[2];
    private bool _isTweening = false;

    public event System.Action OnExtended = delegate { };
    public event System.Action OnRetracted = delegate { };

    private void Awake()
    {
        _line.SetPositions(_linePositions);
    }
    public void ExtendToPoint(Vector3 point)
    {
        MoveLineRendererToPoint(transform.position, point).OnComplete(ExtendComplete);
    }
    public void Retract()
    {
        MoveLineRendererToPoint(_linePositions[1], transform.position).OnComplete(RetractComplete);
    }
    private TweenInterface MoveLineRendererToPoint(Vector3 start, Vector3 end)
    {
        if (!_isTweening)
        {
            float percentOfMaxLength = ComputePercentOfMaxLength(start, end);
            float tweenTime = Mathf.Lerp(0, _grapple.ExtendDuration, percentOfMaxLength);
            Tween tween = DOTween.To(GetTetherEndPosition, SetTetherEndPosition, end, tweenTime);
            
            _isTweening = true;
            _line.enabled = true;

            return new TweenInterface(tween);
        }
        else
        {
            return TweenInterface.Null;
        }
    }
    private void ExtendComplete()
    {
        _isTweening = false;
        OnExtended();
    }
    private void RetractComplete()
    {
        _isTweening = false;
        _line.enabled = false;
        OnRetracted();
    }
    private float ComputePercentOfMaxLength(Vector3 start, Vector3 end)
    {
        float distance = Vector3.Distance(start, end);
        return Mathf.InverseLerp(0, _grapple.MaxDistance, distance);
    }
    private Vector3 GetTetherEndPosition()
    {
        return _linePositions[1];
    }
    private void SetTetherEndPosition(Vector3 position)
    {
        _linePositions[0] = transform.position;
        _linePositions[1] = position;
        _line.SetPositions(_linePositions);
    }
}
