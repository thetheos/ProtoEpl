using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    float xMvt = 0f;
    float yMvt = 0f;

    public float runspeed = 40f;

    public CharacterController2D controller2D;




    // Update is called once per frame
    void Update()
    {
        xMvt = Input.GetAxis("Horizontal") * runspeed;
        yMvt = Input.GetAxis("Vertical") * runspeed;
    }

    private void FixedUpdate()
    {
        controller2D.Move(xMvt * Time.fixedDeltaTime, yMvt * Time.fixedDeltaTime);
    }
}
