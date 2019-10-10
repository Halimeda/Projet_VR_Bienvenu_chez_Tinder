using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

namespace VoiceInteraction
{
    public class audio : MonoBehaviour
    {
        public VoiceInteraction.InteractionObjets Io;


        public AudioClip bienvenue; //
        public AudioClip noDonut; //
        public AudioClip donutGive; //
        public AudioClip noMoneyGuard; // Pas bon endroit
        public AudioClip moneyGuard; //
        public AudioClip noPicturesFound; // Pas bon endroit ?????
        public AudioClip picturesFound; //
        public AudioClip fakeButtton; // A metttre !
        public AudioClip trueButtton; // A metttre !
        public AudioClip randomAttention; // A metttre !
        public AudioClip randomDiplom; // A metttre !
        public AudioClip randomLetSee; // A metttre !
        public AudioClip randomSee; // A metttre !
        public AudioClip insideRoom2; // A metttre !
        public AudioClip computerTest; // A metttre !
        public AudioClip endSpech; // A Verifier


        public AudioSource audioSource;

        private bool donutCheck = false;
        private bool moneyCheck = false;
        private bool pictureCheck = false;
        private bool coroutineCheck = false;
        private bool coroutine2Check = false;






        // Start is called before the first frame update
        void Start()
        {
            audioSource = this.GetComponent<AudioSource>();
        }

        // Update is called once per frame
        void Update()
        {
            
        }


        public void welcomeSpeech()
        {
                Debug.Log("Welcome");
                audioSource.clip = bienvenue;
                audioSource.Play();
        }

        public void endSpeech()
        {
            audioSource.clip = endSpech;
            audioSource.Play();
        }

        public void Donut()
        {
            if(Inventory.inventory["Donut"] == 0)
            {
                audioSource.clip = noDonut;
                audioSource.Play();
                Debug.Log("Entre Voix Off1 Donut");
            }
            else if(Inventory.inventory["Donut"] == 2 && donutCheck == false)
            {
                audioSource.clip = donutGive;
                audioSource.Play();
                donutCheck = true;
                Debug.Log("Entre Voix Off2 Donut");
            }
        }

        public void MoneyorPicture()
        {
            if ((Inventory.inventory["Money"] == 0) && (Inventory.inventory["Donut"] == 2) && coroutineCheck == false)
            {
                Debug.Log("noMoney");
                StartCoroutine(launchedNoMoney());
                coroutineCheck = true;
            }
            else if (Inventory.inventory["Money"] == 2 && moneyCheck == false)
            {
                Debug.Log("Money");
                audioSource.clip = moneyGuard;
                audioSource.Play();
                moneyCheck = true;
            }
            else if ((Inventory.inventory["Picture"] == 0) && (Inventory.inventory["Donut"] == 2) && (Inventory.inventory["Money"] == 2) && coroutine2Check == false)
            {
                Debug.Log("noPicture");
                StartCoroutine(launchedNoPicture());
                coroutine2Check = true;
            }
            else if (Inventory.inventory["Picture"] == 2 && pictureCheck == false)
            {
                Debug.Log("Picture");
                audioSource.clip = picturesFound;
                audioSource.Play();
                pictureCheck = true;
            }
        }

        IEnumerator launchedNoMoney()
        {
            yield return new WaitForSeconds(20f);
            audioSource.clip = noMoneyGuard;
            audioSource.Play();
        }

        IEnumerator launchedNoPicture()
        {
            yield return new WaitForSeconds(20f);
            audioSource.clip = noPicturesFound;
            audioSource.Play();
        }

        //Changer Ne lanvce pas la piste audio

        //IEnumerator Zone2()
        //{
        //    //if ((Io.inventory["Picture"] == 2) && (Io.inventory["Donut"] == 2) && (Io.inventory["Money"] == 2))
        //    //{
        //    //    audioSource.clip = insideRoom2;
        //    //    audioSource.Play();
        //    //    yield return new WaitForSeconds(audioSource.clip.length);
        //    //    audioSource.clip = computerTest;
        //    //    audioSource.Play();
        //    //}
        //}
    }
}
