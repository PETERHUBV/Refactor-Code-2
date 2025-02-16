using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class SpaceShooterManager : MonoBehaviour
{
    public GameObject bulletPrefab;
    
    public int poolSize = 10;        
    private Queue<GameObject> bulletPool = new Queue<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < poolSize; i++)
        {
            GameObject bullet = Instantiate(bulletPrefab);
            bullet.SetActive(false);
            bulletPool.Enqueue(bullet);
        }
    }
    public GameObject GetBullet(Transform bulletSpawnHere)
    {
        if (bulletPool.Count > 0)
        {
            GameObject bullet = bulletPool.Dequeue();
            bullet.SetActive(true);
            return bullet;
        }
        else
        {

            GameObject bullet = Instantiate(bulletPrefab);

            return bullet;
        }
    }

  
    public void ReturnBulletToPool(GameObject bullet)
    {
        bullet.SetActive(false);
        bulletPool.Enqueue(bullet);
    }

// Update is called once per frame
void Update()
    {
        
    }
}
