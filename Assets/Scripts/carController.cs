using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class carController : MonoBehaviour {

	// Car controls
    float carSpeed = 10;
    float maxPos = 2.5f;
    Vector3 position;

    
    
	void Start ()
	{
	    position = transform.position;
	}
	
	// Update is called once per frame
	void Update ()
	{
	    position.x += Input.GetAxis("Horizontal") * carSpeed * Time.deltaTime; // Time.deltaTime -> time took to render the last frame
	    position.x = Mathf.Clamp(position.x, -2.5f, 2.5f); // clamps the position of car 
	    transform.position = position;
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("obstacle"))
        {
            Destroy(col.gameObject);
        }
    }
}
