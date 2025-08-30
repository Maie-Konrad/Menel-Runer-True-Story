using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EventMiniGame : MonoBehaviour
{
    [SerializeField] int sceneIndexToLoad;
   
    private void OnTriggerEnter2D(Collider2D collision)
    {
        SceneManager.LoadSceneAsync(sceneIndexToLoad);
    }
}
