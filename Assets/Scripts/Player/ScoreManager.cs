using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public int score;
    public TMP_Text scoreText;
    
    public static ScoreManager instance;

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

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (score < 0)
        {
            score = 0;
        }

        scoreText.text = "Score: " + score;
    }

    /// <summary>
    /// This will add points to the score
    /// </summary>
    public void UpdateScore(int pointsToAdd) {
        score += pointsToAdd;
    }

    /// <summary>
    /// This will reset score points to 0 if needs later
    /// </summary>
    public void ResetScore() {
        score = 0;
    }
    
}
