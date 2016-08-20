using UnityEngine;
using System.Collections;

public class cycle : MonoBehaviour {

	public Transform StartPoint;
	public Transform EndPoint;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
		if (transform.position.x < EndPoint.position.x) {
			float gap = EndPoint.position.x - transform.position.x;
			transform.position = new Vector3 (StartPoint.position.x -gap, transform.position.y, transform.position.z);
		}

	}
}
