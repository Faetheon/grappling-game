using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Grapple Game/Player Configuration")]
public class PlayerConfiguration : ScriptableObject
{
    [SerializeField]
    private float _aimSensitivity = 0.1f;
    [SerializeField]
    private bool _invertAimY = false;

    public float AimSensitivity => _aimSensitivity;
    public float AimYInversionSign => _invertAimY ? 1f : -1f;
}
