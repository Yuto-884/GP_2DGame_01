using UnityEngine;

public class CameraMove : MonoBehaviour
{
    public Transform target;

    public float minX;
    public float maxX;

    Camera cam;
    float halfWidth;

    void Start()
    {
        cam = Camera.main;

        halfWidth =
            cam.orthographicSize *
            cam.aspect;
    }

    void Update()
    {
        float x = Mathf.Clamp(
            target.position.x,
            minX + halfWidth,
            maxX - halfWidth
        );

        transform.position = new Vector3(
            x,
            transform.position.y,
            -10
        );
    }
}