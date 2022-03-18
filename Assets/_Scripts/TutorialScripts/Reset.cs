using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Reset : MonoBehaviour
{
    private void Start()
    {
        Cursor.UpdateAllNavMesh();
    }

    // Update is called once per frame
    private void Update()
    {
        //if (Input.GetKeyDown(KeyCode.R))
        if (Input.GetButtonDown("South"))
        {
            // Scene scene = SceneManager.GetActiveScene();
            // SceneManager.LoadScene(scene.name, LoadSceneMode.Single);
            SceneManager.LoadScene(0);
            GetComponent<Score>();
            
           
        }
    }
}