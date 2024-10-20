using UnityEngine;

namespace Duel
{ 
    
    public class AnimationEvent : MonoBehaviour
    {
        [SerializeField] Player _player;
        [SerializeField] AudioSource _audio;
        [SerializeField] AudioClip _throw;
        public void SpearThrowAnimationEvent()
        {
            _player.rig.enabled = false;
            _player.spear.SpearFly(_player.Stats.Strength, _player.Stats.Accuracy);
            _audio.PlayOneShot(_throw);
        }

        public void  EndSpearAnimation()
        {
            _player.SM.ChangeState(_player.idle);
        }
        public void EndSmallTaunt()
        {
            _player.SM.ChangeState(_player.idle);
            _player.Stats.RaiseEnergy(35);
            _player.animator.SetInteger("Taunt", 0);
        }
        public void EndBigTaunt()
        {
            _player.SM.ChangeState(_player.idle);
            _player.Stats.RaiseEnergy(50);
            _player.animator.SetInteger("Taunt", 0);
        }
    }
}
