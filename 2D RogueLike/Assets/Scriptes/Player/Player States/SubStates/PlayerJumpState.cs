using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player
{
    public class PlayerJumpState : PlayerAbilityState
    {
        public PlayerJumpState(Player player, PlayerStateMachine playerStateMachine, PlayerData playerData, string animBoolName) : base(player, playerStateMachine, playerData, animBoolName)
        {
        }

        public override void Enter()
        {
            base.Enter();
            Player.SetVelocityY(PlayerData.JumpVelocity);
            IsAbilityDone = true;
        }
    }
}
