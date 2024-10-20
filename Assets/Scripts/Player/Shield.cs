using UnityEngine;
using UnityEngine.UIElements;

namespace Duel
{
    public class Shield : MonoBehaviour
    {
        [SerializeField] Player player;
        [SerializeField] GameObject _particalShield;
        [SerializeField] GameObject _particalBlockHit;

        [SerializeField] private int _costActivate = 10;
        [SerializeField] private int _costInSecond = 2;
        [SerializeField] private int _costForBlock = 20;

        private SphereCollider coliderShield;
        private bool _isShieldActive = false;

        private float _timer = 0;

        public bool IsShieldActive { get => _isShieldActive; set => _isShieldActive = value; }

        public void StartShield()
        {
            _particalShield.SetActive(false);
        }
        private void Start()
        {
            coliderShield = GetComponent<SphereCollider>();
            if (coliderShield == null) Debug.LogError("колайдер щита не найден");
        }
        private void Update()
        {
            
                RaiseEnergyOnShield(_costInSecond);
                
        }
        public bool SwitchShield()
        {
            //если щит активен выключаем его
            if (IsShieldActive)
            {
                coliderShield.enabled = false;
                _particalShield.SetActive(false);
                IsShieldActive = false;
                return true;
            }//если щит не активен включаем
            else
            {   // если хватает энергии включаем
                if (player.Stats.SpendEnergy(_costActivate))
                {
                    coliderShield.enabled = true;
                    _particalShield.SetActive(true);
                    IsShieldActive = true;
                    return true;
                }else // если не хватает 
                {
                    return false;
                }
            } 
        }

        public void Block(Vector3 position)
        {
            if (IsShieldActive)
            {
                Instantiate(_particalBlockHit, position, _particalBlockHit.transform.rotation);
                if (!player.Stats.SpendEnergy(_costForBlock))
                {
                    SwitchShield();
                }
            }            
        }
        private void RaiseEnergyOnShield(int value)
        {
            if (IsShieldActive)
            {
                _timer += Time.deltaTime;
                if (_timer >= 1)
                {   
                    //если хватило на поддержание щита
                    if (player.Stats.SpendEnergy(value))
                    {
                        _timer = 0;
                    }
                    else //если не хватило на поддержание щита
                    {
                        SwitchShield();
                    }
                }
            }
        }
        
    }
}

