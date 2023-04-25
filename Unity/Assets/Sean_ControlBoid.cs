using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sean_ControlBoid : MonoBehaviour
{

    public GameObject setPos;
    public GameObject boid;
    
    
    bool inPosition;


    private void Update()
    {
        if (inPosition == true)
        {
            //set camera pos to target
            gameObject.transform.LookAt(boid.transform);
            gameObject.transform.position = setPos.transform.position;

            //jump out of control
            if (Input.GetKey(KeyCode.Z))
            {
                inPosition = false;

            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        print("Cam Connect");
        if (other.tag == "Pod")
        { 

            //tell boid to add steering force to movements
            boid.SendMessage("setSteering", true);

            inPosition = true;
        }
    }
}
