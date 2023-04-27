using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grapple : MonoBehaviour
{
    [SerializeField]
    private GrappleProperties _properties;

    public GrappleProperties Properties
    {
        get => _properties;
        set => _properties = value;
    }

    public void Fire(Vector3 origin, Vector3 direction)
    {

    }
}
