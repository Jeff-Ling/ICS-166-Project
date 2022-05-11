using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Fungus;

// Author: Jiefu Ling(jieful2)
// The item script

[Serializable]
public class Item
{

    public enum ItemType
    {
        tutorialRoom_Key,
        room1_Key,
    }

    public ItemType itemType;
    public int amount;
    public GameObject button;

    public Flowchart mainFlowchart;
    public string blockName;

    public bool collectable;


    public bool IsStackable()
    {
        switch (itemType)
        {
            default:
            case ItemType.tutorialRoom_Key:
                return false;
        }
    }

    public void ActivateButton(Inventory inventory)
    {
        // Activate the UI button
        button.SetActive(true);
        button.GetComponent<TutorialRoom_Key>().SetItem(this);
        button.GetComponent<TutorialRoom_Key>().SetInventory(inventory);

        // Activate text (Fungus)
        mainFlowchart.ExecuteBlock(blockName);
    }

}
