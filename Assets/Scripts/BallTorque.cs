using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallTorque : MonoBehaviour
{
    private Rigidbody2D rb2d;
    private SurfaceEffector2D surfaceEffector2D;
    float torqueAmount = 10f;
    [SerializeField] float boostAmount = 30f;
    [SerializeField] float baseAmount = 10f;

    bool canMove = true;
    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        surfaceEffector2D = FindObjectOfType<SurfaceEffector2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (canMove)
        {
            MovePlayer();
            BoostPlayer();
        }

    }
    public void StopMovement()
    {
        canMove = false;
    }

    private void BoostPlayer()
    {
        if (Input.GetKey(KeyCode.W))
        {
            surfaceEffector2D.speed = boostAmount;
        }
        else
        {
            surfaceEffector2D.speed = baseAmount;
        }

    }

    private void MovePlayer()
    {
        if (Input.GetKey(KeyCode.D))
        {
            rb2d.AddTorque(-torqueAmount);
        }
        else if (Input.GetKey(KeyCode.A))
        {
            rb2d.AddTorque(torqueAmount);
        }
    }
}
