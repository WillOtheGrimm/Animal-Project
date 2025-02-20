using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBread : MonoBehaviour
{

    public GameObject breadPrefab;
    private Vector3 randomLocation;
    public float randomRange;

    // Start is called before the first frame update
    void Start()
    {
        



    }

    // Update is called once per frame
    void Update()
    {
        
    }


    //this method is to spawn food at a random location.
    public void SpawnFood ()
    {
        float randomX = Random.Range(-randomRange, randomRange);
        float randomZ = Random.Range(-randomRange, randomRange);
        randomLocation = new Vector3(randomX, 10, randomZ);




        //Instantiate the bread prefab
        Instantiate(breadPrefab, randomLocation, Quaternion.identity);

    }


}
