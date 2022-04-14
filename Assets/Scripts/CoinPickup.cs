using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinPickup : MonoBehaviour
{
    [SerializeField] AudioClip coinPickupSFX;
    [SerializeField] int intPointsForCoinPickup = 100;

    bool blWasCollected = false;
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player"&& !blWasCollected)
        {
            blWasCollected = true;
            FindObjectOfType<GameSession>().AddToScore(intPointsForCoinPickup);
            AudioSource.PlayClipAtPoint(coinPickupSFX, Camera.main.transform.position);
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
    }
}
