using UnityEngine;
using System.Collections;

public class prefabSpawner : MonoBehaviour {

	private float nextSpawn = 0;
	public Transform prefabToSpawn;
	public AnimationCurve spawnCurve;
	public float curveLengthInSecounds = 30f;
	private float startTime;
	public float jitter = 0.25f;

	// Use this for initialization
	void Start () {
		startTime = Time.time;
	}
	
	// Update is called once per frame
	void Update () {

		if (Time.time > nextSpawn) {
			Instantiate (prefabToSpawn, transform.position, Quaternion.identity);
			float curvePos = (Time.time - startTime) / curveLengthInSecounds;
			if (curvePos > 1f) {
				curvePos = 1f;
				startTime = Time.time;
			}
			nextSpawn = Time.time + spawnCurve.Evaluate(curvePos) + Random.Range(-jitter, jitter);
		}
	}
}
