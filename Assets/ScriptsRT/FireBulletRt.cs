using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBulletRt : MonoBehaviour
{
    public float fireSpeed;
    public float shotCounter;
    public float TimebetweenShots;
    public GameObject Bullet;
    public Transform firePoint;

    public bool right, left, up, down;

    private void Awake()
    {
        var bullet = Instantiate(Bullet, firePoint.position, firePoint.rotation);
        Rigidbody2D bulletRb = bullet.GetComponent<Rigidbody2D>();
        bulletRb.AddForce(Vector2.right * fireSpeed, ForceMode2D.Impulse);

    }
    void Start()
    {
        firePoint = GetComponent<Transform>();
        shotCounter = TimebetweenShots;
    }

    // Update is called once per frame
    void Update()
    {
        shotCounter -= Time.deltaTime;
        if(shotCounter <= 0)
        {
            shotCounter = TimebetweenShots;
           var bullet= Instantiate(Bullet, firePoint.position, firePoint.rotation);
          // Rigidbody2D bulletRb = bullet.GetComponent<Rigidbody2D>();
           // bulletRb.AddForce(Vector2.left * fireSpeed, ForceMode2D.Impulse);

            //if (right)
            //{
            //    bulletRb.AddForce(Vector2.right * fireSpeed, ForceMode2D.Impulse);
            //}

            //if (left)
            //{
            //    bulletRb.AddForce(Vector2.left * fireSpeed, ForceMode2D.Impulse);
            //}

            //if (up)
            //{
            //    bulletRb.AddForce(Vector2.up * fireSpeed, ForceMode2D.Impulse);
            //}

            //if (down)
            //{
            //    bulletRb.AddForce(Vector2.down * fireSpeed, ForceMode2D.Impulse);
            //}

        }


    }
}
