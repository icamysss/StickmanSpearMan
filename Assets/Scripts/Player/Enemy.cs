using UnityEngine;

namespace Duel
{
    public class Enemy : MonoBehaviour
    {
        [SerializeField] Player player;
        float _distance = 52;
        [SerializeField] float _ActionDelay;
        public bool _enemyEnable = true;    
        private bool _shieldOn = false;
        private float _timer, _shieldTimer = 0;

        void Start()
        {
            _ActionDelay = 1;
        }


        void Update()
        {
            if (_enemyEnable)
            {
                ShieldDeActivate();
                _timer += Time.deltaTime;
                if (_timer > _ActionDelay)
                {
                    _timer = 0;
                    EnemyLogic();
                }
            }
        }

        private void EnemyLogic()
        {
            if (player.SM.CurrentState == player.idle)
            {
               Actions _action = SelectAction();

                if (_action == Actions.Attack)
                {
                    player.SM.ChangeState(player.attack);
                }
                ////else if (_action == Actions.Move)
                ////{
                ////    player.SM.ChangeState(player.move);
                //}
            else if (_action == Actions.Taunt)
                {
                    player.SM.ChangeState(player.taunt);
                }
            }
        }
        private void ShieldDeActivate()
        {
            _shieldTimer += Time.deltaTime;
            if (_shieldTimer > 3)
            {
                _shieldTimer = 0;
                if (_shieldOn)
                {
                    if (player.Stats.GetEnergy() < 30)
                    {
                        player.ShieldOnOff();
                        _shieldOn = false;
                        return;
                    }
                    int i = Random.Range(0, 10);
                    if (i <= 2)
                    {
                        player.ShieldOnOff();
                        _shieldOn = false;
                    }

                }
            }    
        }
        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.tag == "Spear")
            {
                if (player.Stats.GetEnergy() > 80)
                {
                    if (!_shieldOn)
                    {
                        player.ShieldOnOff();
                        _shieldOn = true;
                    }
                }
                else
                {
                    int i = Random.Range(0, 10);
                    if (i <= 8)
                    {
                        if (player.Stats.GetEnergy() > 17)
                        {
                            if (!_shieldOn)
                            {
                                player.ShieldOnOff();
                                _shieldOn = true;
                            }
                        }
                    }                    
                }
            }
        }
        private Actions SelectAction()
        {
            if (player.Stats.GetEnergy() < 15)
            {
                return Actions.Taunt;
            }else if (player.Stats.GetEnergy() > 15 && player.Stats.GetEnergy() < 60)
            {
                int t = Random.Range(0, 10);
                if (t < 3)
                {
                    return Actions.Taunt;
                }else if (t >= 3)
                {
                    int i = Random.Range(0, 10);
                    if (i > 4)
                    {
                        return Actions.Attack;
                    }
                    else
                    {
                        if (_distance < 15)
                        {
                            return Actions.Attack;
                        }
                        else return Actions.Attack;
                    }
                }else { return Actions.Attack; }
            }else
            {
                int k = Random.Range(0, 10);
                if (k > 7)
                {
                    return Actions.Attack;
                }
                else
                {
                    return Actions.Attack;
                }
            }  
        }
       
    }
}