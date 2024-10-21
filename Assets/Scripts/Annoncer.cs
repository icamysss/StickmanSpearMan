using UnityEngine;

[RequireComponent(typeof ( AudioSource))]
public class Annoncer : MonoBehaviour
{
    public static Annoncer Instance = null;

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
    }



    public void HeadSHot()
    {

    }
    /// <summary>
    ///  слабаааааак
    /// </summary>
    public void PlayerDeath()
    {

    }
    // следущщЩЩЩИИИИй
    public void EnemyDeath()
    {

    }

    public void 

}
