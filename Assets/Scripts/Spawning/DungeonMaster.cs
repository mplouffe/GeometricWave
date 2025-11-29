using UnityEngine;
using System.Collections;
using System.Xml;
using System.IO;
using System;

namespace lvl_0
{
    public class DungeonMaster : MonoBehaviour
    {

        // properties
        public XmlDocument xmlDoc;
        public CamRot cameraRotation;
        public EnemySpawner enemySpawner;
        public TextAsset _json;

        // Use this for initialization
        void Start()
        {
            // if _xml is not loaded properly, get it from the resources folder
            if (_json == null)
            {
                _json = (TextAsset)Resources.Load("demostage");
            }

            // set up all the objects
            cameraRotation = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CamRot>();
            enemySpawner = FindObjectOfType<EnemySpawner>();

            // start the Logic to run level
            // StartCoroutine(NextEvent(0));
        }

        // TODO: Add logic to wrap loading a level. NextEvent should be called by the logical level wrapper layer until the level is complete
        // TODO: Also level should be able to load next level, or do intermission things


        /// <summary>
        /// This is the eent parser. 
        /// </summary>
        /// <param name="bookmark">The current layer of XML</param>
        IEnumerator NextEvent(int bookmark)
        {

            // and inital pause before spawning the first level event
            yield return new WaitForSeconds(2);

            // as long as there is stuff in the XML, keep parsing
            while (bookmark < xmlDoc.DocumentElement.ChildNodes.Count)
            {
                // get he current event
                XmlNode currentEvent = xmlDoc.DocumentElement.ChildNodes[bookmark];
                string currentEventType = currentEvent.ChildNodes[0].InnerText;
                float nextEvent = 0;

                switch (currentEventType)
                {
                    case "rotate":
                        float rotAmount = Single.Parse(currentEvent.ChildNodes[1].InnerText);
                        float rotIncrement = Single.Parse(currentEvent.ChildNodes[2].InnerText);
                        cameraRotation.changeCameraAngle(rotAmount, rotIncrement);
                        nextEvent = Single.Parse(currentEvent.ChildNodes[3].InnerText);
                        break;
                    case "garbage":
                        //enemySpawner.SpawnGarbageTruck();
                        nextEvent = Single.Parse(currentEvent.ChildNodes[1].InnerText);
                        break;
                    case "cop":
                        //enemySpawner.SpawnCopCar();
                        nextEvent = Single.Parse(currentEvent.ChildNodes[1].InnerText);
                        break;
                    case "ambulance":
                        //enemySpawner.SpawnAmbulance();
                        nextEvent = Single.Parse(currentEvent.ChildNodes[1].InnerText);
                        break;
                    case "turret":
                        //enemySpawner.SpawnTurret();
                        nextEvent = Single.Parse(currentEvent.ChildNodes[1].InnerText);
                        break;
                    case "ped":
                        //enemySpawner.SpawnPedestrian();
                        nextEvent = Single.Parse(currentEvent.ChildNodes[1].InnerText);
                        break;
                    case "car":
                        //enemySpawner.SpawnCar();
                        nextEvent = Single.Parse(currentEvent.ChildNodes[1].InnerText);
                        break;
                    case "loop":
                        bookmark = -1;
                        nextEvent = Single.Parse(currentEvent.ChildNodes[1].InnerText);
                        break;
                    case "buildings":
                        char buildingSide = char.Parse(currentEvent.ChildNodes[1].InnerText);
                        float buildingFrequency = Single.Parse(currentEvent.ChildNodes[2].InnerText);
                        nextEvent = Single.Parse(currentEvent.ChildNodes[3].InnerText);
                        break;
                    case "buildingsOff":
                        nextEvent = Single.Parse(currentEvent.ChildNodes[1].InnerText);
                        break;
                    case "foliage":
                        char foliageSide = char.Parse(currentEvent.ChildNodes[1].InnerText);
                        float foliageFrequency = Single.Parse(currentEvent.ChildNodes[2].InnerText);
                        nextEvent = Single.Parse(currentEvent.ChildNodes[3].InnerText);
                        break;
                    case "foliageOff":
                        nextEvent = Single.Parse(currentEvent.ChildNodes[1].InnerText);
                        break;
                }
                // advance the bookmak, and wait for the duration from the XML doc until the next call
                bookmark++;
                yield return new WaitForSeconds(nextEvent);
            }

            // NOTE: the demo current loops because there is a 'loop' call in it that sets the bookmak to -1 (which will hit 0 by the end of this script, hence settting
            // it back to the beginning of the XML document

        }
    }
}
