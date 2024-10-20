using Duel;
using UnityEngine;
using UnityEngine.UI;

public class InGameUI : MonoBehaviour
{
    [SerializeField] Slider _playerHealth;
    [SerializeField] Slider _playerEnergy;

    [SerializeField] Slider _enemyHealth;
    [SerializeField] Slider _enemyEnergy;
    public int HPAD = 100;
    public GameObject button;

    [SerializeField] Text victext;

    private bool ShowStats = false;
    private Player _player;
    private Player _enemy;

    private void OnEnable()
    {
        GameManager.onLanguageChanged += Changelanguage;
        Changelanguage();
    }
    private void OnDisable()
    {
        GameManager.onLanguageChanged -= Changelanguage;
    }
    public void InitPlayers(Player player, Player enemy)
    {
        _player = player;
        _enemy = enemy;

        _playerHealth.maxValue = _player.Stats.GetMaxHealth();
        _playerHealth.minValue = 0;
        _playerHealth.value = _player.Stats.GetHealth();

        _playerEnergy.maxValue = _player.Stats.GetMaxEnergy();
        _playerEnergy.minValue = 0;
        _playerEnergy.value = _player.Stats.GetEnergy();

        _enemyHealth.maxValue = _player.Stats.GetMaxHealth();
        _enemyHealth.minValue = 0;
        _enemyHealth.value = _player.Stats.GetHealth();

        _enemyEnergy.maxValue = _enemy.Stats.GetMaxEnergy();
        _enemyEnergy.minValue = 0;
        _enemyEnergy.value = _enemy.Stats.GetEnergy();

        ShowStats = true;
    }
    private void ShowPlayerStats()
    {
        _playerHealth.value = _player.Stats.GetHealth();
        _playerEnergy.value = _player.Stats.GetEnergy();

        _enemyHealth.value = _enemy.Stats.GetHealth();
        _enemyEnergy.value = _enemy.Stats.GetEnergy();
    }
    private void Start()
    {
        victext.text = "";
    }
    private void Update()
    {
        if (ShowStats)
        {
            ShowPlayerStats();
            Changelanguage();
            ShowADHealButtton();
        }
    }
    void Changelanguage()
    {
        string str = GameManager.Instance.Language;
        Debug.Log(str);
        if (str == "ru" || str == "be" || str == "kk" || str == "uk" || str == "uz")
        {
            victext.text = "Побед подряд: " + YGamesFunc.Instance._winCount;
        }
        else // if (str == "en")
        {
            victext.text = "Victory in a row: " + YGamesFunc.Instance._winCount;
        }
    }
    void  ShowADHealButtton()
    {
        if (_player.Stats.GetHealth() < HPAD && _player.SM.CurrentState != _player.death
            && _player.Stats.GetHealth() > 0)
        {
            button.SetActive(true);
        }
        else button.SetActive(false);
    }
}
