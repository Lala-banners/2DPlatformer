using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other) {
        if (other.name.Equals("Detective"))
        {
            LevelManager.instance.currentCheckpoint = gameObject;
            print("Activate Checkpoint" + transform.position);
        }
    }
}
