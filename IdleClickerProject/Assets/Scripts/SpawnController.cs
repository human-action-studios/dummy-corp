using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnController : MonoBehaviour
{
    public GameObject car;
    public float cooldown;
    public float cooldownReset;
    public int carCount;
    public int maxCarCount;
    
    // Start is called before the first frame update
    void Start()
    {
        cooldown = cooldownReset;
    }

    // Update is called once per frame
    void Update()
    {
        if (carCount <= maxCarCount && cooldown > 0)
        {
            cooldown -= Time.deltaTime;
        }

        if (carCount < maxCarCount && cooldown <= 0)
        {
            Instantiate(car, gameObject.transform.position, Quaternion.identity);
            carCount++;
            cooldown = cooldownReset;
        }
    }
}
