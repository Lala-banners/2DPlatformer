using UnityEngine;

public class ActivateBossFight : MonoBehaviour
{
    [Header("Boss Music and Ambience")]
    public AudioSource bossMusic;
    public AudioSource bossAlarm;

    private void OnCollisionStay2D(Collision2D other) {
        if (other.collider.gameObject.CompareTag("Player"))
        {
            bossAlarm.Play();
        }
    }
}
