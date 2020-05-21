using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class prefabScript : MonoBehaviour
{
    public Transform myPrefab;
    public int numberOfObjects = 10;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < numberOfObjects; i++)
        {
            float x = UnityEngine.Random.Range(-100f, 100f);
            float y = 1;
            float z = UnityEngine.Random.Range(-100f, 100f);
            Vector3 position = new Vector3(x, y, z);
            Vector3 rotationVector = new Vector3(0, 30, 0);
            Quaternion rotation = Quaternion.Euler(rotationVector);
            Instantiate(myPrefab, position, rotation);
        }
    }

    // Update is called once per frame
    void Update()
    {  
       transform.Rotate(0, 100 * Time.deltaTime, 0, Space.Self);
    }
}
