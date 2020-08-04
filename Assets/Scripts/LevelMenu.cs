using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelMenu : MonoBehaviour
{
    [SerializeField] private Image[] levels = null;
    [SerializeField] private Sprite[] spriteLevels = null;

    private void OnEnable()
    {
        for (int i = 0; i < levels.Length; i++)
        {
            int stateLevel = PlayerPrefs.GetInt($"Level{i}", 0);

            if (stateLevel == 1)
            {
                levels[i].sprite = spriteLevels[0];
            }
            else if (stateLevel == 2)
            {
                levels[i].sprite = spriteLevels[1];
            }
        }
    }
}
