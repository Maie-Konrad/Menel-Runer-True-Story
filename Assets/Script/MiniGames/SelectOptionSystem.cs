using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using static TextGenerator;

public class SelectOptionSystem : MonoBehaviour
{
    [SerializeField] GameObject[] buttoms;
    [SerializeField] bool IsVertical;
    [SerializeField] bool IsHorizontal;


    public delegate void ChoisenButtom();
    public static ChoisenButtom choisenButtom;



    private int _choiseninde;
    private bool _selected;
    public int choisenindex
    {
        get { return _choiseninde; }
        set { _choiseninde = Mathf.Clamp(value, 0, buttoms.Length - 1); }
    }

   
    private void Start()
    {
        choisenindex = 0;
        ChangeColor(Color.red);


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
            Debug.LogWarning(buttoms.ToString() + "  Array Is Epmty!! ");

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
            if (choisenindex > 2)
            {
                choisenindex -= 3;
            }

            ChangeColor(Color.red);

        }
        if (!_selected && Input.GetKeyDown(KeyCode.RightArrow))
        {
            ChangeColor(Color.white);
            if (choisenindex <= 2)
            {
                choisenindex += 3;
            }
            ChangeColor(Color.red);
        }
        SelectChoice();


        Debug.Log(choisenindex);
    }
    private void SelectChoice()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {

            ChangeColor(Color.yellow);
            SelectedButtom(choisenindex);
            choisenButtom();


        }
    }

    private void SelectedButtom(int indexbuttom)
    {
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
