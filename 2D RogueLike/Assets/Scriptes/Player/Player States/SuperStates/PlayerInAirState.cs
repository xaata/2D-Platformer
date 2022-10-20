using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player {
    public class PlayerInAirState : PlayerState
    {
        private bool _isGrounded;
        private int _xInput;
        public PlayerInAirState(Player player, PlayerStateMachine playerStateMachine, PlayerData playerData, string animBoolName) : base(player, playerStateMachine, playerData, animBoolName)
        {
        }

        public override void DoCheck()
        {
            base.DoCheck();
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
            _xInput = Player.InputHandler.NormInputX;
            if (_isGrounded && Player.CurrentVelocity.y < 0.01f)
            {
                StateMachine.ChangeState(Player.LandState);
            }
            else
            {
                Player.CheckIfShouldFlip(_xInput);
                Player.SetVelocityX(PlayerData.MovementVelocity * _xInput);
                Player.Animator.SetFloat("yVelocity", Player.CurrentVelocity.y);
                Player.Animator.SetFloat("xVelocity", Mathf.Abs(Player.CurrentVelocity.x));
            }
        }

        public override void PhysicsUpdate()
        {
            base.PhysicsUpdate();
        }
    }
}