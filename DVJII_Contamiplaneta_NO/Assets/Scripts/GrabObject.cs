using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabObject : MonoBehaviour
{
    public GameObject obj;
    public Transform gripper; //pinza

    public bool active;

    private void Start()
    {
        gripper = GameObject.FindGameObjectWithTag("Gripper").transform;

    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            active = true;

        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            active = false;
            Debug.Log("trueee");
        }
    }

    private void Update()
    {
        if (active)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                obj.transform.SetParent(gripper);
                obj.transform.position = gripper.position;
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
