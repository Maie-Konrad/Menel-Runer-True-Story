using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.Playables;

public class GameMenager : MonoBehaviour
{
    [Header("Game over Reference")]
    [SerializeField] GameObject ObjectGameOver;
    public Animator MenelAnimator;


    [Header("Activation Game Reference")]
    public bool GameStarted;
  
    public GameObject startbuttom;

    public  delegate void TriggerTimernow();
    public static TriggerTimernow TriggerTimer;


    private bool AnimationMenel = false;

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
       // EventAnimationON.AnimationisOver += AnimationisOverMenel;
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
        MenelAnimator.SetBool("GameIsStarted", true);
        yield return new WaitForSeconds(4f);
        GameStarted = true;
        TriggerTimer();

    }
    void AnimationisOverMenel()
    {
        AnimationMenel = true;
    }
}
