using TMPro;
using UnityEngine;

namespace Duel
{
    public class Victories : MonoBehaviour
    {
        [SerializeField] TextMeshProUGUI _recordVics;
        [SerializeField] TextMeshProUGUI _currentVics;

        void Update()
        {
            if (YGamesFunc.Instance.Data.Record > 0)
            { _recordVics.text = YGamesFunc.Instance.Data.Record.ToString(); }
            else { _recordVics.text = "-"; }

            _currentVics.text = YGamesFunc.Instance._winCount.ToString();
        }
    }
}