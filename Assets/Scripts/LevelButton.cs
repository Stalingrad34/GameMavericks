using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelButton : MonoBehaviour
{
    public void StartLevel(int levelNumber)
    {
        int tmp = PlayerPrefs.GetInt($"Level{levelNumber}");
        if (tmp > 0)
        {
            PlayerPrefs.SetInt("CurrentLevel", levelNumber);
            SceneManager.LoadScene(1);
        }
    }
}
