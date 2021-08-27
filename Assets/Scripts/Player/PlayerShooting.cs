using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public Transform firePoint;
    
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            Shoot();
        }
    }

    public void Shoot() {
        //Spawn projectile
        GameObject playerBullet = Pool.instance.GetPooledObject("PlayerBullet");
        if (playerBullet != null)
        {
            playerBullet.transform.position = firePoint.transform.position;
            playerBullet.transform.rotation = firePoint.transform.rotation;
            playerBullet.SetActive(true);
        }
    }
}
