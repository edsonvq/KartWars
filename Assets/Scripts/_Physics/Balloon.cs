using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Balloon : MonoBehaviour
{
    public bool m_UseGravity;
    public float m_MinAirForce = 0.05f;
    public float m_MaxAirForce = 0.1f;

    private Rigidbody m_Body;
	
	
	public int type = 0;
	public int life = 3;
	
	private PlayerPoints pp;
	
    private void Awake()
    {
        m_Body = GetComponent<Rigidbody>();
		
		//gameController = GameObject.Find("Game Manager").GetComponent<GameController>();
		
		GameObject[] objs = GameObject.FindGameObjectsWithTag("Player");
		
        for (var i = 0; i < objs.Length; i++){
			if(objs[i].GetComponent<PlayerPoints>().typePlayer == type){
				pp = objs[i].GetComponent<PlayerPoints>();
			}
		}
		
    }
	
    private void FixedUpdate()
    {
        if (!m_UseGravity)
            m_Body.AddForce(-1.0f * Physics.gravity, ForceMode.Acceleration);

        //m_Body.AddForce(Vector3.up * Random.Range(m_MinAirForce, m_MaxAirForce));

    }
	
	
	void OnTriggerEnter (Collider outro){
		//Debug.Log("Acertou o Balao");

		
		if(outro.gameObject.tag == "Laser"){
			pp.life--;
			Destroy(this.gameObject);
		}
		
        if (outro.gameObject.tag == "Bullet"){
			Destroy(outro.gameObject);
			life--;
			
			if (life > 0)
			{
				MeshRenderer meshRend = GetComponent<MeshRenderer>();
				if(life == 2){
					
					meshRend.material.color = Color.yellow;
				}
				if(life == 1){
					meshRend.material.color = Color.red;
				}
			}
			else
			{
				Destroy(this.gameObject);
				pp.life--;
			}
			
			
			
        }

    }
}
