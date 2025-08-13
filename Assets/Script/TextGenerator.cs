using System.Collections;
using TMPro;
using UnityEngine;

public class TextGenerator : MonoBehaviour
{

    public delegate int ChoisenSelection();
    


    [SerializeField] TextMeshProUGUI TextToDisplay;
    [SerializeField]float appearsCharSpeed;
    [TextArea(3, 10)]
    [SerializeField]string textToMessege;

    private bool coruntineIsRun = false;
    private void Start()
    {
        TextToDisplay.text = "";
        textToMessege.ToCharArray();
       
    }

    private void Update()
    {
       
        if (!coruntineIsRun)
        {
            coruntineIsRun = true;
            StartCoroutine(enumerator());
        }
   

    }
    
    IEnumerator enumerator()
    {
        for (int i = 0; i < textToMessege.Length; i++)
        {
            TextToDisplay.text += textToMessege[i];
         
            yield return new WaitForSeconds(appearsCharSpeed);

        }

       
    }
}
