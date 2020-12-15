using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    public Transform bulletSpawn;
    public GameObject bullet;
    public int fireRate;


    public BulletManager bulletManager;
    public CollisionManager collisionManager;

    void start()
    {
        collisionManager.GetComponent<Check>
    }

    // Update is called once per frame
    void Update()
    {
        _Fire();
        _FloorCollide();
    }

    private void _Fire()
    {
        if (Input.GetAxisRaw("Fire1") > 0.0f)
        {
            // delays firing
            if (Time.frameCount % fireRate == 0)
            {
                var tempBullet = Instantiate(bullet, bulletSpawn.position, Quaternion.identity);
                tempBullet.GetComponent<BulletBehaviour>().direction = bulletSpawn.forward;

                tempBullet.transform.SetParent(bulletManager.gameObject.transform);
            }

        }
    }

    private void _FloorCollide()
    {
        
    }
}
