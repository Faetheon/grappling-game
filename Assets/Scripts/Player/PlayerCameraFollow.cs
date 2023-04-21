using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCameraFollow : MonoBehaviour
{
    [SerializeField]
    private Rigidbody _playerBody;

    private void Update()
    {
        transform.position = _playerBody.position;
    }
}
