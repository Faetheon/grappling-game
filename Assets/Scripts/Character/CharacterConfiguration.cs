using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Grapple Game/Character Configuration")]
public class CharacterConfiguration : ScriptableObject
{
    [SerializeField]
    private RigidbodyMovement _walkingMovement = new RigidbodyMovement(20, 10);

    public void ApplyWalk(Rigidbody rigidbody, Vector3 direction)
    {
        _walkingMovement.Apply(rigidbody, direction);
    }
}
