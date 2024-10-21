using UnityEngine;
using System.Collections;
using UnityEngine.UIElements;

namespace Duel
{
    public class HitPlayer : MonoBehaviour
    {
        [SerializeField] Player player;
        [SerializeField] int _damage = 20;
        


        private void Hit(Vector3 position)
        {
            Instantiate(player.ParticalHit, position, player.ParticalHit.transform.rotation);
            player.Stats.TakeDamage(_damage);
        }
        private void Headshot(Vector3 position)
        {
            Instantiate(player.ParticalHeadshot, position, player.ParticalHeadshot.transform.rotation);
            player.Stats.TakeDamage(_damage);
            Bleeding(position);
        }
        private void Bleeding(Vector3 position)
        {
            Instantiate(player.ParticalBleeding, position, player.ParticalBleeding.transform.rotation,gameObject.transform);           

            player.Stats.TakeDamage(_damage);
            player.Stats.Bleeding();
        }

   

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.tag == "Spear")
            {
                if (gameObject.name == "mixamorig:Hips")      // ????? ? ?????
                {
                    foreach (ContactPoint hitPoint in collision.contacts)
                    {
                        player.Hit();
                        Bleeding(new Vector3(hitPoint.point.x, hitPoint.point.y, hitPoint.point.z));
                        return;
                    }
                }
                else if (gameObject.name == "mixamorig:Spine1") // ????? ? ?????
                {
                    foreach (ContactPoint hitPoint in collision.contacts)
                    {
                        player.Hit();
                        Bleeding(new Vector3(hitPoint.point.x, hitPoint.point.y, hitPoint.point.z));
                        return;
                    }
                }
                else if (gameObject.name == "mixamorig:Head") // ???? ????? ? ??????
                {
                    foreach (ContactPoint hitPoint in collision.contacts)
                    {
                        player.HeadShot();
                        Headshot(new Vector3(hitPoint.point.x, hitPoint.point.y, hitPoint.point.z));
                        return;
                    }

                }
                
                else
                {
                    foreach (ContactPoint hitPoint in collision.contacts)
                    {
                        player.Hit();
                        Hit(new Vector3(hitPoint.point.x, hitPoint.point.y, hitPoint.point.z));
                        return;
                    }
                }
            }
            if (player.SM.CurrentState == player.death)
            {
                if (collision.gameObject.tag == "Ground")
                {
                    if (gameObject.name == "mixamorig:Hips")
                    {
                        Instantiate(player.ParticalBloodPool, gameObject.transform.position, 
                            player.ParticalBloodPool.transform.rotation, collision.gameObject.transform);
                    }
                }
            }
        }
    }
}

