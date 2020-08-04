using UnityEngine;
using UnityEngine.UI;

public class GameUI : MonoBehaviour
{   
    [SerializeField] private Text UIhp = null;
    [SerializeField] private Image winPanel = null;
    [SerializeField] private Image losePanel = null;
    [SerializeField] private Image pausePanel = null;
    [SerializeField] private AudioSource _audio = null;
    [SerializeField] private AudioClip winMusic = null;
    [SerializeField] private AudioClip loseMusic = null;
    private int playerHP = 0;
    private bool isPaused = false;
    public Text UIcounterEnemy = null;

    private void Awake()
    {
        _audio = GetComponent<AudioSource>();
        Messenger.AddListener("HIT", HitToPlayer);
    }

    private void Start()
    {
        winPanel.gameObject.SetActive(false);
        losePanel.gameObject.SetActive(false);
        pausePanel.gameObject.SetActive(false);
    }

    private void HitToPlayer()
    {
        playerHP--;
        UIhp.text = playerHP.ToString();
    }

    public void LoadPlayerInfo(PlayerShipData playerData)
    {
        playerHP = playerData.Health;
        UIhp.text = playerHP.ToString();
    }


    public void Win()
    {
        _audio.PlayOneShot(winMusic);
        winPanel.gameObject.SetActive(true);
    }

    public void Lose()
    {
        _audio.PlayOneShot(loseMusic);
        losePanel.gameObject.SetActive(false);
    }

    public void Pause()
    {
        isPaused = !isPaused;
        if (isPaused)
        {
            Time.timeScale = 0.001f;
            pausePanel.gameObject.SetActive(true);
        }
        else
        {
            Time.timeScale = 1.0f;
            pausePanel.gameObject.SetActive(false);
        }
    }

    private void OnDestroy()
    {
        Messenger.RemoveListener("HIT", HitToPlayer);
    }


}
