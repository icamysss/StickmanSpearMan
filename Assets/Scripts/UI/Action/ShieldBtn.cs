using UnityEngine;
using UnityEngine.UI;

namespace Duel
{
    public class ShieldBtn : MonoBehaviour
    {
        [SerializeField] Sprite _on;
        [SerializeField] Sprite _off;
        [SerializeField] Animator animator;

        [SerializeField] Image _image;
        private Player player;
        private Player enemy;
        bool playerGet = false;

        private void Start()
        {
            GetPlayer();
            // включаем на старте
            player.ShieldOnOff();
        }
        private void OnEnable()
        {
            GameManager.onSpawnedPlayer += GetPlayer;
        }
        private void OnDisable()
        {
            GameManager.onSpawnedPlayer -= GetPlayer;
        }
        public void Enable()
        {
            gameObject.GetComponent<Button>().interactable = true;
            _image.sprite = _on;
        }
        public void Disable()
        {
            gameObject.GetComponent<Button>().interactable = false;
            _image.sprite = _off;
            animator.enabled = false;
        }

        public void ClickBtn()
        {
            player.ShieldOnOff();
        }

        private void GetPlayer()
        {
            player = GameManager.Instance.player.GetComponent<Player>();
            if (player != null) playerGet = true;
            enemy = GameManager.Instance.enemy.GetComponent<Player>();
        }
        private void Update()
        {
            if (playerGet)
            {
                if (player.Stats.GetEnergy() > 5 && player.ShieldCanOn)
                {
                    Enable();
                }
                else if (player._shield.IsShieldActive)
                {
                    Enable();
                }
                else Disable();

                if (player._shield.IsShieldActive) animator.enabled = true;
                else
                {
                    animator.enabled = false;
                    gameObject.transform.localScale = new Vector3(1, 1, 1);
                }

               

            }

            if (player.SM.CurrentState == player.death || enemy.Stats.GetHealth() <= 0)
            {
                Disable();
            }          
        }
    }
}