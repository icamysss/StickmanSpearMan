using UnityEngine;
using UnityEngine.UI;

namespace Duel
{
    public class headerTranslate : MonoBehaviour
    {
        [SerializeField] Text buttonText;

        private void OnEnable()
        {
            GameManager.onLanguageChanged += Changelanguage;
        }
        private void OnDisable()
        {
            GameManager.onLanguageChanged -= Changelanguage;
        }

        void Changelanguage()
        {
            string str = GameManager.Instance.Language;

            if (str == "ru" || str == "be" || str == "kk" || str == "uk" || str == "uz")
            {
                buttonText.text = "Нажми что бы начать";
            }
            else buttonText.text = "Press to start";

        }
    }
}
