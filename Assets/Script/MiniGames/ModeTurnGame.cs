using UnityEngine;

public class ModeTurnGame : MonoBehaviour
{
    public Vector3 ReferenceChoice = new Vector3();
    public float timechange;

    public bool fightmode;
    void Update()
    {
        if (fightmode)
        {
            Area2Choice();
        }
    }
    private void Area2Choice()
    {

        

    }
}
