using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager_PipeRotation : MonoBehaviour
{
    public GameObject PipeHolder;
    public GameObject[] pipes;
    public GameObject puzzleBoxScene;

    [SerializeField]
    int totalPipes = 0;

    private bool allCorrect;

    // Start is called before the first frame update
    void Start()
    {
        totalPipes = PipeHolder.transform.childCount;

        pipes = new GameObject[totalPipes];
        
        for (int i = 0; i < pipes.Length; i++)
        {
            pipes[i] = PipeHolder.transform.GetChild(i).gameObject;
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Check Pipes Game
        CheckPipes();
        if (allCorrect)
        {
            // Turn off game scene
            puzzleBoxScene.SetActive(false);
        }
    }

    private void CheckPipes()
    {
        allCorrect = true;
        for (int i = 0; i < pipes.Length; i++)
        {
            if (pipes[i].GetComponent<pipeControl>().GetisCorrected() == false)
            {
                allCorrect = false;
            }
        }
    }
}
