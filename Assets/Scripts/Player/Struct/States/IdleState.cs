using UnityEngine;

namespace Duel
{
    public class IdleState : State
    {
        public IdleState(Player player, StateMachine stateMachine) : base(player, stateMachine)
        {
        }

        public override void Enter()
        {
            player.rig.enabled = false;
            player.animator.SetInteger("Taunt", 0);
            player.animator.SetBool("WinStop", true);
        }

        public override void StateUpdate()
        {
           
        }
        public override void PhysicUpdate()
        {
            
        }

        public override void Exit()
        {
           
         
        }
    }
}
