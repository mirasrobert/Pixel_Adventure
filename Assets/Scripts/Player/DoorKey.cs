using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorKey : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            bool playerHasTheKey = collision.GetComponent<Stats>().canEnter();
            if(playerHasTheKey)
            { // Finish Level
                print("Level 1 Complete");
            } else
            {
                print("Door Locked, No Key");
            }
        }
    }
}
