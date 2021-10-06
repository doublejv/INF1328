using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int health;
    public float speed;
    public int fireRate;

    public GameObject projectile;

    private Rigidbody2D rb;
    private GameObject cannon;
    private int projectileDelay = 0;

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
        cannon = transform.Find("Cannon").gameObject;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rb.AddForce(new Vector2(Input.GetAxis("Horizontal") * speed, 0));
        rb.AddForce(new Vector2(0, Input.GetAxis("Vertical") * speed));

        if (Input.GetButton("Fire1") && projectileDelay > fireRate)
        {
            Shoot();
        }

        projectileDelay++;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            Damage();

            collision.gameObject.GetComponent<Enemy>().Damage();
        }
    }

    private void Shoot()
    {
        projectileDelay = 0;
        Instantiate(projectile, cannon.transform.position, Quaternion.identity);
    }

    private void Die()
    {
        Destroy(gameObject);
    }
}
