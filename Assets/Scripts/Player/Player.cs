using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Author: Jiefu Ling(jieful2)
// This script is used to control player's movement.

public class Player : MonoBehaviour
{

    public float Speed = 10f;

    private Rigidbody RigidBody;
    private float MovementInputValue = 0f;

    // Start is called before the first frame update
    void Start()
    {
        RigidBody = this.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        GetPlayerInput();
    }

    private void FixedUpdate()
    {
        Move();
    }

    void GetPlayerInput()
    {
        MovementInputValue = Input.GetAxisRaw("Horizontal");
        Debug.Log(MovementInputValue);
    }

    void Move()
    {
        RigidBody.velocity = transform.right * MovementInputValue * Speed * Time.deltaTime;
    }
}
