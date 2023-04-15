using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private PlayerInputInterface _inputInterface;
    [SerializeField]
    private CharacterInput _characterInput;

    private void Awake()
    {
        _inputInterface.OnStrafe += InputInterface_OnStrafe;
    }
    private void OnDestroy()
    {
        _inputInterface.OnStrafe -= InputInterface_OnStrafe;
    }
    private void InputInterface_OnStrafe(Vector2 obj)
    {
        _characterInput.SetStrafe(obj);
    }
}
