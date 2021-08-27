using System.Collections;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Header("Enemy Stats")] public float speed;
    public float attackDist;
    public Transform player;
    public Vector2 pointA;
    public Vector2 pointB;

    [Header("Enemy Shooting")] 
    private float timeBtwShots;
    public float startTimeBtwShots;

    // Start is called before the first frame update
    void Awake() {
        player = FindObjectOfType<PlayerController2D>().transform;
        timeBtwShots = startTimeBtwShots;
    }

    private void Update() {
        
        if (timeBtwShots <= 0 && Vector2.Distance(transform.position, player.transform.position) < attackDist)
        {
            //Spawn projectile
            GameObject projectile = Pool.instance.GetPooledObject("Projectile");
            if (projectile != null)
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

    IEnumerator Start() {
        pointA = transform.position;

        while (true)
        {
            yield return StartCoroutine(Move(transform, pointA, pointB, 5.0f));
            yield return StartCoroutine(Move(transform, pointB, pointA, 5.0f));
        }
    }

    private IEnumerator Move(Transform thisT, Vector3 startPos, Vector3 endPos, float time) {
        float index = 0.0f;
        float rate = 1.0f / time;

        while (index < 1.0f)
        {
            index += Time.deltaTime * rate;
            thisT.position = Vector3.Lerp(startPos, endPos, index);
            yield return null;
        }
    }
}