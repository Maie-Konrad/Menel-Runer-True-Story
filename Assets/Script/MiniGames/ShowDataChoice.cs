using TMPro;
using UnityEngine;

public class ShowDataChoice : MonoBehaviour
{

    SelectOptionSystem SoSystem;

    [SerializeField] GameObject[] gameObjects;
    [SerializeField] GameObject MenegaerObject;


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

        for (int i = 0; i < gameObjects.Length; i++)
        {
            gameObjects[i].SetActive(false);
        }

       
    }
    public void ChoiceBehaviur()
    {
      

            if (gameObjects[SoSystem.choisenindex].activeSelf)
            {

                gameObjects[SoSystem.choisenindex].SetActive(false);
                MenegaerObject.SetActive(false);

            }
            else
            {
                gameObjects[SoSystem.choisenindex].SetActive(true);
                MenegaerObject.SetActive(true);

            }
        

    }

}
