using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    [SerializeField] public int numAcorns;

    // Start is called before the first frame update
    void Start()
    {
        numAcorns = 0;
        EventBus.Subscribe(EventBus.EventType.HitItem, IncItems);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void IncItems()
    {
        numAcorns++;
    }
}
