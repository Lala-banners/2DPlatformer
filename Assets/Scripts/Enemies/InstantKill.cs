using UnityEngine;

public class InstantKill : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.CompareTag("Player"))
        {
            HudDisplay.instance.GameOver();
        }
    }
}
