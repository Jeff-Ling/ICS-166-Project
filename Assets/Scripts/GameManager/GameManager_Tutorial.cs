using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

public class GameManager_Tutorial : MonoBehaviour
{
    public GameObject player;
    public GameObject key1;

    public Flowchart mainFlowchart;

    // Bool Check
    private bool flowchartHasShown_key1 = false;

    private void Update()
    {
        CheckDistanceKey1();
    }

    public void CheckDistanceKey1()
    {
        if (!flowchartHasShown_key1 && Vector3.Distance(player.transform.position, key1.transform.position) < 5f)
        {
            flowchartHasShown_key1 = true;
            mainFlowchart.ExecuteBlock("Before Pick Up Key1");
        }
    }
}
