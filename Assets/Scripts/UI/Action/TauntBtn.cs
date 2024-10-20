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
        public void ClickBtn()
        {
            player.SM.ChangeState(player.taunt);
        }

        private void GetPlayer()
        {
            player = GameManager.Instance.player.GetComponent<Player>();
            if (player != null) playerGet = true;
        }
        private void Update()
        {
            if (playerGet && player != null)
            {
                if (player.SM.CurrentState == player.idle)
                {
                    Enable();
                }
                else Disable();
            }                
        }
    }
}