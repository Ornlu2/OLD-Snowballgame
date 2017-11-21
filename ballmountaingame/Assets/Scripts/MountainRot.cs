using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MountainRot : MonoBehaviour {

    public bool isLeftkeyEnabled = true;
    public bool isRightkeyEnabled = true;

    public void rightmovement()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            AudioSource audio = GetComponent<AudioSource>();
            audio.Play();

        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Rotate(0, 0, 30f * Time.deltaTime);


            if (gameObject.transform.rotation.z < 40)
            {
                //Debug.Log ("rightkeyinrange");
                isRightkeyEnabled = true;
            }
            else
            {
                //Debug.Log ("rightkey out ofrange");
                isRightkeyEnabled = false;

            }

        }
    }

    public void leftmovement()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            AudioSource audio = GetComponent<AudioSource>();
            audio.Play();

        }
        if (Input.GetKey(KeyCode.RightArrow))
        {


            transform.Rotate(0, 0, -30f * Time.deltaTime);


            if (gameObject.transform.rotation.z > -40)
            {
                //Debug.Log ("leftkeyinrange");
                isLeftkeyEnabled = true;
            }
            else
            {
                //Debug.Log ("leftkey out ofrange");
                isLeftkeyEnabled = false;

            }


        }
    }


    void ClampRotation(float minAngle, float maxAngle, float clampAroundAngle = 0)
    {
        //clampAroundAngle is the angle you want the clamp to originate from
        //For example a value of 90, with a min=-45 and max=45, will let the angle go 45 degrees away from 90

        //Adjust to make 0 be right side up
        clampAroundAngle += 180;

        //Get the angle of the z axis and rotate it up side down
        float z = transform.rotation.eulerAngles.z - clampAroundAngle;

        z = WrapAngle(z);

        //Move range to [-180, 180]
        z -= 180;

        //Clamp to desired range
        z = Mathf.Clamp(z, minAngle, maxAngle);

        //Move range back to [0, 360]
        z += 180;

        //Set the angle back to the transform and rotate it back to right side up
        transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, z + clampAroundAngle);
    }

    //Make sure angle is within 0,360 range
    float WrapAngle(float angle)
    {
        //If its negative rotate until its positive
        while (angle < 0)
            angle += 360;

        //If its to positive rotate until within range
        return Mathf.Repeat(angle, 360);
    }

    void Update()
    {
        if (isLeftkeyEnabled == true)
        {


            leftmovement();



        }

        if (isRightkeyEnabled == true)
        {

            rightmovement();


        }

        ClampRotation(-40, 40, 0);

    }


}
