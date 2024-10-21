using UnityEngine;

namespace Duel
{
    public class Stats : MonoBehaviour
    {
        private bool stopAll = false;
        public AudioSource _audio;
        public AudioClip _hit;
        [SerializeField] Player player;
        public int _maxHealth = 100;
        [SerializeField] public int _currentHealth;
        public int hpBase = 100;
        private int _maxEnergy = 200;
        [SerializeField] private int _currentEnergy;
        [SerializeField] private int _stepUpEnergy = 2;

        [SerializeField] private float _accuracy = 15;

        private float _timer = 0;
        int _countBleedTick = 0 ;

        [SerializeField] private float strengthBase = 74;
        private float _strength = 0;

        public float Strength { get => _strength; set => _strength = value; }
        public bool StopAll { get => stopAll; set => stopAll = value; }
        public float Accuracy { get => _accuracy; set => _accuracy = value; }

        private void Start()
        {
            _currentEnergy = _maxEnergy;
            _currentHealth = _maxHealth;
            StopAll = false;
        }

        private void Update()
        {
            if (!stopAll)
            {
                RaiseEnergyByTime(_stepUpEnergy);                
            }else
            {
                StopBleed();
            }
            CalculateStregth();
        }



        private void RaiseEnergyByTime(int value)
        {
            _timer += Time.deltaTime;
            if (_timer >= 1)
            {
                _timer = 0;
                RaiseEnergy(value);
            }
        }
        public int GetEnergy()
        {
            return _currentEnergy;
        }
        public int GetMaxEnergy()
        {
            return _maxEnergy;
        }
        public void RaiseEnergy(int value)
        {
            _currentEnergy += value;
            if (_currentEnergy > _maxEnergy) _currentEnergy = _maxEnergy;
        }
        public bool SpendEnergy(int value)
        {
            if (_currentEnergy < value)
                return false;
            else if (_currentEnergy == value)
            {
                _currentEnergy = 0;
                return true;
            }else
            {
                _currentEnergy -= value;
                return true;
            }
        }

        public int GetHealth()
        {
            return _currentHealth;
        }
        public int GetMaxHealth()
        { return _maxHealth; }
        public void Heal(int value)
        {
            _currentHealth += value;
            if (_currentHealth > _maxHealth) _currentHealth = _maxHealth;
            StopBleed();
        }
        public void Bleeding()
        {
            InvokeRepeating("Bleed", 0, 1f);
        }
        public void StopBleed()
        {
            CancelInvoke();
            GameObject[] bleeds = GameObject.FindGameObjectsWithTag("bleed");
            for (int i = 0; i < bleeds.Length; i++)
            {
                Destroy(bleeds[i]);
            }
        }
        private void Bleed()
        {
            _countBleedTick++;
            if (_countBleedTick < 10)
            {
                TakeDamage(1);
            }                 
        }
        public void TakeDamage(int value)
        {
            if (_currentHealth != 0)
            {
                if (_currentHealth <= value)
                {
                    _currentHealth = 0;
                    player.SM.ChangeState(player.death);
                }
                else
                {
                    _currentHealth -= value;
                    if (value > 2)
                    {
                        _audio.PlayOneShot(_hit);
                    }
                }
            } 
        }

        private void CalculateStregth()
        {
            // 
            float str = Random.Range(0 , strengthBase / 5);
            int plusminus = Random.Range(0, 100);
            if (plusminus > 50)
            {
                player.Stats.Strength = strengthBase + str;
            }else
                player.Stats.Strength = strengthBase - str;

        }
        private float GetConstant()
        {
            int distance = Mathf.RoundToInt(GameManager.Instance.CalculateDistance() / 10);
            switch (distance)
            {
                case 10:
                    {
                        return 3.84f;
                    }
                case 9:
                    {
                        return 3.84f;
                    }
                case 8:
                    {
                        return 3.84f;
                    }
                case 7:
                    {
                        return 3.84f;
                    }
                case 6:
                    {
                        return 3.84f;
                    }
                case 5:
                    {
                        return 3.84f;
                    }
                case 4:
                    {
                        return 4.16f;
                    }
                case 3:
                    {
                        return 4.625f;
                    }
                case 2:
                    {
                        return 5.2f;
                    }
                case 1:
                    {
                        return 7.4f;
                    }
                default: return 3.84f;

            }
        }
    }
}

