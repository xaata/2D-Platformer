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
        public PlayerGroundedState(Player player, PlayerStateMachine playerStateMachine, PlayerData playerData, string animBoolName) : base(player, playerStateMachine, playerData, animBoolName)
        {
        }

        public override void DoCheck()
        {
            base.DoCheck();
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

            if (_jumpInput && Player.CheckIfGrounded())
            {
                Player.InputHandler.UseJumpInput();
                StateMachine.ChangeState(Player.JumpState);
            }
        }

        public override void PhysicsUpdate()
        {
            base.PhysicsUpdate();
        } 
    }
}
