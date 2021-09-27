using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public float Speed = 5f;
    public float MaxSpeed = 10f;
    public float Acceleration = 0.01f;
    public Rigidbody2D Rb;
    public Vector3 StartPosition;

    private float currentSpeed;

    // Start is called before the first frame update
    void Start()
    {
        StartPosition = transform.position;
        Launch();
    }

     // Update is called once per frame
    void FixedUpdate()
    {
        if (currentSpeed < MaxSpeed)
        {
            currentSpeed += Acceleration;
            Rb.velocity = Rb.velocity.normalized * currentSpeed;
        }
    }

    public void Reset()
    {
        Rb.velocity = Vector2.zero;
        currentSpeed = Speed;
        transform.position = StartPosition;
        Launch();
    }

    private void Launch()
    {
        float x = Random.Range(0, 2) == 0 ? -1 : 1;
        float y = Random.Range(0, 2) == 0 ? -1 : 1;
        Rb.velocity = new Vector2(Speed * x, Speed * y);
    }
}
