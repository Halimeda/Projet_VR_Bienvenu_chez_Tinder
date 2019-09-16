using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;


namespace Valve.VR.InteractionSystem.Sample
{
    public class ButtonBehaviour : MonoBehaviour
    {
        public GameObject door;
        private Vector3 ennemyPosition = new Vector3(0, 0, 0);
        private int number = 0;
        //public audio voix;

        public void ButtonClick()
        {

            if (gameObject.tag == "StartButton")
            {
                //Change scene
                //voix.welcome();
                Debug.Log("Start Game");
            }

            else if (gameObject.tag == "FalseButton")
            {
                if (number == 0)
                {
                    Debug.Log("False Button - Fight");
                    GameObject ennemy = Resources.Load("NpcFight") as GameObject;
                    Instantiate(ennemy, ennemyPosition, Quaternion.identity);
                    number++;

                }
            }

            else if (gameObject.tag == "TrueButton")
            {
                if (door)
                {
                    Destroy(door);
                    Debug.Log("True room");

                }
            }

            else if (gameObject.tag == "TestButton")
            {
                //add timer bille & Start animation
                Debug.Log("No score");
            }
        }

        public void ButtonRelease()
        {
            ColorSelf(Color.white);
        }

        private void ColorSelf(Color newColor)
        {
            Renderer[] renderers = this.GetComponentsInChildren<Renderer>();
            for (int rendererIndex = 0; rendererIndex < renderers.Length; rendererIndex++)
            {
                renderers[rendererIndex].material.color = newColor;
            }
        }

    }
}
