using NUnit.Framework.Interfaces;
using TMPro;
using UnityEngine;

public class DefultText : MonoBehaviour
{

    TextGenerator textGenerator;

    SelectOptionSystem SoSystem;


    [TextArea(3, 10)][SerializeField] string TestTextToMessage;
    [SerializeField] GameObject Defultstate;
    [SerializeField] TextMeshProUGUI defultText;

    private bool Generate;
    private bool TypingText;

    private void OnEnable()
    {
        SelectOptionSystem.EventInteract += Defualt;
    }
    private void OnDisable()
    {
        SelectOptionSystem.EventInteract -= Defualt;
    }
    void Start()
    {
        SoSystem = GetComponent<SelectOptionSystem>();
        Generate = true;
        TypingText = true;
        Defualt();
        textGenerator = GetComponent<TextGenerator>();
    }
    private void Update()
    {
        GenerateTextdefult();
    }
    public void Defualt()
    {
        if (Defultstate != null)
        {

            if (Generate)
            {
                Defultstate.SetActive(true);
                TypingText = true ;
                Generate = false;
            }
            else
            {
                Defultstate.SetActive(false);
                TypingText = false;
                Generate = true;
            }

        }
        else
        {
            Debug.LogWarning("GameObejcect DefultText is not assigned in inspektor" + gameObject.name);
        }



    }
    private void GenerateTextdefult()
    {

         defultText.text = textGenerator.GenerateText(TestTextToMessage, 0.05f, TypingText);


    }
}
