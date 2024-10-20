using UnityEngine.UI;
using UnityEngine;

namespace Duel
{
    public class EndGame : MonoBehaviour
    {
        [SerializeField] Text _header;
        [SerializeField] Text _back;
        [SerializeField] Text _restart;
        [SerializeField] Text _subheader; 
        [SerializeField] Text _recordText;


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
                    _header.text = "Игра окончена";
                    returnBtn.SetActive(true);
                    _back.text = "Продолжить";
                }
                
                            
                _restart.text = "Заново";
                _subheader.text = "Побед подряд: ";
                _recordText.text = "Рекорд: ";

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