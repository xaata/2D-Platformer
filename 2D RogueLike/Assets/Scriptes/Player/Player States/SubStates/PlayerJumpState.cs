using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player
{
    public class PlayerJumpState : PlayerAbilityState
    {
        private int _amountOfJumpsLeft;
        public PlayerJumpState(Player player, PlayerStateMachine playerStateMachine, PlayerData playerData, string animBoolName) : base(player, playerStateMachine, playerData, animBoolName)
        {
            _amountOfJumpsLeft = playerData.AmountOfJumps;
        }

        public override void Enter()
        {
            base.Enter();
            Player.SetVelocityY(PlayerData.JumpVelocity);
            IsAbilityDone = true;
            DecreaseAmountOfJumpsLeft();
            Player.InAirState.SetIsJumping();
        }
        public bool CanJump()
        {
            if (_amountOfJumpsLeft > 0)           
                return true;          
            else return false;
        }
        public void ResetAmountOfJumpsLeft() => _amountOfJumpsLeft = PlayerData.AmountOfJumps;
        public void DecreaseAmountOfJumpsLeft() => _amountOfJumpsLeft--;
    }
}
