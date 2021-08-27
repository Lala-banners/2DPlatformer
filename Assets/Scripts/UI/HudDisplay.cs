using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HudDisplay : MonoBehaviour
{
    #region Variables
    [Header("Health")]
    [SerializeField] private Image[] heartSlots;
    [SerializeField] private Sprite[] hearts;
    private float healthPerSection;

    [Space] [Header("UI")] 
    public GameObject optionsMenu;
    public GameObject pauseMenu;
    public bool isPaused;
    public AudioSource pausedAudio;
    public AudioSource unPausedAudio;
    public GameObject gameOverMenu;
    public AudioSource gameOverMusic;
    public AudioSource backgroundMusic;
    public Button mainMenuButton, quitButton;
    
    [Space] 
    
    [Header("Score & Life Counter")]
    
    public Image[] lifeSlots;
    #endregion
    
    public static HudDisplay instance;

    private void Awake() {
        
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
            return;
        }
    }
    
    private void Start() {
        UnPaused();
        backgroundMusic.Play();
        backgroundMusic.loop = true;
    }

    private void Update() {
        PauseGame();
    }

    #region UpdateHearts
    /// <summary>
    /// Goes through each heart slot and calculates what should be be displayed based on current health.
    /// </summary>
    /// <param name="currentHealth">The current health of the player.</param>
    /// <param name="maxHealth">The max health of the player</param>
    public void UpdateHearts(float currentHealth, float maxHealth)
    {
        int heartSlotIndex = 0;

        healthPerSection = maxHealth / (heartSlots.Length * 4); //calculate how much health each heart slot quarter is worth

        foreach (Image heart in heartSlots)
        {
            if (currentHealth >= healthPerSection * 4 * (heartSlotIndex + 1)) //if current health fills this heart
            {
                heartSlots[heartSlotIndex].sprite = hearts[4]; //display full heart
            }
            else if (currentHealth >= healthPerSection * (4 * heartSlotIndex + 3)) //if current health reaches at least a 3/4 of the current heart
            {
                heartSlots[heartSlotIndex].sprite = hearts[3]; //display 3/4 heart
            }
            else if (currentHealth >= healthPerSection * (4 * heartSlotIndex + 2))
            {
                heartSlots[heartSlotIndex].sprite = hearts[2];
            }
            else if (currentHealth >= healthPerSection * (4 * heartSlotIndex + 1))
            {
                heartSlots[heartSlotIndex].sprite = hearts[1];
            }
            else
            {
                heartSlots[heartSlotIndex].sprite = hearts[0];
            }
            heartSlotIndex++;
        }
    }
    #endregion

    public void GameOver() {
        gameOverMenu.SetActive(true);
        Time.timeScale = 0;
        backgroundMusic.Stop();
        backgroundMusic.loop = false;
        gameOverMusic.Play();
        
        quitButton.onClick.AddListener(() => {
            OptionsManager.instance.QuitGame();
        });
        
        mainMenuButton.onClick.AddListener(() => {
            SceneManager.LoadScene(0);
        });
    }
    
    #region Score
    
    #endregion

    public void PauseGame() {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (optionsMenu.activeSelf)
            {
                pauseMenu.SetActive(true);
                optionsMenu.SetActive(false);
            }
            else
            {
                isPaused = !isPaused;
                if (isPaused)
                {
                    pausedAudio.Play();
                    Paused(pauseMenu);
                }
                else
                {
                    unPausedAudio.Play();
                    UnPaused();
                }
            }
        }
    }
    
    public void Paused(GameObject _panel) {
        isPaused = true;
        Time.timeScale = 0;
        pauseMenu.SetActive(false);
        _panel.SetActive(true);
    }

    public void UnPaused() {
        isPaused = false;
        Time.timeScale = 1;
        pauseMenu.SetActive(false);
    }
}

