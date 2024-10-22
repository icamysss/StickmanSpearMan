using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using Duel;


[RequireComponent(typeof ( AudioSource))]
public class Annoncer : MonoBehaviour
{
    public static Annoncer Instance = null;
    public float showingTime;
    public Text textinUI;

    public AudioClip headShotClip;
    public AudioClip looseClip;
    public AudioClip winClip;

    private AudioSource audioSource;



    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else if (Instance == this)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(Instance);


        textinUI.enabled = false;
        audioSource = GetComponent<AudioSource>();
    }



    public void HeadSHot()
    {
       

        audioSource.PlayOneShot(headShotClip);
        StartCoroutine(ShowText("Хедшот !!!", "Headshot !!!", Color.red ));
    }

    public void EnemyReturn()
    {
        int rnd = Random.Range(0, 4);
        switch (rnd)
        {
            case 0:
                StartCoroutine(ShowText("Я стал сильнее ", "I'm stronger now", Color.blue, 4f));
                break;
            case 1:
                StartCoroutine(ShowText("Борис бритва вернулся", "I've returned", Color.blue, 4f));
                break;
            case 2:
                StartCoroutine(ShowText("Смотрите кто пришел", "Look at me", Color.blue, 4f));
                break;
            default:
                if (YG.YandexGame.auth)
                {
                    StartCoroutine(ShowText(YGamesFunc.Instance.Data.PlayerName +
                   " мы видились? ",
                   YGamesFunc.Instance.Data.PlayerName + " I know you ", Color.blue, 4f));
                }
                else
                {
                    StartCoroutine(ShowText("Мы видились?",
                  " I see you ", Color.blue, 4f));
                }
               
                break;
        }
    }

    /// <summary>
    ///  слабаааааак
    /// </summary>
    public void PlayerDeath()
    {
        audioSource.PlayOneShot(looseClip);

        int rnd = Random.Range(0, 4);
        switch (rnd)
        {
            case 0:
                StartCoroutine(ShowText("Слабак !", "Wuss", Color.blue, 4f));
                break;
            case 1:
                StartCoroutine(ShowText("На рекорд не тянет ...", "It's not a record", Color.blue, 4f));
                break;
            case 2:
                StartCoroutine(ShowText("Этого выносите !", "Take it out", Color.blue, 4f));
                break;
            default:
                // если авторизован
                if (YG.YandexGame.auth)
                {
                    StartCoroutine(ShowText(YGamesFunc.Instance.Data.PlayerName +
                    " вставай ",
                    YGamesFunc.Instance.Data.PlayerName + " wake up ", Color.blue, 4f));
                }
                else
                {
                    StartCoroutine(ShowText(
                                     "что лежишь ? вставай !",
                             " wake up neo ", Color.blue, 4f));
                }
                break;
        }
    }
    // следущщЩЩЩИИИИй
    public void EnemyDeath()
    {
        audioSource.PlayOneShot(winClip);

        int rnd = Random.Range(0, 4);
        switch (rnd)
        {
            case 0:
                StartCoroutine(ShowText("Следующий", "The next", Color.red, 4f));
                break;
            case 1:
                StartCoroutine(ShowText("Этот был слабоват", "This one was a little weak", Color.red, 4f));
                break;
            case 2:
                StartCoroutine(ShowText("Этого выносите", "Take it out", Color.red, 4f));
                break;
            default:
                StartCoroutine(ShowText("Еше фаталити прописать? ", "Fatality ", Color.red, 4f));
                break;
        }
    }

    public void TimetoDance()
    {
        StartCoroutine(ShowText("Пора потанцевать", "Lets dance", Color.green, 2f));
    }


    /// <summary>
    /// текс кажет
    /// </summary>
    /// <param name="Rusmessage">Русское</param>
    /// <param name="Angmessage">Английское</param>
    /// <returns></returns>
    IEnumerator ShowText( string Rusmessage, string Angmessage, Color color, float showingTime)
    {

        string lng = GameManager.Instance.Language;

        textinUI.text = "";
        textinUI.color = color;
        textinUI.enabled = true;

        if (lng == "ru")
        {
            textinUI.text = Rusmessage;
        }
        if (lng == "en")
        {
            textinUI.text = Angmessage;
        }

        yield return new WaitForSeconds(showingTime);

        textinUI.enabled = false;
    }
    IEnumerator ShowText(string Rusmessage, string Angmessage, Color color)
    {

        string lng = GameManager.Instance.Language;

        textinUI.text = "";
        textinUI.color = color;
        textinUI.enabled = true;

        if (lng == "ru")
        {
            textinUI.text = Rusmessage;
        }
        if (lng == "en")
        {
            textinUI.text = Angmessage;
        }

        yield return new WaitForSeconds(showingTime);

        textinUI.enabled = false;
    }
}
 