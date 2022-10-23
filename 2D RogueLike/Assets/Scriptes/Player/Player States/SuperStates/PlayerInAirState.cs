using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player {
    public class PlayerInAirState : PlayerState
    {
        private bool _isGrounded;
        private int _xInput;
        private bool _jumpInput;
        private bool _jumpInputStop;
        private bool _coyoteTime;
        private bool _isJumpimg;
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
            CheckCoyoteTime();
            _jumpInput = Player.InputHandler.JumpInput;
            _xInput = Player.InputHandler.NormInputX;
            _jumpInputStop = Player.InputHandler.JumpInputStop;
            CheckJumpMultipier();
            if (_isGrounded && Player.CurrentVelocity.y < 0.01f)
            {
                StateMachine.ChangeState(Player.LandState);
            }
            else if(_jumpInput && Player.JumpState.CanJump())
            {
                StateMachine.ChangeState(Player.JumpState);
            }
            else
            {
                Player.CheckIfShouldFlip(_xInput);
                Player.SetVelocityX(PlayerData.MovementVelocity * _xInput);
                Player.Animator.SetFloat("yVelocity", Player.CurrentVelocity.y);
                Player.Animator.SetFloat("xVelocity", Mathf.Abs(Player.CurrentVelocity.x));
            }
        }

        private void CheckJumpMultipier()
        {
            if (_isJumpimg)
            {
                if (_jumpInputStop)
                {
                    Player.SetVelocityY(Player.CurrentVelocity.y * PlayerData.VariableJumpHeightMultiplier);
                    _isJumpimg = false;
                }
                else if (Player.CurrentVelocity.y <= 0f)
                {
                    _isJumpimg = false;
                }
            }
        }

        public override void PhysicsUpdate()
        {
            base.PhysicsUpdate();
        }
        private void CheckCoyoteTime()
        {
            if (_coyoteTime && Time.time > StartTime + PlayerData.CoyoteTime)
            {
                _coyoteTime = false;
                Player.JumpState.DecreaseAmountOfJumpsLeft();
            }
        }
        public void StartCoyoteTime() => _coyoteTime = true;
        public void SetIsJumping() => _isJumpimg = true;
    }
}