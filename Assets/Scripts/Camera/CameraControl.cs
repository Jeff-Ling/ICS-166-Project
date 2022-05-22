using UnityEngine;

// Author: Jiefu Ling(jieful2)
// This script is used to control camera movement.
// Camera should follow player smoothly.

public class CameraControl : MonoBehaviour
{
    public float m_DampTime = 0.2f;                 
    public float m_ScreenEdgeBuffer = 4f;           
    public float m_MinSize = 100f;                  
    public Transform m_Target; 


    private Camera m_Camera;                        
    private Vector3 m_MoveVelocity;                 
    private Vector3 m_DesiredPosition;              


    private void Awake()
    {
        m_Camera = GetComponentInChildren<Camera>();
    }


    private void FixedUpdate()
    {
        // We just want the camera to move but not zoom
        Move();
    }


    private void Move()
    {
        FindAveragePosition();

        transform.position = Vector3.SmoothDamp(transform.position, m_DesiredPosition, ref m_MoveVelocity, m_DampTime);
    }


    private void FindAveragePosition()
    {
        Vector3 targetPosition = new Vector3();

        targetPosition.x = m_Target.position.x;
        targetPosition.y = 1f;
        targetPosition.z = -10f;

        m_DesiredPosition = targetPosition;
    }
}