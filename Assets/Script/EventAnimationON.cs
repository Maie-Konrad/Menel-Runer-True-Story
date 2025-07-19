using UnityEngine;

public class EventAnimationON : MonoBehaviour
{
    [SerializeField]Animator animatorfromZZZ;
    [SerializeField] AudioSource MenelAuuuaa;

    public bool wakeupanimationover  = false;


    public delegate void AnimationMenelWakeUpIsOver();
    public static AnimationMenelWakeUpIsOver AnimationisOver;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void AnimationZZZisfalse()
    {
        animatorfromZZZ.enabled = false;
        MenelAuuuaa.enabled = true;
    }
    public void animationMenelWakeUpIsOver()
    {
        AnimationisOver();
        wakeupanimationover = true;

    }

}
