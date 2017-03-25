using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour {

	float ymax;

	// Use this for initialization
	void Start () {
		// Get borders of screen
		float distance = transform.position.z - Camera.main.transform.position.z;
		Vector3 uppermost = Camera.main.ViewportToWorldPoint(new Vector3(0,1,distance));
		ymax = uppermost.y;
	}
	
	// Update is called once per frame
	void Update ()
	{
		// This destroys the laser after it goes off screen
		if (transform.position.y > ymax) {
			Destroy(gameObject);  
		}
	}

	void OnCollisionEnter2D(Collision2D coll) {
        //if (coll.gameObject.tag == "Enemy")
         //   coll.gameObject.SendMessage("ApplyDamage", 10);
		//It his something so it should go away.
		Destroy(gameObject); 
    }
}
