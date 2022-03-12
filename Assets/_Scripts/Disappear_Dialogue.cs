using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Disappear_Dialogue : MonoBehaviour
{
    public GameObject Balloon;
    //public string Text;

    public AudioSource audio1;
    public AudioClip[] clips;

    public GameObject[] Appear;
    public GameObject[] HideObject;

    private GameObject _curBalloon;

    private void OnTriggerEnter(Collider col)
    {
        if (col.tag != "Player") { return; }
        Canvas canvas = FindObjectOfType<Canvas>();
        if (canvas == null) { return; }

        /* _curBalloon = Instantiate(Balloon); //create text balloon
        _curBalloon.GetComponent<RectTransform>().position = new Vector2(Screen.width / 2.0f, 15); //position text balloon
         _curBalloon.GetComponent<Text>().text = Text; //update text in balloon
         _curBalloon.transform.parent = canvas.transform; //add balloon under Canvas

         //font size
         int screenHeight = Screen.height;
         float fontSize = screenHeight / 10.0f; Debug.Log((int)fontSize);
         _curBalloon.GetComponent<Text>().fontSize = (int)fontSize; //update text in balloon
         Vector2 rectSize = _curBalloon.GetComponent<RectTransform>().sizeDelta;
         rectSize.y = (int)(fontSize / 0.825);
         _curBalloon.GetComponent<RectTransform>().sizeDelta = rectSize;
        */

        //object show
        foreach (GameObject obj in Appear)
            if (obj != null) { obj.SetActive(true); }
        foreach (GameObject obj2 in HideObject)
            if (obj2 != null) { obj2.SetActive(false); }

        //audio
        if (audio1 == null) { return; }
        if (clips.Length == 0) { return; }
        int i = Random.Range(0, clips.Length); //random number within clips length
        audio1.clip = clips[c];
        audio1.Play();
        c++;
        if (c >= clips.Length) { c = 0; }
    }

    private int c = 0;

    private void OnTriggerExit(Collider col)
    {
        if (col.tag != "Player") { return; }
        if (_curBalloon == null) { return; }
        // if (Appear != null) { Appear.SetActive(false); }
        Destroy(_curBalloon);
    }
}