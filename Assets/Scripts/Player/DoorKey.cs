using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;


public class DoorKey : MonoBehaviour
{

    public TextMeshProUGUI doorIsLockText;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            bool playerHasTheKey = collision.GetComponent<Stats>().canEnter();
            
            if (playerHasTheKey)
            {   // Finish Level
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); // Advance Level

            } else
            {
                doorIsLockText.text = "Door is lock";
                StartCoroutine(hideText(1));
            }
        }
    }

    IEnumerator hideText(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        doorIsLockText.text = "";
    }
}
