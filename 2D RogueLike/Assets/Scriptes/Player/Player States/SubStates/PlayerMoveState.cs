using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
namespace Player
{
    public class PlayerMoveState : PlayerGroundedState
    {
        public PlayerMoveState(Player player, PlayerStateMachine playerStateMachine, PlayerData playerData, string animBoolName) : base(player, playerStateMachine, playerData, animBoolName)
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
            Player.CheckIfShouldFlip(XInput);
            Player.SetVelocityX(PlayerData.MovementVelocity * XInput);
            if (XInput == 0f)
            {              
                StateMachine.ChangeState(Player.IdleState);
            }
        }

        public override void PhysicsUpdate()
        {
            base.PhysicsUpdate();
        }
    }
}