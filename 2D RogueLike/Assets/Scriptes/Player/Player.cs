using System.Collections;
using System.Collections.Generic;
using UnityEditor.UI;
using UnityEngine;

namespace Player
{
    public class Player : MonoBehaviour
    {

        [SerializeField] private Transform _groundCheck;

        public PlayerStateMachine StateMachine { get; private set; }
        public PlayerIdleState IdleState { get; private set; }
        public PlayerMoveState MoveState { get; private set; }
        public PlayerJumpState JumpState { get; private set; }
        public PlayerInAirState InAirState { get; private set; }
        public PlayerLandState LandState { get; private set; }

        public PlayerInputHandler InputHandler { get; private set; }
        public Animator Animator { get; private set; }
        public Rigidbody2D Rigidbody2D { get; private set; }

        public Vector2 CurrentVelocity { get; private set; }
        public int FacingDirection { get; private set; }

        [SerializeField] private PlayerData _playerData;
        private Vector2 _workSpace;
        private void Awake()
        {
            StateMachine = new PlayerStateMachine();
            IdleState = new PlayerIdleState(this, StateMachine, _playerData, "idle");
            MoveState = new PlayerMoveState(this, StateMachine, _playerData, "move");
            JumpState = new PlayerJumpState(this, StateMachine, _playerData, "jump");
            InAirState = new PlayerInAirState(this, StateMachine, _playerData, "inAir");
            LandState = new PlayerLandState(this, StateMachine, _playerData, "land");
        }
        private void Start()
        {
            Animator = GetComponent<Animator>();
            InputHandler = GetComponent<PlayerInputHandler>();
            Rigidbody2D = GetComponent<Rigidbody2D>();
            StateMachine.Init(IdleState);

            FacingDirection = 1;
            //Init FSM
        }
        private void Update()
        {
            CurrentVelocity = Rigidbody2D.velocity;
            StateMachine.CurrentState.LogicUpdate();
        }
        private void FixedUpdate()
        {
            StateMachine.CurrentState.PhysicsUpdate();
        }




        public void SetVelocityX(float velocity)
        {
            _workSpace.Set(velocity, CurrentVelocity.y);
            Rigidbody2D.velocity = _workSpace;
            CurrentVelocity = _workSpace;
            //Rigidbody2D.velocity = new Vector2(velocity, Rigidbody2D.velocity.y);
        }
        public void SetVelocityY(float velocity)
        {
            _workSpace.Set(CurrentVelocity.x, velocity);
            Debug.Log(velocity);
            Rigidbody2D.velocity = _workSpace;
            CurrentVelocity = _workSpace;
            //Rigidbody2D.velocity = new Vector2(velocity, Rigidbody2D.velocity.y);
        }




        private void AnimationTrigger() => StateMachine.CurrentState.AnimationTrigger();
        private void AnimationFinishTrigger() => StateMachine.CurrentState.AnimationFinishTrigger();
        public bool CheckIfGrounded()
        {
            return Physics2D.OverlapCircle(_groundCheck.position, _playerData.GroundCheckRadius, _playerData.GroundLayerMask);     
        }
        public void CheckIfShouldFlip(int xInput)
        {
            
            if (xInput != 0 && xInput != FacingDirection)
            {
                Flip();
            }
        }
        private void Flip()
        {
            FacingDirection *= -1;
            transform.Rotate(0.0f, 180, 0.0f);
        }
    }
}
