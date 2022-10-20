using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace Player
{
    public class PlayerState
    {
        protected Player Player;
        protected PlayerStateMachine StateMachine;
        protected PlayerData PlayerData;

        protected bool IsAnimationFinished;

        protected float StartTime;
        protected float TimeInCurrentState;
        private string _animationBoolName;

        public PlayerState(Player player, PlayerStateMachine playerStateMachine, PlayerData playerData, string animBoolName)
        {
            Player = player;
            StateMachine = playerStateMachine;
            PlayerData = playerData;
            _animationBoolName = animBoolName;
        }
        public virtual void Enter()
        {
            DoCheck();
            Player.Animator.SetBool(_animationBoolName, true);
            StartTime = Time.time;
            Debug.Log(_animationBoolName);
            IsAnimationFinished = false;
        }
        public virtual void Exit()
        {
            Player.Animator.SetBool(_animationBoolName, false);
        }
        public virtual void LogicUpdate()
        {

        }
        public virtual void PhysicsUpdate()
        {
            DoCheck();
        }
        public virtual void DoCheck()
        {

        }
        public virtual void AnimationTrigger() { }
        public virtual void AnimationFinishTrigger() => IsAnimationFinished = true ;
    }
}