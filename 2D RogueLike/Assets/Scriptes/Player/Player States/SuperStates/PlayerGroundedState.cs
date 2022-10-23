using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static System.Net.WebRequestMethods;

namespace Player
{
    public class PlayerGroundedState : PlayerState
    {
        protected int XInput;
        private bool _jumpInput;
        private bool _isGrounded;
        public PlayerGroundedState(Player player, PlayerStateMachine playerStateMachine, PlayerData playerData, string animBoolName) : base(player, playerStateMachine, playerData, animBoolName)
        {
        }

        public override void DoCheck()
        {
            base.DoCheck();
            Player.JumpState.ResetAmountOfJumpsLeft(); 
            _isGrounded = Player.CheckIfGrounded();
        }

        public override void Enter()
        {
            base.Enter();
        }

        public override void Exit()
        {
            base.Exit();
        }

        public override void LogicUpdate()
        {
            base.LogicUpdate();
            XInput = Player.InputHandler.NormInputX;
            _jumpInput = Player.InputHandler.JumpInput;

            if (_jumpInput && Player.JumpState.CanJump())
            {
                Player.InputHandler.UseJumpInput();
                StateMachine.ChangeState(Player.JumpState);

            }
            else if (!_isGrounded)
            {
                Player.InAirState.StartCoyoteTime();
                StateMachine.ChangeState(Player.InAirState);
            }
        }

        public override void PhysicsUpdate()
        {
            base.PhysicsUpdate();
        } 
    }
}
