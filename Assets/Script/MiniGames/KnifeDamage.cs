using UnityEngine;
using UnityEngine.Events;

public class KnifeDamage : MonoBehaviour
{
    public UnityEvent GetDamage;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("działacollider");
            GetDamage.Invoke();
        }
        
    }
}
