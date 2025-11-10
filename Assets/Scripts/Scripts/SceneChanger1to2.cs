using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger1to2 : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Level Exiter")
        {
            SceneManager.LoadScene("Scene 2");
        }
    }
}
