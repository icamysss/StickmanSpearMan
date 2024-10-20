using UnityEngine;

namespace Duel
{
    public class DestroyGameObject : MonoBehaviour
    {
        [SerializeField] private float timeToDestroy;
        void Start()
        {
            Destroy(this.gameObject, timeToDestroy);
        }
    }
}

