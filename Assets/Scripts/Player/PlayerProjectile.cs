using System;
using UnityEngine;

public class PlayerProjectile : MonoBehaviour
{
    public float speed;

    private void Start() {
        
    }

    private void Update() {
        
    }
    
    private void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Enemy"))
        {
            //player.TakeDamage(4f);
            gameObject.SetActive(false);
        }
    }
}
