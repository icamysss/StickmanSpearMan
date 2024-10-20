using UnityEngine;

namespace Duel
{
    public class Spear : MonoBehaviour
    {
        [SerializeField] Rigidbody _head;
        [SerializeField] Rigidbody _body;
        [SerializeField] GameObject _particalSmoke;

        void Start()
        {
            SetKinematic(true);
            _particalSmoke.SetActive(false);
        }
        public void SpearFly(float power, float range)
        {
            SetKinematic(false);             

            _head.AddRelativeForce(Vector3.up * power, ForceMode.Impulse);
            RandomStrength(range);
        }
        private void RandomStrength(float range)
        {
            float rnd = Random.Range(-range, range);
            _head.AddRelativeForce(new Vector3(rnd, 0, 0) * 0.1f, ForceMode.Impulse);
        }
        public void SetKinematic(bool isKinematic)
        {
            if (isKinematic)
            {
                _head.isKinematic = true;
                _body.isKinematic = true;
                _particalSmoke.SetActive(false);
            }
            else
            {
                if (gameObject.transform.parent != null) gameObject.transform.parent = null;
                _particalSmoke.SetActive(true);
                _body.isKinematic = false;
                _head.isKinematic = false;
            }
        }
        private void OnCollisionEnter(Collision collision)
        {
            //???? ????? ? ??? ??? ????? ??????????
            if (collision.gameObject.name == "Shield")
            {
                //Debug.Log("????? ?: " + collision.gameObject.name);
                DestroySpear(true,0);
                
                foreach(ContactPoint hitPoint in collision.contacts)
                {
                   collision.gameObject.GetComponent<Shield>().Block(new Vector3(hitPoint.point.x,
                                                                                 hitPoint.point.y, hitPoint.point.z));
                }
                
                // ???? ????? ? ?????????  
            } else if (collision.gameObject.tag == "Player" || collision.gameObject.tag == "Enemy")
            {
               // Debug.Log("????? ?: " + collision.gameObject.name);
                DestroySpear(false, 120);
                gameObject.transform.SetParent(collision.transform);
                Hit();

            } //????? ? ?????????
            else if (collision.gameObject.name == "Catcher")
            {
                DestroySpear(true,0);
            }else if (collision.gameObject.tag == "Spear")
            {
                DestroySpear(true, 0);

                GameObject.Destroy(collision.gameObject);
            }
            else
            {// ????? ?? ??? ?? ??????
                //Debug.Log("????? ?: " + collision.gameObject.name);
                DestroySpear(false, 40);
                gameObject.transform.SetParent(collision.transform);
                Hit();
            }

            
        }
        public void DestroySpear(bool quick, float time)
        {
            if (quick)
            {
                Destroy(gameObject);
            }
            else
            {
                Destroy(gameObject, time);
            }           
        }
        public void SetSpearLayer(int i)
        {
            gameObject.layer = i;
            _body.gameObject.layer = i;
        }
        private void Hit()
        {
            SetKinematic(true);         
            _head.GetComponent<CapsuleCollider>().enabled = false;
            _body.GetComponent<CapsuleCollider>().enabled = false;
        }
        public void Destroy()
        {
            Destroy(gameObject);
        }
    }
}