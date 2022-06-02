using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

public class GameManager_Room1 : MonoBehaviour
{
    public Flowchart mainFlowchart;

    public GameObject camer;
    public GameObject player;
    public GameObject puzzleBox;
    public GameObject puzzleBoxScene;

    private bool firstTimePuzzleBox = true;
    private bool Say_1 = false;
    private bool Say_2 = false;
    private bool Say_3 = false;

    public GameObject[] backgroundLight;
    public GameObject littleGirl;
    public GameObject point1;
    public GameObject stair;
    public GameObject anotherScene;

    private void Start()
    {
        Time.timeScale = 1f;
    }

    // Update is called once per frame
    void Update()
    {
        OpenPipeGame();

        ApproachStair();
        CheckDistancePuzzleBox();
        Say_OutOfMind();
    }

    private void OpenPipeGame()
    {
        if (Vector3.Distance(player.transform.position, puzzleBox.transform.position) < 3f && Input.GetKey(KeyCode.E) && firstTimePuzzleBox)
        {
            puzzleBoxScene.SetActive(true);
            firstTimePuzzleBox = false;
        }
    }

    public void LightBlackOut()
    {
        foreach (GameObject l in backgroundLight)
        {
            l.SetActive(false);
        }

    }

    public void LittleGirlDisappear()
    {
        littleGirl.SetActive(false);
    }

    public void LightBack()
    {
        foreach (GameObject l in backgroundLight)
        {
            l.SetActive(true);
        }

        puzzleBox.SetActive(true);
    }

    private void Say_OutOfMind()
    {
        if (!Say_1 && Vector3.Distance(player.transform.position, point1.transform.position) < 10f)
        {
            Say_1 = true;
            mainFlowchart.ExecuteBlock("OutOfMind");
        }
    }

    private void CheckDistancePuzzleBox()
    {
        if (!Say_2 && Vector3.Distance(player.transform.position, puzzleBox.transform.position) < 5f)
        {
            Say_2 = true;
            mainFlowchart.ExecuteBlock("PuzzleBox");
        }
    }
    private void ApproachStair()
    {
        if (!Say_3 && Vector3.Distance(player.transform.position, stair.transform.position) < 5f)
        {
            Say_3 = true;
            mainFlowchart.ExecuteBlock("ApproachStair");
        }
    }

    public void TeleportPlayer()
    {
        anotherScene.SetActive(true);
        player.transform.position = new Vector3(395f, -0.8f, 0f);
        camer.transform.position = new Vector3(400f, 1f, -10f);

    }
}
