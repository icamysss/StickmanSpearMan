using UnityEngine;

namespace Duel
{
    public class Level : MonoBehaviour
    {
        [SerializeField] GameObject road;
        [SerializeField] GameObject _playerPrefab;
        [SerializeField] GameObject _enemyPrefab;

        
        public void StartGame()
        {
            road.SetActive(true);
            SpawnPlayers();
           // SpawnEnemy();         
        }

        public void SpawnPlayers()
        {
            GameObject go = Instantiate(_playerPrefab, new Vector3(-0.214f, 0, -26), _playerPrefab.transform.rotation);
            go.layer = 6;
            go.name = "Player";
            go.tag = "Player";
            GameManager.Instance.player = go;

            GameObject goE = Instantiate(_enemyPrefab, new Vector3(0, 0, 26), Quaternion.Euler(new Vector3(0, 180, 0)));
            goE.layer = 7;
            goE.name = "Enemy";
            goE.tag = "Enemy";
            GameManager.Instance.enemy = goE;

            GameManager.Instance.CheckPlayerLinks();
            UI.Instance.ShowStats(go.GetComponent<Player>(),goE.GetComponent<Player>());
            
        }
        public void SpawnEnemy()
        {
            GameObject goE = Instantiate(_enemyPrefab, new Vector3(0, 0, 26), Quaternion.Euler(new Vector3(0, 180, 0)));
            goE.layer = 7;
            goE.name = "Enemy";
            goE.tag = "Enemy";
            GameManager.Instance.enemy = goE;
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
                GameObject[] spears = GameObject.FindGameObjectsWithTag("Spear");
                foreach (GameObject go in spears)
                {
                    Destroy(go);
                }
                GameManager.Instance.CheckPlayerLinks();
                GameManager.Instance.player.GetComponent<Player>().SM.ChangeState(GameManager.Instance.player.GetComponent<Player>().idle);
            }
            else LevelReset();
        }
    }
}