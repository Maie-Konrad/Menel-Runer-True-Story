using UnityEngine;

public class MenuGame : MonoBehaviour
{
    bool GameIsStarted;
    public GameObject gameobjectcanvas;

    private void Start()
    {
       
    }
    public void StartTheGame()
    {
        gameobjectcanvas.SetActive(false);
        Debug.Log("KURWA");
    }
}

