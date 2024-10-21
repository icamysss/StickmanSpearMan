using UnityEngine;

namespace Duel
{
    public class DeathState : State
    {
        public DeathState(Player player, StateMachine stateMachine) : base(player, stateMachine)
        {
        }

        public override void Enter()
        {
            player.animator.SetInteger("Taunt", 0);
            player.ShieldCanOn = false;
            player.characterController.enabled = false;
            EnableRagDoll(true);


            if (player.spear != null) player.DestroySpear();

            GameObject[] spears = GameObject.FindGameObjectsWithTag("Spear");
            foreach (GameObject go in spears)
            {
                Spear s = go.GetComponent<Spear>();
                if (s != null) s.Destroy();

            }

            player.Stats.StopAll = true;

            if (player.gameObject.tag == "Player")
            {
                GameManager.Instance.enemy.GetComponent<Enemy>()._enemyEnable = false;
                Annoncer.Instance.PlayerDeath();
                player.Death();
            } else if (player.gameObject.tag == "Enemy")
            {
                Annoncer.Instance.EnemyDeath();
                //YGamesFunc.Instance.Win();
                player.Death();
                //выключаем ввод
            }
   
        }

        public override void StateUpdate()
        {
          
        }
        public override void PhysicUpdate()
        {
            base.PhysicUpdate();
        }
        public override void Exit()
        {
            player.characterController.enabled = false;
            EnableRagDoll(false);
            player.Stats.StopAll = false;
            player.ShieldCanOn = true;

        }

        public void EnableRagDoll(bool value)
        {
            if (!value)
            {
                player.animator.enabled = true;
                for (int i = 0; i < player.ragdollRigidBodies.Length; i++)
                {
                    player.ragdollRigidBodies[i].isKinematic = true;
                }
            }
            else if (value)
            {
                player.animator.enabled = false;
                for (int i = 0; i < player.ragdollRigidBodies.Length; i++)
                {
                    player.ragdollRigidBodies[i].isKinematic = false;
                }
            }
        }
    }
}
