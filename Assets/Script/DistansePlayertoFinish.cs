using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class DistansePlayertoFinish : MonoBehaviour
{
    [SerializeField] Transform Player;
    [SerializeField] Transform Metafinish;
    //[SerializeField] Transform Start;
    public Slider sliderdistanse;
    private float Distanse;

    private void Update()
    {
        
        Distanse = Player.transform.position.x / Metafinish.transform.position.x;
        sliderdistanse.value = Distanse;
    }
}
