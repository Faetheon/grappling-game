using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterGrapple : MonoBehaviour
{
    [SerializeField]
    private Character _character;
    [SerializeField]
    private Grapple _grapple;

    public event Grapple.GrappleFinishedDelegate OnGrappleFinished = delegate { };

    private void Awake()
    {
        _grapple.Properties = _character.GrappleProperties;
        _grapple.OnGrappleFinished += GrappleFinished;
    }
    private void OnDestroy()
    {
        _grapple.OnGrappleFinished -= GrappleFinished;
    }
    private void GrappleFinished(bool connectedToPoint)
    {
        OnGrappleFinished(connectedToPoint);
    }
    public void Fire()
    {
        _grapple.Fire(_character.GetAimRay());
    }
}
