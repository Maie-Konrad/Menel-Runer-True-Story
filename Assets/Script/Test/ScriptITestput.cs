using Unity.VisualScripting;
using UnityEngine;
using System;
using UnityEngine.Events;

public class ScriptITestput : MonoBehaviour
{
    //POSTAÆ
    public delegate void Callback();
    public static Callback PressSpace;

    public static event Action<int> GetDamege;

    [SerializeField] int HP;
    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.Space))
        {
            PressSpace();

            GetDamege(HP);

        }

    }
  
}
