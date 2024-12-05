// Tutorial for changing scenes
// Documentatin: https://docs.unity3d.com/ScriptReference/SceneManagement.SceneManager.html

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollideTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        // Check if collision is made with the Drop, which is tagged as "Finish"
        // You can change the tag and manually change this accordingly.
        if (other.tag == "LevelExit")
        {
            // Print out the current scene's name
            Debug.Log(SceneManager.GetActiveScene().name);
            // Change scene
            SceneManager.LoadScene("01_Next");

            // This will do the same thing.
            //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}
