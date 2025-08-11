using System.Collections;
using UnityEngine;

public class PlayerBehaviurInKillerFish : MonoBehaviour
{
    [SerializeField]int MaxHP;
    [SerializeField] float GetDamageCooldownTime;

    private void Update()
    {
        if (MaxHP <= 0)
        {
            Debug.Log("DEd");
        }
    }
    public void GetDamage(int  damage)
    {
        MaxHP = MaxHP - damage;
        Debug.Log("GetDamage :   " + damage);
    }

  
}
