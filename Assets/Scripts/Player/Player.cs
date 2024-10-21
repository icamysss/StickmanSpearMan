using UnityEngine;
using UnityEngine.Animations.Rigging;

namespace Duel
{
    public class Player : MonoBehaviour
    {

        #region StateMachine
        public StateMachine SM;
        public IdleState idle;
        public MoveState move;
        public WinState win;
        public DeathState death;
        public AttackState attack;
        public TaunState taunt;
        #endregion

        #region Public properties
        public AudioClip _headShot;
        public AudioClip _hit;
        
        public AudioSource _audio;
        
        public Rigidbody[] ragdollRigidBodies;
        public Animator animator;
        public CharacterController characterController;
        public RigBuilder rig;
        public Vector3 StartPos;
        [HideInInspector] public Spear spear;
        #endregion

        [SerializeField] SkinnedMeshRenderer _stickman; 
        [SerializeField] private CharacterData data;
        [SerializeField] GameObject _spearSpawn;
        public Shield _shield;
        [SerializeField] private Stats _stats;
        private bool shieldCanOn = true;
        public Stats Stats { get => _stats; set => _stats = value; }
        public bool ShieldCanOn { get => shieldCanOn; set => shieldCanOn = value; }
        #region CharacterData
        private Material PlayerMaterial => data.PlayerMaterial;
        private Material ShieldMaterial => data.ShieldMaterial;
        private GameObject _spear => data.Weapon;
        public GameObject ParticalHit => data.ParticalHit; // ??????? ?????????
        public GameObject ParticalHeadshot => data.ParticalHeadshot;
        public GameObject ParticalBleeding => data.ParticalBleeding;
        public GameObject ParticalBloodPool => data.ParticalBloodPool;

       
        #endregion




        private void Start()
        {
            #region ????????????? StateMachine
            SM = new StateMachine();
            idle = new IdleState(this, SM);
            move = new MoveState(this, SM);
            win = new WinState(this, SM);
            death = new DeathState(this, SM);
            attack = new AttackState(this, SM);
            taunt = new TaunState(this,SM);
            SM.Initialize(idle);
            #endregion
            Initialization();
            StartPos = gameObject.transform.position;
        }

        private void Update()
        {

            SM.CurrentState.StateUpdate();
        }     

        private void FixedUpdate()
        {
            SM.CurrentState.PhysicUpdate();
        }

        public void ShieldOnOff()
        {
            if (shieldCanOn)
            {
                _shield.SwitchShield();
            }
            else 
            {
                if (_shield.IsShieldActive) _shield.SwitchShield();
            }
        }
        public void InstantiateSpear()
        {
          Instantiate(_spear, _spearSpawn.transform.position, _spearSpawn.transform.rotation, _spearSpawn.transform);

            spear = _spearSpawn.GetComponentInChildren<Spear>();
            if (spear == null) Debug.LogError(this);
            else spear.SetSpearLayer(gameObject.layer);
        }
        public void Initialization()
        {
            _stickman.material = PlayerMaterial;
            _shield.gameObject.layer = gameObject.layer;
            _shield.GetComponentInChildren<ParticleSystem>().GetComponent<Renderer>().material = ShieldMaterial;
            _shield.StartShield();
        }
        public void DestroySpear()
        {
            Destroy(spear.gameObject);
        }

        public void HeadShot()
        {
            _audio.PlayOneShot(_headShot);
        }
        
        public void Death()
        {
            Invoke("GameEnd", 7);
        }
        void GameEnd()
        {
            GameManager.Instance.GameEnd(gameObject.tag);
        }
        public void Hit()
        {
            _audio.PlayOneShot(_hit);
        }
    }
}

