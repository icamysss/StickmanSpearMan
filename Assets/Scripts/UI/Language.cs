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
            if (buttonText.text == "Русский")
            {
                GameManager.Instance.ChangeLanguage("en");
                buttonText.text = "English";
            }
            else if (buttonText.text == "English")
            {
                GameManager.Instance.ChangeLanguage("ru");
                buttonText.text = "Русский";
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
                buttonText.text = "Русский";
            }else buttonText.text = "English";

        }
    }
}