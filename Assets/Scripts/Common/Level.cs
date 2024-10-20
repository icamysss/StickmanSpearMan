using UnityEngine;

namespace Duel
{
    public class Level : MonoBehaviour
    {
        [SerializeField] GameObject road;
        [Header("player")]
        [SerializeField] GameObject _playerPrefab;
        [SerializeField] Transform playerSpawnPoint;

        [Header("Enemy")]
        [SerializeField] GameObject _enemyPrefab;
        [SerializeField] Transform enemySpawnPoint;


        public void StartGame()
        {
            road.SetActive(true);
            SpawnPlayers();
           // SpawnEnemy();         
        }

        public void SpawnPlayers()
        {
            GameObject player = Instantiate(_playerPrefab, playerSpawnPoint.position, _playerPrefab.transform.rotation);
            player.layer = 6;
            player.name = "Player";
            player.tag = "Player";
            GameManager.Instance.player = player;

            GameObject enemy = Instantiate(_enemyPrefab, enemySpawnPoint.position, Quaternion.Euler(new Vector3(0, 180, 0)));
            enemy.layer = 7;
            enemy.name = "Enemy";
            enemy.tag = "Enemy";
            GameManager.Instance.enemy = enemy;

            GameManager.Instance.CheckPlayerLinks();
            UI.Instance.ShowStats(player.GetComponent<Player>(),enemy.GetComponent<Player>());
            
        }
        public void SpawnEnemy()
        {
            GameObject enemy = Instantiate(_enemyPrefab, enemySpawnPoint.position, Quaternion.Euler(new Vector3(0, 180, 0)));
            enemy.layer = 7;
            enemy.name = "Enemy";
            enemy.tag = "Enemy";
            GameManager.Instance.enemy = enemy;
            GameManager.Instance.CheckPlayerLinks();
        }
        public void LevelReset()
        {
            GameObject[] spears = GameObject.FindGameObjectsWithTag("Spear");
            foreach (GameObject go in spears)
            {
                Destroy(go);
            }
            Destroy(GameManager.Instance.player.gameObject);
            Destroy(GameManager.Instance.enemy.gameObject);
            UI.Instance._endGame.SetActive(false);
            UI.Instance._inGameUI.SetActive(true);
            YGamesFunc.Instance._winCount = 0;
            StartGame();
        }
        public void ReturnPlayer()
        {
            Player pl = GameManager.Instance.player.GetComponent<Player>();
            if (pl != null)
            {
                pl.Stats.Heal(1000);
                pl.SM.ChangeState(pl.idle);
                GameObject[] spears = GameObject.FindGameObjectsWithTag("Spear");
                foreach (GameObject go in spears)
                {
                    Destroy(go);
                }
                GameManager.Instance.CheckPlayerLinks();
                UI.Instance._inGameUI.SetActive(true);
                GameManager.Instance.enemy.GetComponent<Player>().SM.ChangeState(GameManager.Instance.enemy.GetComponent<Player>().idle);
            }
            else LevelReset();
        }
        public void ReturnEnemy()
        {
            Player pl = GameManager.Instance.enemy.GetComponent<Player>();
            if (pl != null)
            {
                pl.Stats.Heal(1000);
                pl.SM.ChangeState(pl.idle);
                GameManager.Instance.CheckPlayerLinks();
                GameManager.Instance.player.GetComponent<Player>().SM.ChangeState(GameManager.Instance.player.GetComponent<Player>().idle);
                UI.Instance._inGameUI.SetActive(true);
            }
            else LevelReset();
        }
    }
}