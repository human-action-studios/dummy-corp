using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DespawnController : MonoBehaviour
{
    public SpawnController spawnController;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Car")
        {
            Debug.Log(other.tag);
            spawnController.carCount--;
            Destroy(other.gameObject);
        }
    }
}
