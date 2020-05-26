using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public float speed ;
    public float rotation;

    // Start is called before the first frame update
    void Start()
    {
        speed = 100.0f;
    }

    // Update is called once per frame
    void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal") * Time.deltaTime;
        float moveVertical = Input.GetAxis("Vertical");

        rotation += moveHorizontal;

        Vector3 movement = new Vector3(0.0f, 0.0f, speed * moveVertical * Time.deltaTime);
        Vector3 targetDirection = new Vector3(Mathf.Sin(rotation), 0, Mathf.Cos(rotation));
        transform.rotation = Quaternion.LookRotation(targetDirection);

        transform.Translate(movement);

    }
    //Das Einsammeln 
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Equals("Collectable"))
        {
            Destroy(other.gameObject);
        }
    }
}
        
