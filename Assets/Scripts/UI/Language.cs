using UnityEngine.UI;
using UnityEngine;

namespace Duel
{
    public class Language : MonoBehaviour
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

        private void Start()
        {
            if (buttonText == null) Debug.LogError("ссылка");
            buttonText.text = GameManager.Instance.Language;
            Changelanguage();
        }
        public void OnClickButtonLanguage()
        {
            UI.Instance.AClick();
            if (buttonText.text == "ru")
            {
                GameManager.Instance.ChangeLanguage("en");
                buttonText.text = "en";
            }
            else if (buttonText.text == "en")
            {
                GameManager.Instance.ChangeLanguage("ru");
                buttonText.text = "ru";
            }
            else
            {
                buttonText.gameObject.SetActive(false);
            }

        }
        void Changelanguage()
        {
            string str = GameManager.Instance.Language;

            if (str == "ru" || str == "be" || str == "kk" || str == "uk" || str == "uz")
            {
                buttonText.text = "ru";
            }else buttonText.text = "en";

        }
    }
}