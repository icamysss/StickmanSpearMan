using UnityEngine;


namespace Duel
{
    public class MoveState : State
    {
        float _distance;
        Vector3 _dir;
        Vector3 _currentPosition;
        float _speed = 5;

        public MoveState(Player player, StateMachine stateMachine) : base(player, stateMachine)
        {
        }
        public override void Enter()
        {
            if (GameManager.Instance.CalculateDistance() > 12 && player.Stats.GetEnergy() > 80)
            {
                player.Stats.SpendEnergy(75);
                player.characterController.enabled = true;
                _distance = Random.Range(2, 4);
                _dir = player.transform.InverseTransformDirection(Vector3.forward);
                _currentPosition = player.transform.position;
                player.animator.SetBool("Walk", true);
            }else
            {
                stateMachine.ChangeState(player.idle);
            }
        }
        public override void StateUpdate()
        {
            if (GameManager.Instance.CalculateDistance() <= 10)
                stateMachine.ChangeState(player.idle);
        }

        public override void PhysicUpdate()
        {
            float offset = Mathf.Abs(_currentPosition.z) - Mathf.Abs(player.transform.position.z);

            if (Mathf.Abs(offset) < _distance)
            {
                player.characterController.Move(_dir * _speed / 100);                
            }
            else if (Mathf.Abs(offset) >= _distance)
            {
                stateMachine.ChangeState(player.idle);
            }
        }

        public override void Exit()
        {
           /// float moveDistforAccuracy = Vector3.Distance(player.StartPos, player.gameObject.transform.position);

          //  if ((5 - Mathf.RoundToInt(moveDistforAccuracy)/3) > 0)
          //  {
          //      player.Stats.Accuracy = 15 - Mathf.RoundToInt(moveDistforAccuracy) / 3;
         //   }
          //  else player.Stats.Accuracy = 1;


          player.characterController.enabled = false;
          player.animator.SetBool("Walk", false);
        }
    }
}

