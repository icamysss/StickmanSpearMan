using System.Collections;
using UnityEngine;

public class SpearTImeScale : MonoBehaviour
{
    public float distance = 2f;
    public string plTag = "Player";
    public LayerMask layerMask;
    public float timeScale = 0.1f;

    // Получаем позицию рейкаста
    Vector3 raycastOrigin;
    Vector3 raycastDirection;// Направление рейкаста вниз

    private void Update()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {

    }
    private void OnTriggerEnter(Collider other)
    {
        ////if (other.gameObject.name == "mixamorig:Hips")      // ????? ? ?????
        ////{
        ////  StartCoroutine(SetTimeScale(0.5f, 2));
        ////}
        //////else if (other.gameObject.name == "mixamorig:Spine1") // ????? ? ?????
        //////{
        //////    StartCoroutine(SetTimeScale(0.3f, 2));
        //////}
        ////else
        //if (other.gameObject.name == "mixamorig:Head") // ???? ????? ? ??????
        //{
        //    StartCoroutine(SetTimeScale(0.1f, 2));
        //}
    }


    IEnumerator SetTimeScale(float scale, float wait)
    {
        Time.timeScale = scale;

        yield return new WaitForSeconds(wait);

        Time.timeScale = 1;
    }
}
