using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    //The player is the target for the camera->
    public Transform target;
    //This store the intial position of the camera->
    private Vector3 offset;
    // Start is a method called before the first frame update
    void Start()
    {
        //We substract the different distances->
        offset= transform.position-target.position;
    }

    // Update is a method called once per frame
    //void Update()
    //{
    //    Vector3 newPosition = new Vector3(transform.position.x,transform.position.y, offset.z+target.position.z);
    //    transform.position = newPosition;
    //}

    void LateUpdate()
    {
        Vector3 newPosition = new Vector3(transform.position.x, transform.position.y, offset.z + target.position.z);
        transform.position = Vector3.Lerp(transform.position, newPosition, 10 * Time.deltaTime);
    }
}
