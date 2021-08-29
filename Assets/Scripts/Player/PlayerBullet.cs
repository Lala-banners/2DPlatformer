using System;
using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    public int speed;
    public int damage = 40;
    public GameObject impactEffect;
    private Enemy enemy;

    private void Awake() {
        enemy = FindObjectOfType<Enemy>();
    }

    // Update is called once per frame
    void Update() {
        transform.position += transform.right * Time.deltaTime * speed;
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if (other.collider.gameObject == enemy)
        {
            print("Enemy Hit & Taking Damage");
            //Instantiate(impactEffect, transform.position, transform.rotation);
            //enemy.EnemyTakeDmg(damage);
            //gameObject.SetActive(false);
        }
    }
}