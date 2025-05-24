using UnityEngine;

public class GizmozTestingOk : MonoBehaviour
{
    public GameObject TargetGizmos;
    public GameObject Targeting;
    Vector3 mouseposition;
    Vector3 worldPostion;
    Collider2D jej;

    [SerializeField]Transform[] targetTranssform;
    private void Start()
    {
       Collider2D jej = GetComponent<Collider2D>();
    }
    private void Update()
    {
        Vector3 mousePosition = Input.mousePosition;
        worldPostion = Camera.main.ScreenToWorldPoint(mousePosition);
        
      
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;

        Gizmos.DrawLine(TargetGizmos.transform.position, worldPostion);

        for (int i = 0; i < targetTranssform.Length; i++)
        {
            if (targetTranssform[i +1] != null)
            {

                Gizmos.DrawLine(targetTranssform[i].position, targetTranssform[i + 1].position);
            }

          
        }

        
    
    }
}
