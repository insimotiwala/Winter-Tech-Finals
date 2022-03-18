using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public Text scorekeeper;
    //public string Text;
    private static int points = 0;



    private void OnTriggerEnter(Collider col)
    {
        if (col.tag != "Player") { return; }

     

            points = points + 25;

            scorekeeper.text = points.ToString();
     


    }

    private void OnTriggerExit(Collider col)
    {
        if (col.tag != "Player") { return; }

        Destroy(this.gameObject, 4);


    }
}