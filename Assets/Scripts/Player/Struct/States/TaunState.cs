using UnityEngine;

namespace Duel
{
    public class TaunState : State
    {
        public TaunState(Player player, StateMachine stateMachine) : base(player, stateMachine)
        {
        }

        public override void Enter()
        {
            if (GameManager.Instance._audioTaunt.isPlaying)
            {
                GameManager.Instance._audioTaunt.volume = 0.3f;
            }

            player.ShieldCanOn = false;
            player.ShieldOnOff();
            player.characterController.enabled = false;
            player.animator.SetInteger("Taunt", Random.Range(1,9));
        }

        public override void StateUpdate()
        {
            
        }

        public override void PhysicUpdate()
        {

        }

        public override void Exit()
        {
            player.ShieldCanOn = true;
            if (player.gameObject.tag == "Player")
            {
               if (!(GameManager.Instance.enemy.GetComponent<Player>().SM.CurrentState ==
                    GameManager.Instance.enemy.GetComponent<Player>().taunt))
                {
                    GameManager.Instance._audioTaunt.volume = 0.01f;
                }
            }
            else if (player.gameObject.tag == "Enemy")
            {
                if (!(GameManager.Instance.player.GetComponent<Player>().SM.CurrentState ==
                     GameManager.Instance.player.GetComponent<Player>().taunt))
                {
                    GameManager.Instance._audioTaunt.volume = 0.01f;
                }
            }
        }
    }
}