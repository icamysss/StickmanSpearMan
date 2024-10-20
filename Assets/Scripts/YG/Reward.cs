using UnityEngine;
using YG;
using Duel;

public class Reward : MonoBehaviour
{
	public Level level;

// Подписываемся на событие открытия рекламы в OnEnable
private void OnEnable()
{
	YandexGame.RewardVideoEvent += Rewarded;
}

// Отписываемся от события открытия рекламы в OnDisable
private void OnDisable()
{
	YandexGame.RewardVideoEvent -= Rewarded;
}

	// Подписанный метод получения награды
	void Rewarded(int id)
	{
		// Если ID = 1, то выдаём "+100 монет"
		if (id == 1)
		{
			level.ReturnPlayer();
			UI.Instance._endGame.SetActive(false);
			YG.YandexGame.GameplayStart();
		}

		// Если ID = 2, то выдаём "здоровье".
		else if (id == 2)
		{
			GameManager.Instance.player.GetComponent<Player>().Stats.Heal(500);
			YG.YandexGame.GameplayStart();
		}
	}

// Метод для вызова видео рекламы
public void ExampleOpenRewardAd(int id)
{
	// Вызываем метод открытия видео рекламы
	YandexGame.RewVideoShow(id);
		YG.YandexGame.GameplayStop();
	}
}
