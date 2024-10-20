﻿namespace Duel
{
    public abstract class State
    {
        protected Player player;
        protected StateMachine stateMachine;

        protected State(Player player, StateMachine stateMachine)
        {
            this.player = player;
            this.stateMachine = stateMachine;
        }

        public virtual void Enter()
        {
            
        }
        public virtual void StateUpdate()
        {
            
        }

        public virtual void PhysicUpdate()
        {

        }
        public virtual void Exit()
        {

        }
    }
}

