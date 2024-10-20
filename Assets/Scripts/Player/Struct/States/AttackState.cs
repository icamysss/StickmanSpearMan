namespace Duel
{
    public class AttackState : State
    {
        public AttackState(Player player, StateMachine stateMachine) : base(player, stateMachine)
        {
        }
        public override void Enter()
        {
                if (player.Stats.SpendEnergy(15))
                {
                    player.animator.SetTrigger("Throw");
                    player.rig.enabled = true;
                    player.InstantiateSpear();
                }
                else
                {
                    stateMachine.ChangeState(player.idle);
                }
        }

        public override void StateUpdate()
        {
                      
        }

        public override void PhysicUpdate()
        {
          
        }

        public override void Exit()
        {
            player.rig.enabled = false;
        }

    }
}

