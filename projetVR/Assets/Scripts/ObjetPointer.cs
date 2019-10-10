//======= Copyright (c) Valve Corporation, All rights reserved. ===============
using UnityEngine;
using UnityEngine.AI;

using System.Collections;
using System.Collections.Generic;
using Valve.VR;
using Valve.VR.Extras;

namespace VoiceInteraction
{
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
        private GameObject ennemy;
        private GameObject money;
        private GameObject ball;

        public GameObject ballPoint;
        public GameObject picture;
        public GameObject pig;
        public GameObject donut;
        public audio voixOff;
        public GameObject door1;
        public GameObject door2;
        public Enemy enemyRoot;
        public GameObject guardDoor2;
        public GameObject guardDestination;
        public GameObject trueButtonPoint;


        public InteractionObjets interactionObjet;

        private bool objectCheck = false;


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
                if ((touched.gameObject.tag == "Donut" || touched.gameObject.tag == "Money" || touched.gameObject.tag == "Picture" || touched.gameObject.tag == "Ball" || touched.gameObject.tag == "CanMove" || touched.gameObject.tag == "ObjectTest") && grabed == null)
                {
                    grabed = touched;
                    grabed.transform.SetParent(this.transform);
                    if (touched.gameObject.tag == "Ball")
                    {
                        voixOff.endSpeech();

                    }
                    else if (touched.gameObject.tag == "ObjectTest")
                    {
                        objectCheck = true;
                    }
                    else if (touched.gameObject.tag == "Donut")
                    {
                        /* 0--> pas encore récupéré
                         * 1--> récupéré
                         * 2--> donné
                         */
                        Debug.Log("Inventory.modify Donut");
                        Inventory.Modify(touched.gameObject);
                        if (donut)
                        {
                            Destroy(donut);
                        }

                    }
                    else if (touched.gameObject.tag == "Money")
                    {
                        Debug.Log("Inventory.modify Money");
                        Inventory.Modify(touched.gameObject);
                        money.SetActive(false);
                    }
                    else if (touched.gameObject.tag == "Picture")
                    {
                        Debug.Log("Inventory.modify Picture");
                        Inventory.Modify(touched.gameObject);
                        if (picture)
                        {
                            Debug.Log("Destroy Picture");

                            Destroy(picture);
                        }


                    }
                }

                else if (touched.gameObject.tag == "StartButton" || touched.gameObject.tag == "TrueButton" || touched.gameObject.tag == "FalseButton" || touched.gameObject.tag == "TestButton" || touched.gameObject.tag == "Pig" || touched.gameObject.tag == "GardePlante")
                {
                    grabed = null;
                    if (touched.gameObject.tag == "StartButton")
                    {
                        if (door1)
                        {
                            Debug.Log("destroy");
                            voixOff.welcomeSpeech();
                            Destroy(door1);
                        }
                    }
                    else if (touched.gameObject.tag == "TrueButton")
                    {
                        if (door2 && Inventory.inventory["Money"] == 2 && Inventory.inventory["Picture"] == 2)
                        {
                            Destroy(door2);
                            Debug.Log("True room");

                        }
                    }
                    else if (touched.gameObject.tag == "FalseButton")
                    {
                        if (Enemy.enemyCheck == false)
                        {
                            Debug.Log("False Button - Fight");
                            ennemy = Resources.Load("NpcFight") as GameObject;
                            ennemy = Instantiate(ennemy, enemyRoot.enemyPosition, Quaternion.identity) as GameObject;
                            Enemy.enemyCheck = true;
                        }
                    }
                    else if (touched.gameObject.tag == "TestButton" && objectCheck == true)
                    {
                        //add timer bille & Start animation
                        Debug.Log("No score");
                        ball = Resources.Load("Note_desirabilite") as GameObject;
                        ball = Instantiate(ball, ballPoint.transform.position, Quaternion.identity);

                    }
                    else if (touched.gameObject.tag == "Pig")
                    {
                        if (Inventory.inventory["Donut"] == 1)
                        {
                            Debug.Log("Cochon");
                            Inventory.inventory["Donut"] += 1;
                            money = Resources.Load("Money") as GameObject;
                            Vector3 moneypos = new Vector3(pig.transform.position.x +2, pig.transform.position.y, pig.transform.position.z +2);
                            Instantiate(money, moneypos, Quaternion.identity);
                        }
                        voixOff.Donut();
                    }
                    else if (touched.gameObject.tag == "GardePlante")
                    {
                        if (Inventory.inventory["Money"] == 1)
                        {
                            Debug.Log("MoneyGuard");
                            Inventory.inventory["Money"] += 1;
                        }
                        if (Inventory.inventory["Picture"] == 1)
                        {
                            Debug.Log("PictureGuard");
                            Inventory.inventory["Picture"] += 1;
                        }
                        else if (Inventory.inventory["Money"] == 2 && Inventory.inventory["Picture"] == 2)
                        {
                            Debug.Log("WayPoint");
                            NavMeshAgent guard = guardDoor2.GetComponent<NavMeshAgent>();
                            guard.SetDestination(guardDestination.transform.position);
                            guard.speed = 5;
                            GameObject trueButton = Resources.Load("TrueButton") as GameObject;
                            Instantiate(trueButton, trueButtonPoint.transform.position, Quaternion.identity);
                        }
                        voixOff.MoneyorPicture();
                    }
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
                    if ((tag == "Donut" || tag == "Pig" || tag == "Money" || tag == "ObjectTest" || tag == "StartButton" || tag == "TrueButton" || tag == "FalseButton" || tag == "TestButton" || tag == "Picture" || tag == "Ball" || tag == "CanMove" || tag == "GardePlante") && grabed == null)
                    {
                        touched = hit.transform.gameObject;
                        pointer.GetComponent<MeshRenderer>().material.color = highlightColor;
                    }
                }

            }

            if (ennemy)
            {
                ennemy.transform.position = enemyRoot.enemyPosition;
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

            voixOff.MoneyorPicture();
        }
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
