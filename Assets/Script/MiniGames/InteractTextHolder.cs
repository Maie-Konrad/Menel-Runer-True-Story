using System.Collections.Generic;
using System.Linq;
using Ink.Runtime;
using TMPro;
using UnityEngine;
using static SelectOptionSystem;

public class InteractTextHolder : MonoBehaviour
{
    [SerializeField] ButtomChoiceData[] ActChoice;
    [SerializeField] ButtomChoiceData[] ItemChoice;
    [SerializeField] ButtomChoiceData[] MercyChoice;

    [SerializeField] TextMeshProUGUI[] Textchoise;

    [SerializeField] TextMeshProUGUI testbuttom;

    private int aaa;
    TextGenerator TxtGenetor;

    public void testvoidlol()
    {
        Textchoise[0].text = ActChoice[0].TekstToDisplay;
    }
    //private void tete()
    //{

    //    for (int i = 0; i < Textchoise.Count(); i++)
    //    {

    //        for (int j = 0; j < ActChoice[0].TekstToDisplay.Length; j++)
    //        {
    //            testbuttom.text = TxtGenetor.GenerateText(ActChoice[0].TekstToDisplay, 0.1f);


    //        }

    //    }
       
    //}
}
