using UnityEngine;

public class Pickup : MonoBehaviour
{
    public int pointsToAdd;

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.GetComponent<PlayerController2D>() == null)
            return;
        
        ScoreManager.instance.UpdateScore(pointsToAdd);
        gameObject.SetActive(false);
    }
}
