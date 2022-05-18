using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Stats : MonoBehaviour
{
    // For Coins
    public TextMeshProUGUI coinText;
    public static int score;

    // For Key
    private bool HasTheKey { get; set; }

    // Add Audio
    [SerializeField] private AudioSource collectSoundEffect;

    void Start()
    {
        score = 0;
    }

    // If Gameobject collides with the coin
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Coin"))
        {
            collectSoundEffect.Play();
            ChangeScore(1); // Incremet Coin
            Destroy(collision.gameObject); // Destroy the coin
        }

        if (collision.gameObject.CompareTag("Blue_key"))
        {
            this.HasTheKey = true;
            collectSoundEffect.Play();
            Destroy(collision.gameObject); // Destroy the key
        }
    }

    public void ChangeScore(int coinValue)
    {
        score += coinValue;
        coinText.text = score.ToString();
    }

    // Check If Player Has The Key
    public bool canEnter()
    {
        return HasTheKey;
    }


}
