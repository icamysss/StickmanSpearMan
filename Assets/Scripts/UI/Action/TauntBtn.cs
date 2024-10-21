using UnityEngine;
using UnityEngine.UI;

namespace Duel
{
    public class TauntBtn : MonoBehaviour
    {
        [SerializeField] Sprite _on;
        [SerializeField] Sprite _off;

        [SerializeField] Image _image;
        private Player player;
        private Player enemy;
        bool playerGet = false;
        Animation animation;

        private void Start()
        {
            GetPlayer();
                animation = GetComponent<Animation>();
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
        public void ClickBtn()
        {
            player.SM.ChangeState(player.taunt);
        }

        private void GetPlayer()
        {
            player = GameManager.Instance.player.GetComponent<Player>();
            if (player != null) playerGet = true;
            enemy = GameManager.Instance.enemy.GetComponent<Player>();
        }
        private void Update()
        {
            if (playerGet && player != null)
            {
                if (player.SM.CurrentState == player.idle && enemy.Stats.GetHealth() > 0)
                {
                    Enable();
                }
                else Disable();
            }

            if (player.Stats.GetEnergy() < 30)
            {
                animation.Play();
            }
            else
            {
                animation.Stop();
            }
        }
    }
}