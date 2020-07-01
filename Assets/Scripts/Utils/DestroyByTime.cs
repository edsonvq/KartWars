using UnityEngine;
using System.Collections;

public class DestroyByTime : MonoBehaviour {

	public float time;

	//apenas destroi a animacao explosao
	void Start () {
		Destroy(this.gameObject, time);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
