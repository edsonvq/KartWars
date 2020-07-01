using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
	public float time;

	//apenas destroi a animacao explosao
	void Start () {
		Destroy(this.gameObject, time);
	}

    // Update is called once per frame
    void Update()
    {
        
    }


    void OnBecameInvisible()
    {
        Destroy(this.gameObject);
    }
}
