using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pipeControl : MonoBehaviour
{
    public float[] correctPosition;
    
    [SerializeField]
    bool isCorrected = false;

    int possibleRotation = 1;

    float [] rotation = {0, 90, 180, 270};

    private void Start()
    {
        possibleRotation = correctPosition.Length;

        int rand = Random.Range(0, rotation.Length);
        transform.eulerAngles = new Vector3(0, 0, rotation[rand]);

        if (possibleRotation > 1)
        {
            if ((correctPosition[0] - 1 < transform.eulerAngles.z && transform.eulerAngles.z < correctPosition[0] + 1) || (correctPosition[1] - 1 < transform.eulerAngles.z && transform.eulerAngles.z < correctPosition[1] + 1))
            {
                isCorrected = true;
            }
        }
        else
        {
            if (transform.eulerAngles.z == correctPosition[0])
            {
                isCorrected = true;
            }
        }
    }

    private void OnMouseDown()
    {
        transform.Rotate(new Vector3(0, 0, 90));

        Debug.Log(transform.eulerAngles.z);

        if (possibleRotation > 1)
        {
            if ((correctPosition[0] - 1 < transform.eulerAngles.z && transform.eulerAngles.z < correctPosition[0] + 1) || (correctPosition[1] - 1 < transform.eulerAngles.z && transform.eulerAngles.z < correctPosition[1] + 1) && isCorrected == false)
            {
                isCorrected = true;
            }
            else if (isCorrected == true)
            {
                isCorrected = false;
            }
        }
        else
        {
            if (transform.eulerAngles.z == correctPosition[0] && isCorrected == false)
            {
                isCorrected = true;
            }
            else if (isCorrected == true)
            {
                isCorrected = false;
            }
        }
    }

    public bool GetisCorrected()
    {
        return isCorrected;
    }
}
