using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.Playables;

public class GameMenager : MonoBehaviour
{
    [Header("Game over Reference")]
    [SerializeField] GameObject ObjectGameOver;
    public Animator timelinel;


    [Header("Activation Game Reference")]
    public bool GameStarted;
    public GameObject CutSceneTimeLine;
    public GameObject startbuttom;

    public  delegate void TriggerTimernow();
    public static TriggerTimernow TriggerTimer;

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
    private void Start()
    {
      
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
        Timer.timehasbeenexceeded += GameiSOver;
    }
    public void GameStatus()
    {
        CutSceneTimeLine.gameObject.SetActive(true);
        startbuttom.gameObject.SetActive(false);

        
        StartCoroutine(coluddownintro());
        
        
    }
    public bool GameBeenStarted()
    {
        
        return GameStarted;
       
    }
 

    private void GameiSOver()
    {
        Time.timeScale = 0;
        ObjectGameOver.SetActive(true);
        Debug.Log("GameOver times up");
    }

    IEnumerator coluddownintro()
    {
        yield return new WaitForSeconds(4f);
        timelinel.enabled = true;
        GameStarted = true;
        TriggerTimer();
    }
}
