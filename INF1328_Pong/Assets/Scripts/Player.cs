using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public bool IsPlayer1;
    public float Speed;
    public Rigidbody2D Rb;
    public Vector2 StartPosition;

    private float movement;

    // Start is called before the first frame update
    void Start()
    {
        StartPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (IsPlayer1)
        {
            movement = Input.GetAxisRaw("Vertical_P1");
        }
        else
        {
            movement = Input.GetAxisRaw("Vertical_P2");
        }

        Rb.velocity = new Vector2(Rb.velocity.x, movement * Speed);
    }

    public void Reset()
    {
        Rb.velocity = Vector2.zero;
        transform.position = StartPosition;
    }
}
