using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class GrabObject : MonoBehaviour
{
    public GameObject obj;
    public GameObject player;
    
    [Header ("Gripper")] //AGREGADO
    public Transform gripperUp; //pinza arriba
    public Transform gripperDown; //pinza abajo
    public Transform gripper; //pinza

    [Header ("Trash")] //AGREGADO
    public string typeTrash; //AGREGADO
    public bool active; //AGREGADO
    public bool activeDelete; //AGREGADO

    [Header ("Animator")] //AGREGADO
    public Animator animPlayer; //AGREGADO

    private void Start()
    {
        gripper = GameObject.FindGameObjectWithTag("Gripper").transform;
        gripperUp = GameObject.FindGameObjectWithTag("GripperUp").transform;
        gripperDown = GameObject.FindGameObjectWithTag("GripperDown").transform;
        player = GameObject.FindGameObjectWithTag("Player");
        animPlayer = player.GetComponent<Animator>(); //AGREGADO
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Gripper")
        {
            active = true;
        }
        if (typeTrash == "Plastic" && other.tag == "PlasticTrashCan")
        {
            activeDelete = true;
        }
        if (typeTrash == "Organic" && other.tag == "OrganicTrashCan")
        {
            activeDelete = true;
        }
        if (typeTrash == "Paper" && other.tag == "PaperTrashCan")
        {
            activeDelete = true;
        }
        if (typeTrash == "Metal" && other.tag == "MetalTrashCan")
        {
            activeDelete = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Gripper")
        {
            active = false;
        }
        if (typeTrash == "Plastic" && other.tag == "PlasticTrashCan")
        {
            activeDelete = false;
        }
        if (typeTrash == "Organic" && other.tag == "OrganicTrashCan")
        {
            activeDelete = false;
        }
        if (typeTrash == "Paper" && other.tag == "PaperTrashCan")
        {
            activeDelete = false;
        }
        if (typeTrash == "Metal" && other.tag == "MetalTrashCan")
        {
            activeDelete = false;
        }
    }

    private void Update()
    {
        if (active)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                obj.transform.SetParent(gripperUp);
                obj.transform.position = gripperUp.position;
                obj.GetComponent<Rigidbody2D>().gravityScale = 0;
                animPlayer.SetBool("crouched", true); //AGREGADO
                animPlayer.SetBool("grabbing", true); //AGREGADO
            }
            if (Input.GetKeyDown(KeyCode.R))
            {
                obj.transform.SetParent(null);
                obj.GetComponent<Rigidbody2D>().gravityScale = 1;
                animPlayer.SetBool("grabbing", false); //AGREGADO
                if (activeDelete)
                {
                    Destroy(obj);
                    //MARI ACÁ VA SUMAR PUNTAJE!!!//
                }
            }
        }
        animPlayer.SetBool("crouched", false); //AGREGADO
    }
}




