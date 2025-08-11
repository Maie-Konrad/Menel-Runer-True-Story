using TMPro;
using UnityEngine;

public class SecondScriptITest : MonoBehaviour
{
    // OBIEKT REAGUJ¥CY NA POSTAÆ
    [SerializeField]TextMeshProUGUI textMeshProUGUI;
    SpriteRenderer squaree = new SpriteRenderer();
    private void Awake()
    {
      
        squaree = GetComponent<SpriteRenderer>();
    }
    private void OnEnable()
    {
        ScriptITestput.PressSpace += Somethink;
        ScriptITestput.GetDamege += countSometnk;
    }
    private void OnDisable()
    {
        ScriptITestput.PressSpace -= Somethink;
    }
    private void Somethink()
    {
        squaree.color = Color.red;
    }
    private void countSometnk(int yes)
    {
        yes = yes - 10;
        textMeshProUGUI.text = yes.ToString();
    }
}
