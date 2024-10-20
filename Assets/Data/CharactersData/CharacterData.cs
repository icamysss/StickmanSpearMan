using UnityEngine;

namespace Duel
{
    [CreateAssetMenu(fileName = "CharacterData", menuName = "Game Data/Character Data")]
    public class CharacterData : ScriptableObject
    {
        [SerializeField] private GameObject _weapon;
        [SerializeField] private Material _playerMaterial;
        [SerializeField] private Material _shieldMaterial;
        [SerializeField] private GameObject _particalHit;
        [SerializeField] private GameObject _particalHeadshot;
        [SerializeField] private GameObject _particalBleeding;
        [SerializeField] private GameObject _particalBloodPool;



        public GameObject Weapon => _weapon;
        public Material PlayerMaterial => _playerMaterial;
        public Material ShieldMaterial => _shieldMaterial;

        public GameObject ParticalHit => _particalHit;
        public GameObject ParticalHeadshot => _particalHeadshot;
        public GameObject ParticalBleeding => _particalBleeding;
        public GameObject ParticalBloodPool => _particalBloodPool;
    }
}
