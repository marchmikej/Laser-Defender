using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour {

	public GameObject enemyPreFab;

	// Use this for initialization
	void Start () {
		// They as GameObject tell Instantiate that we want this returned as a game object so we
		// can put this in the EnemyFormation game object
		GameObject enemy = Instantiate(enemyPreFab, new Vector3(0,0,0), Quaternion.identity) as GameObject;
		enemy.transform.parent = transform;  // Puts the new enemy inside whatever is running this script
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
