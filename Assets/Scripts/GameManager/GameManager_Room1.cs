using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager_Room1 : MonoBehaviour
{

    public GameObject player;
    public GameObject puzzleBox;
    public GameObject puzzleBoxScene;

    private void Start()
    {
        Time.timeScale = 1f;
    }

    // Update is called once per frame
    void Update()
    {
        OpenPipeGame();
    }

    private void OpenPipeGame()
    {
        if (Vector3.Distance(player.transform.position, puzzleBox.transform.position) < 3f && Input.GetKey(KeyCode.E))
        {
            puzzleBoxScene.SetActive(true);
        }
    }
}
