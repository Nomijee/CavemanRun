using UnityEngine;
using System.Collections;

public class CavemanRunDestoryOnHit : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D other)	{
		Destroy (other.gameObject);
	}
}
