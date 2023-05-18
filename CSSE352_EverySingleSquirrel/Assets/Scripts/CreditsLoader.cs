using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreditsLoader : MonoBehaviour
{
    public void OnClickLoad()
    {
        EventBus.Publish(EventBus.EventType.Credits);
    }
}
