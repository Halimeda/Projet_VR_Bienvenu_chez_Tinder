//======= Copyright (c) Valve Corporation, All rights reserved. ===============
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Valve.VR;
using Valve.VR.Extras;

public class ObjetPointer : MonoBehaviour
{
    //public SteamVR_Behaviour_Pose pose;

    public SteamVR_Action_Boolean grabPinch;
    public SteamVR_Input_Sources inputSource = SteamVR_Input_Sources.Any;


    public Color color;
    public float thickness = 0.002f;
    public Color highlightColor = Color.green;
    public GameObject holder;
    public GameObject pointer;
    public bool addRigidBody = false;

    public VoiceInteraction.InteractionObjets Io;
    private GameObject touched;
    private GameObject grabed;

    public GameObject door1;
    public GameObject door2;
    public GameObject ennemyRoot;
    private int number = 0;

    private Vector3 ennemyPosition = new Vector3(0, 0, 0);


    public Vector3 origin_offset = new Vector3();
    public float max_distance_to_grab = 1000;

    Transform previousContact = null;


    private void Start()
    {

        holder = new GameObject();
        holder.transform.parent = this.transform;
        holder.transform.localPosition = Vector3.zero;
        holder.transform.localRotation = Quaternion.identity;

        pointer = GameObject.CreatePrimitive(PrimitiveType.Cube);
        pointer.transform.parent = holder.transform;
        pointer.transform.localScale = new Vector3(thickness, thickness, 100f);
        pointer.transform.localPosition = new Vector3(0f, 0f, 50f);
        pointer.transform.localRotation = Quaternion.identity;
        BoxCollider collider = pointer.GetComponent<BoxCollider>();


        if (addRigidBody)
        {
            if (collider)
            {
                collider.isTrigger = true;
            }
            Rigidbody rigidBody = pointer.AddComponent<Rigidbody>();
            rigidBody.isKinematic = true;
        }
        else
        {
            if (collider)
            {
                Object.Destroy(collider);
            }
        }
        Material newMaterial = new Material(Shader.Find("Unlit/Color"));
        newMaterial.SetColor("_Color", color);
        pointer.GetComponent<MeshRenderer>().material = newMaterial;
    }

    void OnEnable()
    {
        if (grabPinch != null)
        {
            grabPinch.AddOnChangeListener(OnTriggerPressedOrReleased, inputSource);
        }
    }


    private void OnDisable()
    {
        if (grabPinch != null)
        {
            grabPinch.RemoveOnChangeListener(OnTriggerPressedOrReleased, inputSource);
        }
    }




    private void OnTriggerPressedOrReleased(SteamVR_Action_Boolean action_In, SteamVR_Input_Sources sources, bool newstate)
    {
        if (newstate && touched != null)
        {
            if (touched.gameObject.tag == "StartButton")
            {
                if (door1)
                {
                    Debug.Log("destroy");
                    Destroy(door1);
                }
            }
            else if (touched.gameObject.tag == "TrueButton")
            {
                if (door2)
                {
                    Destroy(door2);
                    Debug.Log("True room");

                }
            }
            else if (touched.gameObject.tag == "FalseButton")
            {
                if (number == 0)
                {
                    Debug.Log("False Button - Fight");
                    GameObject ennemy = Resources.Load("NpcFight") as GameObject;
                    Instantiate(ennemy, ennemyPosition, Quaternion.identity);
                    number++;
                }
            }
            else if (touched.gameObject.tag == "TestButton")
            {
                //add timer bille & Start animation
                Debug.Log("No score");
            }
            else if (touched.gameObject.tag != "StartButton" || touched.gameObject.tag != "TrueButton" || touched.gameObject.tag != "FalseButton" || touched.gameObject.tag != "TestButton")
            {
                grabed = touched;
                grabed.transform.SetParent(this.transform);
            }

            if (Io != null)
            {
                Io.Modify(grabed);
            }
            
        }
        else if (!newstate && grabed != null)
        {
            grabed.transform.SetParent(null);
            grabed = null;
        }
    }



    private void Update()
    {


        if (grabed != null)
        {
            grabed.transform.localPosition = Vector3.zero;
            grabed.transform.localRotation = Quaternion.identity;
            grabed.transform.localPosition = origin_offset;
        }



        touched = null;

        float dist = 100f;

        Ray raycast = new Ray(transform.position, transform.forward);
        RaycastHit hit;
        bool bHit = Physics.Raycast(raycast, out hit);

        if (bHit)
        {
            if (hit.distance <= max_distance_to_grab)
            {
                string tag = hit.transform.gameObject.tag;
                if ((tag == "Donut" || tag == "Money" || tag == "StartButton" || tag == "TrueButton" || tag == "FalseButton" || tag == "TestButton" || tag == "Picture" || tag == "Ball" || tag == "CanMove") && grabed == null)
                {
                    touched = hit.transform.gameObject;
                    pointer.GetComponent<MeshRenderer>().material.color = highlightColor;
                }
            }
            
        }

        if (!bHit)
        {
            previousContact = null;
        }
        if (bHit && hit.distance < 100f)
        {
            dist = hit.distance;
        }

        if (touched == null)
        {
            pointer.GetComponent<MeshRenderer>().material.color = color;
        }
        pointer.transform.localPosition = new Vector3(0f, 0f, dist / 2f);
    }
}

public struct PointerEventArgs
{
    public SteamVR_Input_Sources fromInputSource;
    public uint flags;
    public float distance;
    public Transform target;
}

public delegate void PointerEventHandler(object sender, PointerEventArgs e);
