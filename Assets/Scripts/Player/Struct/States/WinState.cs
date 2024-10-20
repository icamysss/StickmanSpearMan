using UnityEngine;

namespace Duel
{
    public class WinState : State
    {
        float time = 0;
        public WinState(Player player, StateMachine stateMachine) : base(player, stateMachine)
        {
        }
        public override void Enter()
        {
            player.animator.SetBool("WinStop", false);
            player.animator.SetTrigger("Win");
            player.ShieldCanOn = false;
        }

        public override void StateUpdate()
        {
           time+= Time.deltaTime;
            if (time > 5)
            {
                time = 0;
                stateMachine.ChangeState(player.idle);
            }
        }

        public override void Exit()
        {
            player.ShieldCanOn = true;
        }
    }
}