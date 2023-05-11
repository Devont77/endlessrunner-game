using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private CharacterController controller;
    private Vector3 direction;
    public float fordwardSpeed;//sino es público no podremos ajustarlo en el apartado Player Controller asociado a nuestro script
    private int selectedLine = 1; //1-middle, 2-left, 3-right, por defecto empezamos en el medio.
    public float laneDistance = 4;//la distancia entre 2 lineas.

    public float jumpForce;
    public float Gravity = -20;

    // Start is a method called before the first frame update
    void Start()
    {
        controller= GetComponent<CharacterController>();
    }

    // Update is a method called once per frame
    void Update()
    {
        direction.z = fordwardSpeed;

        direction.y += Gravity*Time.deltaTime;
        //We check if we are on the ground->
        if (controller.isGrounded)
        {
            //We check if we are holding o typing the up arrow key;
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                Jump();
            }
        }
        //Gather the inputs on which lane we should be
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            selectedLine++;
            if(selectedLine == 3)selectedLine = 2;
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            selectedLine--;
            if (selectedLine ==-1) selectedLine = 0;
        }

        //Calculate where we should be in the future->
        Vector3 targetPosition=transform.position.z * transform.forward + transform.position.y * transform.up;
        if(selectedLine==0)
        {
            targetPosition+= Vector3.left * laneDistance;
        }else if(selectedLine==2)
        {
            targetPosition+= Vector3.right * laneDistance;
        }

        //without smoothness-> transform.position = targetPosition;
        transform.position = Vector3.Lerp(transform.position,targetPosition,80*Time.deltaTime);
    }

    private void FixedUpdate()
    {
        controller.Move(direction * Time.fixedDeltaTime);
    }
    private void Jump()
    {
        direction.y = jumpForce;
    }
}
