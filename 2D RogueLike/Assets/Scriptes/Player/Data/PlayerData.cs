using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "newPlayerData", menuName = "Data/Player Data/Base Data")]
public class PlayerData : ScriptableObject
{
    [Header("Move State")]
    public float MovementVelocity = 10f;
    [Header("Jump State")]
    public float JumpVelocity = 1f;
    [Header("Check Variables")]
    public float GroundCheckRadius = 0.3f;
    public LayerMask GroundLayerMask;
}
