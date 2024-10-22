using UnityEngine;
using Duel;
using UnityEngine.UI;

public class recordShow : MonoBehaviour
{
    [SerializeField] Text buttonText;

    [SerializeField] string rus;
    [SerializeField] string eng;



    public YGamesFunc yaf;

    private void OnEnable()
    {
        GameManager.onLanguageChanged += Changelanguage;
    }
    private void OnDisable()
    {
        GameManager.onLanguageChanged -= Changelanguage;
    }

    //private void Start()
    //{
    //    Changelanguage();
    //}
    void Changelanguage()
    {
        string str = GameManager.Instance.Language;

        if (str == "ru" || str == "be" || str == "kk" || str == "uk" || str == "uz")
        {
            buttonText.text = rus + ": " + yaf.Data.Record.ToString();
        }
        else buttonText.text = eng + ": " + yaf.Data.Record.ToString();

    }

    private void Update()
    {
        Changelanguage();
    }
}
