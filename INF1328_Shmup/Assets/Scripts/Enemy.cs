using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    Rigidbody2D rb;

    public float xSpeed;
    public float ySpeed;
    public bool canShoot;
    public float fireRate;
    public int health;

    public GameObject projectile;

    public void Damage()
    {
        health--;

        if (health == 0)
            Die();
    }

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        if (canShoot)
        {
            fireRate += Random.Range(fireRate / -2, fireRate / 2);
            InvokeRepeating("Shoot", fireRate, fireRate);
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rb.velocity = new Vector2(xSpeed, ySpeed * -1);
    }

    private void Shoot()
    {
        GameObject temp = (GameObject)Instantiate(projectile, transform.position, Quaternion.identity);
        temp.GetComponent<Projectile>().ChangeDirection();
    }

    private void Die()
    {
        Destroy(gameObject);
    }
}
