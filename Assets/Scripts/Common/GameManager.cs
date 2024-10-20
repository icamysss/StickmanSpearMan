using System;
using UnityEngine;
using YG;


namespace Duel
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager Instance = null;
        public static Action onLanguageChanged;
        public static Action onSpawnedPlayer;

        public AudioSource _audioTaunt;
        public AudioClip _music;
        public string Language = "ru";

        public bool isWin = false;
        public bool isPause = false;

        public Level level;
        [HideInInspector] public GameObject player;
        [HideInInspector] public GameObject enemy;





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
            ShowAd();
        }
        private void Start()
        {
            string lng = YGamesFunc.Instance.Data.Language;
            //Debug.Log(lng);
            if (lng != null || lng != "null")
            {
                if (lng == "ru" || lng == "be" || lng == "uk" || lng == "uz" || lng == "kk")
                {
                    Language = "ru";
                    ChangeLanguage(Language);
                }
                else if (lng == "NULL" || lng == null)
                {
                    Language = "ru";
                    ChangeLanguage(Language);
                }
                else 
                {
                    Language = "en";
                    ChangeLanguage(Language);
                }
            }
           
        }
        private void Update()
        {

        }
        public void TauntMusic()
        {
                _audioTaunt.PlayOneShot(_music);
        }
        public void CheckPlayerLinks()
        {
            onSpawnedPlayer?.Invoke();
        }

        public void GameStart()
        {
            level.StartGame();

        }

        public float CalculateDistance()
        {
            if (player == null || enemy == null)
            {
                player = GameObject.FindGameObjectWithTag("Player");
                enemy = GameObject.FindGameObjectWithTag("Enemy");
                return 52;
            }
            else
            {
                return Vector3.Distance(player.transform.position, enemy.transform.position);
            }
        }

        public void GameEnd(string tag)
        {
            if (tag == "Player")
            {
                enemy.GetComponent<Player>().SM.ChangeState(enemy.GetComponent<Player>().win);
                isWin = false;
                ShowAd();
                UI.Instance.GameOver();
            }
            else if (tag == "Enemy")
            {
                player.GetComponent<Player>().SM.ChangeState(player.GetComponent<Player>().win);
                
                isWin = true;
                ShowAd();
                level.ReturnEnemy();
                YGamesFunc.Instance.Win();
            }
        }
        public void ChangeLanguage(string lang)
        {
            Language = lang;
            onLanguageChanged?.Invoke();
        }

        public void ShowAd()
        {
            YandexGame.FullscreenShow(); 
        }
        public void Pause()
        {
            if (isPause)
            {
                Time.timeScale = 1;
                isPause = false;
            }
            else 
            {
                Time.timeScale = 0;
                isPause = true;
            } 
        }
    }
}