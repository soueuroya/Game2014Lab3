using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    BulletManagerScript bms;
    public Rigidbody2D rb;
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        bms = GameObject.Find("BulletManager").GetComponent<BulletManagerScript>();
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.position += (gameObject.transform.up) * speed;

        if (gameObject.transform.position.y > 5 || gameObject.transform.position.y < -5)
        {
            bms.ReturnPlayerBullet(gameObject);
        }
    }
}
