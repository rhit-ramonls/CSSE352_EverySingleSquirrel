using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartButtonLoader : MonoBehaviour
{
    public void OnClickLoad()
    {
        EventBus.Publish(EventBus.EventType.StartGame);
    }
}
