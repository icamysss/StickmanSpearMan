using UnityEngine;

public class CameraRect : MonoBehaviour
{
    [SerializeField] Camera _cam;

    [SerializeField] float xmin = 0;
    [SerializeField] float ymin = 0;
    [SerializeField] float xmax = 0.2f;
    [SerializeField] float ymax = 0.4f;
    void Update()
    {
        _cam.rect = Rect.MinMaxRect(xmin, ymin, xmax, ymax);
    }
}
