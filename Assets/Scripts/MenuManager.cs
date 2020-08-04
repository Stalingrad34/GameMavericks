using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private Image mainMenu = null;
    [SerializeField] private Image levelsMenu = null;


    private void Start()
    {
        Screen.orientation = ScreenOrientation.Portrait;
        mainMenu.gameObject.SetActive(true);
        levelsMenu.gameObject.SetActive(false);
    }

    public void NewGame()
    {
        PlayerPrefs.DeleteAll();
        PlayerPrefs.SetInt("Level0", 1);
        PlayerPrefs.SetInt("CurrentLevel", 0);
        SceneManager.LoadScene(1);
    }

    public void Levels()
    {
        mainMenu.gameObject.SetActive(false);
        levelsMenu.gameObject.SetActive(true);
    }

    
}
