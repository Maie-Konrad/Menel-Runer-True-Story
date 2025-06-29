using UnityEngine;

public class ParallaxLayer : MonoBehaviour
{
    public float parallaxSpeed;
    private Transform cameraTransform;
    private float startPosX;

    void Start()
    {
        cameraTransform = Camera.main.transform;
        startPosX = transform.position.x;
    }

    void FixedUpdate()
    {
        float distance = cameraTransform.position.x * parallaxSpeed;
        transform.position = new Vector3(startPosX + distance, transform.position.y, transform.position.z);
    }
}