﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


// Author: Jiefu Ling(jieful2)
// This script is used to control player's movement.

public class Player : MonoBehaviour
{

    public float Speed = 10f;

    private Rigidbody RigidBody;
    private float MovementInputValue = 0f;

    private Animator animator;

    // Inventory Element
    private Inventory inventory;              // The list of inventory
    private bool isTouched;                   // Whether Player is touched with item
    private GameObject itemTouched;

    private bool enableInput = true;

    // Start is called before the first frame update
    void Start()
    {
        RigidBody = this.GetComponent<Rigidbody>();

        inventory = new Inventory(UseItem);

        animator = this.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        if (enableInput)
        {
            GetPlayerInput();

            // Player press E and it is able to interact
            if (Input.GetKey(KeyCode.E) && isTouched)
            {
                if (itemTouched != null)
                {
                    Interaction();
                }
            }
        }
        else
        {
            MovementInputValue = 0f;
        }


        // Set animator parameter
        animator.SetFloat("MovementValue", MovementInputValue);

    }

    private void FixedUpdate()
    {
        Move();
    }

    private void GetPlayerInput()
    {
        MovementInputValue = Input.GetAxisRaw("Horizontal");
    }

    private void Move()
    {
        RigidBody.velocity = transform.right * MovementInputValue * Speed * Time.deltaTime;
    }

    private void Interaction()
    {
        if (itemTouched.GetComponent<ItemWorld>().GetItem().collectable)
        {

            // Player pick up something and add to the inventory and the item should disappear
            inventory.AddItem(itemTouched.GetComponent<ItemWorld>().GetItem());
            itemTouched.GetComponent<ItemWorld>().GetItem().ActivateButton(inventory);
            itemTouched.GetComponent<ItemWorld>().DestroySelf();

            Debug.Log("Added to the inventory:");
            Debug.Log(itemTouched.GetComponent<ItemWorld>().GetItem().itemType);
        }
        else
        {
            // Not collectable item should open something immediatedly.
            UseItem(itemTouched.GetComponent<ItemWorld>().GetItem());
        }
    }

    private void UseItem(Item item)
    {
        switch (item.itemType)
        {
            case Item.ItemType.tutorialRoom_Key:
                SceneManager.LoadScene(1);             // Load scene to Room 1
                break;
            case Item.ItemType.room1_Key:
                SceneManager.LoadScene(2);
                break;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        GameObject item = other.gameObject;
        if (item.GetComponent<ItemWorld>() != null)
        {
            // Touch the item
            isTouched = true;
            itemTouched = item;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        GameObject item = other.gameObject;
        if (item.GetComponent<ItemWorld>() != null)
        {
            // Leave the item
            isTouched = false;
            itemTouched = null;
        }
    }

    public void EnableInput()
    {
        enableInput = true;
    }

    public void DisableInput()
    {
        enableInput = false;
    }
}