using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using static TextGenerator;

public class SelectOptionSystem : MonoBehaviour
{
    
    public  GameObject[] buttoms;

    [Header("Buttoms Placement")]
    [SerializeField] bool IsVertical;
    [SerializeField] bool IsHorizontal;

    [Header("Type Event")]
    [SerializeField] bool UnityEventEnable;
    public UnityEvent[] UnityInteractEvent;
    public UnityEvent BlockSelectet;

    public delegate void InteractEventDelegate();
    public static event InteractEventDelegate EventInteract;

    private int _choiseninde;
    private bool _selected;
    private bool ChoisenSelect;
    public int choisenindex
    {
        get { return _choiseninde; }
        set { _choiseninde = Mathf.Clamp(value, 0, buttoms.Length - 1); }
    }
 

    private void Start()
    {
        choisenindex = 0;
        ChangeColor(Color.red);
        if (UnityEventEnable && buttoms.Length != UnityInteractEvent.Length) 
        {
            Debug.LogError("Buttoms and Unity Event Length must be same");
        }
        

    }

    void Update()
    {
        if (IsVertical)
        {
            MoveSelectVertical();
          
        }

        if (IsHorizontal)
        {
            MoveSelectHorizontal();
        }

        if (buttoms == null)
        {
            Debug.LogWarning(buttoms.ToString() + "Buttoms  Array Is Epmty!! ");

        }
       


    }
    private void MoveSelectHorizontal()
    {
        if (!_selected && Input.GetKeyDown(KeyCode.LeftArrow))
        {
            ChangeColor(Color.white);
            choisenindex--;
            ChangeColor(Color.red);

        }
        if (!_selected && Input.GetKeyDown(KeyCode.RightArrow))
        {
            ChangeColor(Color.white);
            choisenindex++;
            ChangeColor(Color.red);
        }
        SelectChoice();
    }
    private void MoveSelectVertical()
    {
        if (!_selected && Input.GetKeyDown(KeyCode.UpArrow))
        {
            ChangeColor(Color.white);
            choisenindex--;
            ChangeColor(Color.red);

        }
        if (!_selected && Input.GetKeyDown(KeyCode.DownArrow))
        {
            ChangeColor(Color.white);
            choisenindex++;
            ChangeColor(Color.red);
        }
        if (!_selected && Input.GetKeyDown(KeyCode.LeftArrow))
        {
            ChangeColor(Color.white);
            if (choisenindex >= Mathf.CeilToInt(buttoms.Length / 2))
            {
                choisenindex -= Mathf.FloorToInt(buttoms.Length / 2);

                
              
            }

            ChangeColor(Color.red);

        }
        if (!_selected && Input.GetKeyDown(KeyCode.RightArrow))
        {
            ChangeColor(Color.white);
            if (choisenindex < Mathf.CeilToInt(buttoms.Length / 2))
            {
                choisenindex += Mathf.FloorToInt(buttoms.Length / 2);
            }
            ChangeColor(Color.red);

        }
        SelectChoice();


        //Debug.Log(choisenindex);
    }
    private void SelectChoice()
    {
        if (!ChoisenSelect && Input.GetKeyDown(KeyCode.C))
        {
          //  Debug.Log("Interact");
            //Select butom ON
            ChoisenSelect = true;
            Interact();
        }
        if (ChoisenSelect && Input.GetKeyDown(KeyCode.X))
        {
            //Select butom OFF
           // Debug.Log("disable interact");

            ChoisenSelect = false;
            Interact();
        }
    }
    private void Interact()
    {
        ChangeColor(Color.yellow);
        SelectedButtom(choisenindex);
        if (UnityEventEnable)
        {
            UnityInteractEvent[choisenindex]?.Invoke();
            
        }
        else
        {
            EventInteract?.Invoke();
        }
        

    }
    public void BlockSelected()
    {

    }

    private void SelectedButtom(int indexbuttom)
    {
        // i forgot what this code do.xpp.

        if (_selected)
        {
          
            _selected = false;
            ChangeColor(Color.red);

        }
        else
        {

            _selected = true;
        }

    }

    private void ChangeColor(Color colored)
    {

        buttoms[choisenindex].gameObject.GetComponent<Image>().color = colored;
    }


}
