using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;

namespace Player {
    public class PlayerAbilityState : PlayerState
    {
        protected bool IsAbilityDone;
        private bool _isGrounded;
        public PlayerAbilityState(Player player, PlayerStateMachine playerStateMachine, PlayerData playerData, string animBoolName) : base(player, playerStateMachine, playerData, animBoolName)
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
            IsAbilityDone = false;
        }

        public override void Exit()
        {
            base.Exit();
        }

        public override void LogicUpdate()
        {
            base.LogicUpdate();
            if (IsAbilityDone)
            {
                if (_isGrounded && Player.CurrentVelocity.y < 0.01f)
                {
                    StateMachine.ChangeState(Player.IdleState);
                }
                else 
                {
                    StateMachine.ChangeState(Player.InAirState);
                }

            }
        }

        public override void PhysicsUpdate()
        {
            base.PhysicsUpdate();
        }
    }
}