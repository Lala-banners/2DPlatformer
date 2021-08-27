using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    public int speed;
    public int damage = 40;
    public GameObject impactEffect;

    // Update is called once per frame
    void Update() {
        transform.position += transform.right * Time.deltaTime * speed;
    }

    private void OnCollisionEnter2D(Collision2D other) {

        if (other.gameObject.TryGetComponent(out Enemy enemy))
        {
            if (enemy != null)
            {
                print("Enemy Hit & Taking Damage");
                Instantiate(impactEffect, transform.position, transform.rotation);
                enemy.EnemyTakeDmg(damage);
                gameObject.SetActive(false);
            }
            else
            {
                print("Enemy Not in scene");
            }
        }
        else
        {
            print("Enemy Not Colliding");
        }
    }
}