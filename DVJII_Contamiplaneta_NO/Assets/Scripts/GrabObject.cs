using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class GrabObject : MonoBehaviour
{
    public GameObject obj;
    public GameObject player;
    public Transform gripperUp; //pinza arriba
    public Transform gripperDown; //pinza abajo
    public Transform gripper; //pinza

    private bool grabbed = false;

    public bool active;

    private void Start()
    {
        gripper = GameObject.FindGameObjectWithTag("Gripper").transform;
        gripperUp = GameObject.FindGameObjectWithTag("GripperUp").transform;
        gripperDown = GameObject.FindGameObjectWithTag("GripperDown").transform;
        player = GameObject.FindGameObjectWithTag("Player");

    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Gripper")
        {
            active = true;

        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Gripper")
        {
            active = false;
        }
    }

    private void Update()
    {
        //if (Input.GetKey(KeyCode.E))
        //{
        //    if (grabbed)
        //    {
        //        player.GetComponent<Animator>().SetBool("crouched", false);
        //    }
        //    else
        //    {
        //        player.GetComponent<Animator>().SetBool("crouched", true);
        //    }

        //    if (active && !grabbed)
        //    {
        //        grabbed = true;
        //        player.GetComponent<Animator>().SetBool("grabbing", true);
        //        obj.transform.SetParent(gripperDown);
        //        obj.transform.position = gripperDown.position;
        //        obj.GetComponent<Rigidbody2D>().gravityScale = 0;
        //    }

        //    if(!active && grabbed)
        //    {
        //        grabbed =false;
        //        player.GetComponent<Animator>().SetBool("grabbing", false);
        //        obj.transform.SetParent(null);
        //        obj.GetComponent<Rigidbody2D>().gravityScale = 1;
        //    }

        //}

        /// if (Input.GetKeyUp(KeyCode.E))
        // {
        //  if (grabbed)
        //  {
        //     obj.transform.SetParent(gripperUp);
        //     obj.transform.position = gripperUp.position;
        //    player.GetComponent<Animator>().SetBool("crouched", false);
        //    player.GetComponent<Animator>().SetBool("grabbing", true);
        // }
        // else
        //{
        //    player.GetComponent<Animator>().SetBool("crouched", false);
        //     player.GetComponent<Animator>().SetBool("grabbing", false);
        // }

        //}

        if (active)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                obj.transform.SetParent(gripperUp);
                obj.transform.position = gripperUp.position;
                //obj.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Kinematic;
                obj.GetComponent<Rigidbody2D>().gravityScale = 0;

            }

            if (Input.GetKeyDown(KeyCode.R))
            {
                obj.transform.SetParent(null);
                obj.GetComponent<Rigidbody2D>().gravityScale = 1;

            }
        }
    }

}




