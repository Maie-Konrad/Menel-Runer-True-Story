using UnityEngine;

public class MovementPlayerInKillerFish : MonoBehaviour
{
    [SerializeField] float Speed;
    [SerializeField] Rigidbody2D Rigidbody2D;
    private void Start()
    {
        
    }
    void Update()
    {
        float MovementX = Input.GetAxis("Horizontal");
        float MovementY = Input.GetAxis("Vertical");

        //gameObject.transform.position += new Vector3(MovementX * Speed, MovementY * Speed);
        Rigidbody2D.linearVelocity  = new Vector3(MovementX * Speed, MovementY * Speed);
    }
}
