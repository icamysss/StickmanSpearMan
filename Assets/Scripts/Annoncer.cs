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

    /// <summary>
    ///  слабаааааак
    /// </summary>
    public void PlayerDeath()
    {
        audioSource.PlayOneShot(looseClip);

        int rnd = Random.Range(0, 3);
        switch (rnd)
        {
            case 0:
                StartCoroutine(ShowText("Слабак ", "Wuss", Color.white, 4f));
                break;
            case 1:
                StartCoroutine(ShowText("На рекорд не тянет", "It's not a record", Color.white, 4f));
                break;
            case 2:
                StartCoroutine(ShowText("Этого выносите", "Take it out", Color.white, 4f));
                break;
            default:
                StartCoroutine(ShowText(YGamesFunc.Instance.Data.PlayerName +
                    " вставай ",
                    YGamesFunc.Instance.Data.PlayerName + " wake up ", Color.white, 4f));
                break;
        }
    }
    // следущщЩЩЩИИИИй
    public void EnemyDeath()
    {
        audioSource.PlayOneShot(winClip);

        int rnd = Random.Range(0, 3);
        switch (rnd)
        {
            case 0:
                StartCoroutine(ShowText("Следущий", "The next", Color.red, 4f));
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
 