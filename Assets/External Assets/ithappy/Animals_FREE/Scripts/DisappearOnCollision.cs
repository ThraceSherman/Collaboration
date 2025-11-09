using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using System.Collections;
public class DisappearOnCollision : MonoBehaviour
{
    private int count = 0;
    public TextMeshProUGUI countText;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SetCountText();
    }
    private void OnTriggerEnter(Collider other)
    {
        // Check if the object colliding is the player
        if (other.gameObject.CompareTag("Collected"))
        {
            count = count + 1;
            SetCountText();
            other.gameObject.SetActive(false);

        }

        if(count == 7)
        {
            Debug.Log(SceneManager.GetActiveScene().name);
            SceneManager.LoadScene("Scene 3");
        }


    }
    void SetCountText()
    {
        countText.text = "Seasoning\nCollected: " + count.ToString();
    }
}
