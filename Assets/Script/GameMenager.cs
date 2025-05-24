using TMPro;
using UnityEngine;

public class GameMenager : MonoBehaviour
{
    
    [Header("Activation Game Reference")]
    public bool GameStarted;
    public GameObject CutSceneTimeLine;
    public GameObject startbuttom;

    public static GameMenager Instance { get; private set; }
    private void Awake()
    {
        GameStarted = false;
    

        if (Instance != null && Instance != this)
        {
            Destroy(this.gameObject );
        }
        Instance = this;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Y))
        {
            Time.timeScale = 0;
        }
        if (Input.GetKeyDown(KeyCode.P))
        {
            Time.timeScale = 1;
        }
    }
    public void GameStatus()
    {
        CutSceneTimeLine.gameObject.SetActive(true);
        startbuttom.gameObject.SetActive(false);

        GameStarted = true;
    }
    public bool GameBeenStarted()
    {
        
        return GameStarted;
       
    }


}
