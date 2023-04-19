using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorOwner : MonoBehaviour
{
    [SerializeField]
    private PlayerInputInterface _inputInterface;

    private void Awake()
    {
        _inputInterface.OnCursorGrab += GrabCursor;
        _inputInterface.OnCursorRelease += ReleaseCursor;
    }
    private void OnDestroy()
    {
        _inputInterface.OnCursorGrab -= GrabCursor;
        _inputInterface.OnCursorRelease -= ReleaseCursor;
    }
    private void OnApplicationFocus(bool focus)
    {
        if (focus)
        {
            GrabCursor();
        }
        else
        {
            ReleaseCursor();
        }
    }
    private void GrabCursor()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }
    private void ReleaseCursor()
    {
        Cursor.lockState = CursorLockMode.None;
    }
}
