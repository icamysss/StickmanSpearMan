using UnityEngine;
using UnityEngine.UI;

namespace Duel
{
    public class AttackBtn : MonoBehaviour
    {
        [SerializeField] Sprite _on;
        [SerializeField] Sprite _off;

        [SerializeField] Image _image;
        private Player player;
        private Player enemy;

        bool playerGet = false;

        private void Start()
        {
            GetPlayer();
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
        }

        public void GetPlayer()
        {
            player = GameManager.Instance.player.GetComponent<Player>();
            if (player != null) playerGet = true;

            enemy = GameManager.Instance.enemy.GetComponent<Player>();

        }

        public void ClickBnt()
        {
            if ( player.SM.CurrentState != player.attack)
            {
                player.SM.ChangeState(player.attack);
            }
        }
        private void Update()
        {
            if (player.SM.CurrentState != player.death && enemy.Stats.GetHealth() > 0)
            {
                if (playerGet && player != null)
                {
                    if (player.SM.CurrentState == player.idle)
                    {
                        if (player.Stats.GetEnergy() >= 15)
                        {
                            Enable();
                        }
                    }
                    else Disable();
                }
                if (player.Stats.GetEnergy() < 15)
                {
                    Disable();
                }
            }
            else
            {
                Disable();

            }
        }
    }
}