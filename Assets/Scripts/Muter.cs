using System;
using UnityEngine;

namespace Duel
{
    [RequireComponent(typeof(AudioSource))]
    public class Muter : MonoBehaviour
    {
        AudioSource source;
        private void Start()
        {
            source = GetComponent<AudioSource>();
        }

        private void OnApplicationFocus(bool focus)
        {
            if (!focus)
            {
               source.Stop();
               source.volume = 0;
            }
            else if (GameManager.Instance.isPause)
            {
               source.Stop();
               source.volume = 0;
            }
            else if (focus)
            {
                    
            }

            
        }
        void OnApplicationPause(bool isPaused)
        {
            if (isPaused)
            {
               source.Stop();
               source.volume = 0;
            }
            else
            {
          
            }
        }
    }
}