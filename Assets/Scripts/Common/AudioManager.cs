using UnityEngine;
using UnityEngine.UI;

namespace Duel
{
    public class AudioManager : MonoBehaviour
    {
        [SerializeField] Button pause;
        public AudioListener listener;
        public bool Muted = false;
        public static AudioManager Instance = null;
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
        
        public void ChangeMute()
        {
            if (!Muted )
            {
                Muted = true;
                AudioListener.volume = 0;
            }
            else if (Muted  )
            {
                Muted = false;
                AudioListener.volume = 1;
            }
        }
        private void OnApplicationFocus(bool focus)
        {
            if (!focus)
            {
                AudioListener.volume = 0;

            }
            else if (GameManager.Instance.isPause)
            {
                AudioListener.volume = 0;

            }
            else if (focus)
            {
                if (!GameManager.Instance.isPause && !Muted)
                {
                    AudioListener.volume = 1;
                }           
            }

            
        }
        void OnApplicationPause(bool isPaused)
        {
            if (isPaused)
            {
                Muted = true;
                AudioListener.volume = 0;
            }
            else
            {
                Muted = false;
                AudioListener.volume = 1;
            }
        }
    }
}