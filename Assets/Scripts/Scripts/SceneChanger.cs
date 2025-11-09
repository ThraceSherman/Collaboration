using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using System.Collections;
public class SceneChanger : MonoBehaviour
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
            SceneManager.LoadScene("Scene 3");
            
            // This will do the same thing.
            //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}
