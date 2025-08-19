using TMPro;
using UnityEngine;

public class TestChoice : MonoBehaviour
{
    SelectOptionSystem SoSystem;
    TextGenerator textGenerator;


    [SerializeField]GameObject[] gameObjects;
    [SerializeField] GameObject Defultstate;


    [SerializeField]TextMeshProUGUI DefultText;
    [TextArea(3, 10)][SerializeField] string TestTextToMessage;

    private bool Generate;
    private void OnEnable()
    {
        SelectOptionSystem.EventInteract += ChoiceBehaviur;
    }
    private void OnDisable()
    {
        SelectOptionSystem.EventInteract -= ChoiceBehaviur;
    }
    private void Start()
    {
        SoSystem = GetComponent<SelectOptionSystem>();
        textGenerator = GetComponent<TextGenerator>();
        Generate = true;
        Defualt(true);

    }
    private void Update()
    {

        GenerateTextdefult();
    }
    public void Defualt(bool StateDefult)
    {

        Defultstate.SetActive(StateDefult);
    }
    public void ChoiceBehaviur()
    {
        if (gameObjects[SoSystem.choisenindex].activeSelf)
        {
            Defualt(true);
            gameObjects[SoSystem.choisenindex].SetActive(false);
            Generate = true;

        }
        else
        {
            gameObjects[SoSystem.choisenindex].SetActive(true);
            Defualt(false);
            Generate = false;
        }

    }
    private void GenerateTextdefult()
    {

        DefultText.text = textGenerator.GenerateText(TestTextToMessage, 0.05f, Generate);

    }   
}
