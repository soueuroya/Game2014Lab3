using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletManagerScript : MonoBehaviour
{
    public GameObject playerbullet;
    public GameObject enemybullet;
    public int maxBullets;
    private Queue<GameObject> m_playerBulletPool;
    private Queue<GameObject> m_enemyBulletPool;


    // Start is called before the first frame update
    void Start()
    {
        _BuildBulletPool();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void _BuildBulletPool()
    {
        m_playerBulletPool = new Queue<GameObject>();

        for (int count = 0; count < maxBullets; count++)
        {
            var tempBullet = Instantiate(playerbullet, gameObject.transform);
            tempBullet.SetActive(false);
            m_playerBulletPool.Enqueue(tempBullet);
        }
    }

    public GameObject GetPlayerBullet(Transform spawnPoint)
    {
        if (m_playerBulletPool.Count > 0)
        {
            var newBullet = m_playerBulletPool.Dequeue();
            newBullet.SetActive(true);
            newBullet.transform.position = spawnPoint.position;
            newBullet.transform.localRotation = spawnPoint.rotation;
            return newBullet;
        }
        return null;
    }

    public void ReturnPlayerBullet(GameObject returnedBullet)
    {
        returnedBullet.SetActive(false);
        m_playerBulletPool.Enqueue(returnedBullet);
    }

}
