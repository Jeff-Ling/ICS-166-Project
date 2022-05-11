using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pipeControl : MonoBehaviour
{
    public float correctPosition;
    
    [SerializeField]
    bool isCorrected = false;

    float [] rotation = {0, 90, 180, 270};

    private void Start()
    {
        int rand = Random.Range(0, rotation.Length);
        transform.eulerAngles = new Vector3(0, 0, rotation[rand]);

        if (transform.eulerAngles.z == correctPosition)
        {
            isCorrected = true;
        }
    }

    private void OnMouseDown()
    {
        transform.Rotate(new Vector3(0, 0, 90));

        if (transform.eulerAngles.z == correctPosition && isCorrected == false)
        {
            isCorrected = true;
        }
        else if (isCorrected == true)
        {
            isCorrected = false;
        }
    }

    public bool GetisCorrected()
    {
        return isCorrected;
    }
}
