using UnityEngine;

public class LevelManager : MonoBehaviour
{
    //Respawn point
    public GameObject currentCheckpoint;

    private PlayerController2D player;
    
    public static LevelManager instance;
    
    private void Awake() {
        
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }
    
    // Start is called before the first frame update
    void Start() {
        player = FindObjectOfType<PlayerController2D>();
    }

    public void RespawnPlayer() 
    {
        print("Player Respawn");
        player.healthCurrent = 100;
        player.transform.position = currentCheckpoint.transform.position;
        HudDisplay.instance.lifeSlots[player.lifeCount].gameObject.SetActive(true);
    }
}
