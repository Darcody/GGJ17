using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boatanimation : MonoBehaviour {
    bool leanleft = false;
    bool leanright = true;
   public float speed = 10;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
       // print("I AM ALIVE " + leanleft +"l | R " + leanright);
        if (leanright) {
            if (transform.localEulerAngles.z < 3f)
            {
              //  transform.Rotate(Vector3.right * Time.deltaTime * speed, Space.World);
                transform.Rotate(Vector3.forward * Time.deltaTime * speed, Space.World);
              //  print(transform.eulerAngles.z);
              //  print("A");
            }
           else  if (transform.localEulerAngles.z > 357f)
            {
               // transform.Rotate(Vector3.right * Time.deltaTime * speed, Space.World);
                transform.Rotate(Vector3.forward* Time.deltaTime * speed, Space.World);
              //  print(transform.eulerAngles.z);
              //  print("B");
            }
            else {
            //    print("ChangeSTATE");
                leanright =false;
                leanleft = true;
            }
        }

        if (leanleft)
        {
           // print("left");
            if (transform.localEulerAngles.z > 0 && transform.localEulerAngles.z < 2)
            {
            //    transform.Rotate(Vector3.left * Time.deltaTime * speed, Space.World);
                transform.Rotate(Vector3.back * Time.deltaTime * speed, Space.World);
               //   print(transform.eulerAngles.z);
               // print("C");
            }

            else if ( transform.localEulerAngles.z > 355)
            {
              //  transform.Rotate(Vector3.left * Time.deltaTime * speed, Space.World);
                transform.Rotate(Vector3.back * Time.deltaTime * speed, Space.World);
              //   print(transform.eulerAngles.z);
               // print("D");
            }

            else
            {
                leanright = true;
                leanleft = false;
            }
        }






    }
}
