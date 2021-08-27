using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Header("Enemy Stats")]
    public float attackDist;
    public Transform player;

    [Header("Enemy Shooting")] 
    private float timeBtwShots;
    public float startTimeBtwShots;

    public int enemyHealth;
    public int pointsOnDeath;
    public GameObject deathEffect;

    // Start is called before the first frame update
    void Awake() {
        player = FindObjectOfType<PlayerController2D>().transform;
        timeBtwShots = startTimeBtwShots;
    }

    private void Update() {

        if (enemyHealth <= 0)
        {
            print("Enemy Dead");
            StopAllCoroutines();
            Instantiate(deathEffect, transform.position, transform.rotation);
            ScoreManager.instance.UpdateScore(pointsOnDeath);
            gameObject.SetActive(false);
        }
        
        if (timeBtwShots <= 0)
        {
            //Spawn projectile
            GameObject projectile = Pool.instance.GetPooledObject("Projectile");
            if (Vector2.Distance(transform.position, player.transform.position) < attackDist)
            {
                projectile.transform.position = Pool.instance.spawnPos.transform.position;
                projectile.transform.rotation = Pool.instance.spawnPos.transform.rotation;
                projectile.SetActive(true);
            }

            timeBtwShots = startTimeBtwShots;
        }
        else
        {
            timeBtwShots -= Time.deltaTime;
        }
    }

    public void EnemyTakeDmg(int damage) {
        enemyHealth -= damage;
    }
}