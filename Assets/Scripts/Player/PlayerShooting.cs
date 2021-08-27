using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    private float timeBtwShots;
    public float startTimeBtwShots;
    
    // Start is called before the first frame update
    void Start()
    {
        timeBtwShots = startTimeBtwShots;
    }

    // Update is called once per frame
    void Update()
    {
        if (timeBtwShots <= 0)
        {
            //Spawn projectile
            GameObject playerBullet = Pool.instance.GetPooledObject("PlayerBullet");
            if (playerBullet != null)
            {
                playerBullet.transform.position = Pool.instance.spawnPos.transform.position;
                playerBullet.transform.rotation = Pool.instance.spawnPos.transform.rotation;
                playerBullet.SetActive(true);
            }

            timeBtwShots = startTimeBtwShots;
        }
        else
        {
            timeBtwShots -= Time.deltaTime;
        }
    }
}
