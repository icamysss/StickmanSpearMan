using UnityEngine;
using UnityEngine.UI;

namespace Duel
{
    public class InputManager : MonoBehaviour
    {
        [SerializeField] Button _attack;
        [SerializeField] Button _move;
        [SerializeField] Button _shield;
        [SerializeField] Button _taunt;
        string device;

        void Attack()
        {
            if (_attack.IsInteractable())
            {
                _attack.onClick.Invoke();
            }            
        }
        void Move()
        {
            if (_move.IsInteractable())
            {
                _move.onClick.Invoke();
            }
        }
        void Shield()
        {
            if (_shield.IsInteractable())
            {
                _shield.onClick.Invoke();
            }
        }
        void Taunt()
        {
            if (_taunt.IsInteractable())
            {
                _taunt.onClick.Invoke();
            }
        }

        private void Start()
        {
            device = YGamesFunc.Instance.Data.Device;
        }
        private void Update()
        {
            SelectInput();
        }

        void SelectInput()
        {
                if (Input.GetKeyUp(KeyCode.A)) Attack();
                if (Input.GetKeyUp(KeyCode.D)) Taunt();
               // if (Input.GetKeyUp(KeyCode.W)) Move();
                if (Input.GetKeyUp(KeyCode.S) || Input.GetKeyUp(KeyCode.Space)) Shield();
        }
    }
}