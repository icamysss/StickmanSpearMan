using UnityEngine;
using YG;


namespace Duel
{
    public class YGamesFunc : MonoBehaviour
    {
        public static YGamesFunc Instance = null;
        public GameData Data;
        public int _winCount = 0;

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
        private void OnEnable() => YandexGame.GetDataEvent += GetData;
        private void OnDisable() => YandexGame.GetDataEvent -= GetData;
        private void Start()
        {
            if (YandexGame.SDKEnabled == true)
            {
                GetData();
            }
        }
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Backspace))
            {
                if (Input.GetKeyDown(KeyCode.F12))
                {
     
                }
            }
        }
        public void Win()
        {
            _winCount++;
            if (_winCount > Data.Record)
            {
                SaveRecord();
            }

        }
        public void Loose()
        {
            if (_winCount > Data.Record)
            {
                SaveRecord();
            } 
        }
        public void GetData()
        {
            Data.Device = YandexGame.EnvironmentData.deviceType;
            Data.PlayerName = YandexGame.playerName;
            Data.Language = YandexGame.EnvironmentData.language;
            Data.Record = YandexGame.savesData.record;

            GameManager.Instance.ChangeLanguage(Data.Language);
            YandexGame.GameplayStop();
        }

        private void SaveRecord()
        {
            Data.Record = _winCount;
            YandexGame.savesData.record = Data.Record;
            YandexGame.SaveProgress();
            YandexGame.NewLeaderboardScores("Leader", Data.Record);
        }
    }
}