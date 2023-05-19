using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawner : MonoBehaviour
{

    [SerializeField] GameObject itemPrefab;

    // Start is called before the first frame update
    void Start()
    {
        EventBus.Subscribe(EventBus.EventType.SpawnItems, SpawnItems);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnItems()
    {
        for(int i=0; i<5; i++){
            GameObject new_item = Instantiate(itemPrefab);
            new_item.transform.position = new Vector3(Random.Range(-18.5f,16.5f), Random.Range(-4.5f,12.5f), new_item.transform.position.z);
            new_item.transform.SetParent(gameObject.transform);
        }
    }
}
