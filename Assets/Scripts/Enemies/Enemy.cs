using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Header("Enemy Stats")] 
    public float attackDist;
    public int enemyHealth;
    public Transform player;

    [Header("Enemy Shooting")] 
    private float timeBtwShots;
    public float startTimeBtwShots;

    [Header("Enemy Death")]
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
            EnemyDie();
        }
    }

    public void Shoot() {
        if (Vector2.Distance(transform.position, player.transform.position) <= attackDist)
        {
            if (timeBtwShots <= 0)
            {
                //Spawn projectile
                GameObject projectile = Pool.instance.GetPooledObject("Projectile");
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

    public void EnemyDie() {
        StopAllCoroutines();
        Instantiate(deathEffect, transform.position, transform.rotation);
        ScoreManager.instance.UpdateScore(pointsOnDeath);
        gameObject.SetActive(false);
    }
}