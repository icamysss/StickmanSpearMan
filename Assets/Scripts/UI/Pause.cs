using UnityEngine;
using UnityEngine.UI;

namespace Duel
{
    public class Pause : MonoBehaviour
    {
        [SerializeField] Sprite _pause;
        [SerializeField] Sprite _play;
        [SerializeField] Button btn;

        public void CliclBtn()
        {
            GameManager.Instance.Pause();
            UI.Instance.AClick();
            GameManager.Instance.ShowAd();
            AudioManager.Instance.ChangeMute();
        }
        private void Update()
        {
            if (GameManager.Instance.isPause) btn.image.sprite = _play;
            else btn.image.sprite = _pause;
        }
    }
}