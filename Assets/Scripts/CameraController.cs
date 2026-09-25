using UnityEngine;
/************************************************************
* COMPONENT OF: Camera
* DESCRIPTION: The camera will follow the player in game.
* DATE: 9/25/2026
* AUTHOR: Lav Popov
* VERSION: 1.0
*************************************************************/

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform playerTransform;

    [SerializeField] private Vector3 offset;

  

    // Update is called once per frame
    void LateUpdate()
    {
       transform.position = playerTransform.position + offset; 
 
    }
}
