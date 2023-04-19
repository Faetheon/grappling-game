using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Grapple Game/Character Configuration")]
public class CharacterConfiguration : ScriptableObject
{
    [SerializeField]
    private RigidbodyMovement _walkingMovement = new RigidbodyMovement(20, 10, 2);

    public void Walk(Rigidbody rigidbody, Vector3 direction)
    {
        _walkingMovement.Move(rigidbody, direction);
    }
}
