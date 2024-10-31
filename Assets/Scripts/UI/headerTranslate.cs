using System;
using UnityEngine;
using UnityEngine.UI;

namespace Duel
{
    public class headerTranslate : MonoBehaviour
    {
        [SerializeField] Text buttonText;

        [SerializeField] string rus;
        [SerializeField] string eng;


        private void Start()
        {
            Changelanguage();
        }

        private void OnEnable()
        {
            GameManager.onLanguageChanged += Changelanguage;
        }
        private void OnDisable()
        {
            GameManager.onLanguageChanged -= Changelanguage;
        }

        public void Changelanguage()
        {
            string str = GameManager.Instance.Language;

            if (str == "ru" || str == "be" || str == "kk" || str == "uk" || str == "uz")
            {
                buttonText.text = rus;
            }
            else buttonText.text = eng;

        }
    }
}
