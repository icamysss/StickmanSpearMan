using UnityEngine;
using UnityEngine.UI;

namespace Duel
{
    public class MuteBtn : MonoBehaviour
    {
        [SerializeField] Button btn;

        public void CliclBtn()
        {
            AudioManager.Instance.ChangeMute();
            UI.Instance.AClick();
        }
        private void Update()
        {
            if (AudioManager.Instance.Muted) btn.image.color = Color.red;
            else btn.image.color = Color.white;
        }
    }
}