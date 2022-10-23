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
    public int AmountOfJumps = 2;
    [Header("In Air State")]
    public float CoyoteTime = 0.2f;
    public float VariableJumpHeightMultiplier = 0.5f;
    [Header("Check Variables")]
    public float GroundCheckRadius = 0.3f;
    public LayerMask GroundLayerMask;
}
