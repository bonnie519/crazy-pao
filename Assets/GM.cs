using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GM : MonoBehaviour
{

    public static float vertVel = 0;
    public static int coinTotal = 0;
    public static float timeTotal = 0;
    public float waittoload = 0;

    public float zScenePos = 15;

    public static float zVelAdj = 1;

   // public static string lvlCompStatus = "";

   // public Transform bbNoPit;
   // public Transform bbPitMid;

    public Transform coinObj;
   // public Transform obstObj;
   // public Transform capsuleObj;

    public int randNum;

    // Use this for initialization
    void Start()
    {
        //Instantiate(bbNoPit, new Vector3(0, 2.25f, 40), bbNoPit.rotation);
        //Instantiate(bbNoPit, new Vector3(0, 2.25f, 44), bbNoPit.rotation);
        //Instantiate(bbPitMid, new Vector3(0, 2.25f, 48), bbPitMid.rotation);
        //Instantiate(bbPitMid, new Vector3(0, 2.25f, 52), bbPitMid.rotation);
        Instantiate(coinObj, new Vector3(6, 1, 15), coinObj.rotation);
    }

    // Update is called once per frame
    void Update()
    {

        if (zScenePos < 60)
        {
            zScenePos += 3;
            Instantiate(coinObj, new Vector3(6, 1, zScenePos), coinObj.rotation);
            Debug.Log(zScenePos);
        }
       else if (zScenePos < 90)
       {
            Instantiate(coinObj, new Vector3(-6, 1, zScenePos), coinObj.rotation);
            zScenePos += 3;
      } else
       {
           Instantiate(coinObj, new Vector3(0, 1, 105), coinObj.rotation);
       }

        // timeTotal += Time.deltaTime;

        // if (lvlCompStatus == "Fail")
        // {
        //     waittoload += Time.deltaTime;
        // }

        // if (waittoload > 2)
        // {
        //     SceneManager.LoadScene("levelComp");
        // }
    }
}