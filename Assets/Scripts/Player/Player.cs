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

    private Inventory inventory;              // The list of inventory
    private bool isTouched;                   // Whether Player is touched with item
    private GameObject itemTouched;

    // Start is called before the first frame update
    void Start()
    {
        RigidBody = this.GetComponent<Rigidbody>();

        inventory = new Inventory(UseItem);
    }

    // Update is called once per frame
    void Update()
    {
        GetPlayerInput();

        // Player press E and it is able to interact
        if (Input.GetKey(KeyCode.E) && isTouched)
        {
            Interaction();
        }
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
        if (itemTouched.GetComponent<Item>().collectable)
        {

            // Player pick up something and add to the inventory and the item should disappear
            inventory.AddItem(itemTouched.GetComponent<Item>());
            itemTouched.GetComponent<Item>().GetItem();
            itemTouched.SetActive(false);

            Debug.Log("Added to the inventory:");
            Debug.Log(itemTouched.GetComponent<Item>().itemType);
        }
        else
        {
            // Not collectable item should open something immediatedly.
            itemTouched.GetComponent<Item>().GetItem();
        }
    }

    private void UseItem(Item item)
    {
        switch (item.itemType)
        {
            case Item.ItemType.HealthPotion:
                break;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        GameObject item = other.gameObject;
        if (item.GetComponent<Item>() != null)
        {
            // Touch the item
            isTouched = true;
            itemTouched = item;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        GameObject item = other.gameObject;
        if (item.GetComponent<Item>() != null)
        {
            // Leave the item
            isTouched = false;
            itemTouched = null;
        }
    }
}