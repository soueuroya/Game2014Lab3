using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputScript : MonoBehaviour
{
    public GameManager gm;
    public BulletManagerScript bms;
    public Transform bulletSpawnPoint;

    public List<GameObject> weapons;
    public float turningSpeed;

    public Animator anim;
    public Animator FLTL, FLTR;

    public bool turningR, turningL;
    public float fireRate = 0.3f;
    public float fireTimer = 0;

    void Update()
    {
        ReadInput();
    }

    void ReadInput()
    {
        if (fireTimer > 0)
        {
            fireTimer -= Time.deltaTime;
        }

        if (Input.GetKeyDown(KeyCode.Escape)) // When player presses Escape
        {
            gm.TogglePause();
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            TurnRight();
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            TurnLeft();
        }

        if (Input.GetKeyUp(KeyCode.RightArrow))
        {
            turningR = false;
        }
        else if (Input.GetKeyUp(KeyCode.LeftArrow))
        {
            turningL = false;
        }

        if (Input.GetKey(KeyCode.Space))
        {
            Shoot();
        }

        UpdateAnimationVariables();
    }

    void UpdateAnimationVariables()
    {
        FLTR.SetBool("Flamming", turningL);
        FLTL.SetBool("Flamming", turningR);
    }

    void TurnLeft()
    {
        turningL = true;
        if (gameObject.transform.localEulerAngles.z < 220)
        {
            gameObject.transform.Rotate(Vector3.forward * turningSpeed * Time.deltaTime);
        }
    }

    void TurnRight()
    {
        turningR = true;
        if (gameObject.transform.localEulerAngles.z > 140)
        {
            gameObject.transform.Rotate(-Vector3.forward * turningSpeed * Time.deltaTime);
        }
    }

    void Shoot()
    {
        if (fireTimer <= 0)
        {
            fireTimer = fireRate;
            bms.GetPlayerBullet(bulletSpawnPoint);
        }
    }

}
