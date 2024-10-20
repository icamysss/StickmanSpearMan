using TMPro;
using UnityEngine;

namespace Duel
{
    public class EndGame : MonoBehaviour
    {
        [SerializeField] TextMeshProUGUI _header;
        [SerializeField] TextMeshProUGUI _back;
        [SerializeField] TextMeshProUGUI _restart;
        [SerializeField] TextMeshProUGUI _subheader; 
        [SerializeField] TextMeshProUGUI _recordText;


        [SerializeField] GameObject returnBtn;
        

        private void OnEnable()
        {
            GameManager.onLanguageChanged += Changelanguage;
            Changelanguage();
        }
        private void OnDisable()
        {
            GameManager.onLanguageChanged -= Changelanguage;
        }
        private void Start()
        {
            Changelanguage();
        }
        private void Changelanguage()
        {
            string str = GameManager.Instance.Language;
            Debug.Log(str);
            if (str == "ru" || str == "be" || str == "kk" || str == "uk" || str == "uz" )
            {
                if (GameManager.Instance.isWin)
                {
                    _header.text = "Победа";
                    returnBtn.SetActive(false);
                }
                else
                {
                    _header.text = "Проиграл";
                    returnBtn.SetActive(true);
                    _back.text = "Вернуться";
                }
                
                            
                _restart.text = "Ещё раз";
                _subheader.text = "побед подряд:";
                _recordText.text = "рекорд";

            }
            else // if (str == "en")
            {
                if (GameManager.Instance.isWin)
                {
                    _header.text = "Victory";
                    returnBtn.SetActive(false);
                }
                else
                {
                    _header.text = "Game Over";
                    returnBtn.SetActive(true);
                    _back.text = "Back in game";
                }
                
               
                _restart.text = "Again";
                _subheader.text = "victory in a row:";
                _recordText.text = "record";
            }
        }
    }
}