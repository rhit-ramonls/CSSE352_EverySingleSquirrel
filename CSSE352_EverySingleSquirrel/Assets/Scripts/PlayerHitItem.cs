using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHitItem : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject == GameObject.Find("Player"))
        {
            EventBus.Publish(EventBus.EventType.HitItem);
            Destroy(gameObject);
        }
    }
}
