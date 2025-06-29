using System.Collections.Generic;
using UnityEngine;

public class BackgroundManager : MonoBehaviour
{
    public List<GameObject> themes; // Przeci�gnij prefaby motyw�w
    public float themeDuration = 30f; // Czas na motyw (sekundy)
    private int currentThemeIndex = 0;
    private float timer;

    void Start()
    {
        LoadTheme(0); // Zacznij od pierwszego motywu
    }

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= themeDuration)
        {
            timer = 0f;
            ChangeTheme();
        }
    }

    void ChangeTheme()
    {
        // Wy��cz stary motyw
        themes[currentThemeIndex].SetActive(false);

        // Losuj nowy (lub sekwencyjnie)
        currentThemeIndex = (currentThemeIndex + 1) % themes.Count;

        // W��cz nowy motyw
        themes[currentThemeIndex].SetActive(true);
    }

    void LoadTheme(int index)
    {
        foreach (var theme in themes)
            theme.SetActive(false);

        themes[index].SetActive(true);
    }

}
