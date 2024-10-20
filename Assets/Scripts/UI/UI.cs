using UnityEngine;


namespace Duel
{
    public class UI : MonoBehaviour
    {
        public static UI Instance = null;

        public GameObject _startUI;
        public GameObject _inGameUI;
        public GameObject _endGame;
        public AudioClip _click;
        public AudioSource _audio;

        private InGameUI inGameUI;

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }
            else if (Instance == this)
            {
                Destroy(gameObject);
            }
            DontDestroyOnLoad(Instance);
        }
        private void Start()
        {
            inGameUI = _inGameUI.GetComponent<InGameUI>();
        }
        public void ClickStart()
        {
            GameManager.Instance.GameStart();
            _startUI.SetActive(false);
            _inGameUI.SetActive(true);
            AClick();
        }
        
        public void ShowStats(Player player, Player enemy)
        {
            inGameUI.InitPlayers(player, enemy);
        }
        public void AClick()
        {
            _audio.PlayOneShot(_click);
        }
        public void GameOver()
        {
            _endGame.SetActive(true);
        }
    }
}