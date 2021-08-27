using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private PlayerController2D player;
    public float cameraDistance;
    
    // Start is called before the first frame update
    void Awake() {
        GetComponent<Camera>().orthographicSize = ((Screen.height / 2) / cameraDistance);
        player = FindObjectOfType<PlayerController2D>();
    }

    // Update is called once per frame
    void FixedUpdate() {
        if (player != null)
        {
            transform.position = new Vector3(player.transform.position.x, player.transform.position.y, transform.position.z);
        }
    }
}
