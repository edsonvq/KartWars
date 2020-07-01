using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShot : MonoBehaviour
{
	
    public float _force = 50.0f;
	public float _fireRate = 0.1f; 
	private float _nextFire;
	
	public float _radius;
	public Transform _centerPoint;
	public Rigidbody _shotPrefab;   //Projétil
	public Transform[] _shotSpawns; //Onde sairam as balas
	public Transform[] _shotBase;   //Base da metralhadora 
	public Transform[] _shotParticles;   //Base da metralhadora
	
	public string _tagTarget;   //Base da metralhadora 
    public LayerMask _layers;

	private PlayerPoints pp;
	
	
	public Transform canhao;
	public Transform missil;
	public Transform target;
	
    public void Start()
    {
		
		pp = GetComponent<PlayerPoints>();
				
		_shotParticles[0].GetComponent<ParticleSystem>().Emit(0);
		_shotParticles[1].GetComponent<ParticleSystem>().Emit(0);
	}
	
    public void Update()
    {
        Collider[] colliders = Physics.OverlapSphere(_centerPoint.position, _radius, _layers);

        foreach (var collider in colliders)
        {
			if(collider.gameObject != this.gameObject && collider.gameObject.tag == _tagTarget){
				Rigidbody body_collider = collider.GetComponent<Rigidbody>();
				
				if (!body_collider) continue;

				Vector3 direction = body_collider.position - _centerPoint.position;

				//direction = _centerPoint.position - body_collider.position;

				//float distance = direction.magnitude;
				//if (distance < m_StopRadius) continue;
				
				
				//Angulo igual ao inspector
				//Debug.Log(">>X:"+braco_teste.localEulerAngles.x);
				// Print the rotation around the global Y Axis
				//Debug.Log(">>Y:"+braco_teste.localEulerAngles.y);
				// Print the rotation around the global Z Axis
				//Debug.Log(">>Z:"+braco_teste.localEulerAngles.z);
		
				//float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
				//Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
				//braco_teste.rotation = Quaternion.Slerp(braco_teste.rotation, q, Time.deltaTime * 2);
				//Debug.Log(">>Y:"+angle);
				//braco_teste.LookAt(body_collider.position);
				//float angle = braco_teste.localEulerAngles.y;
				
				Vector3 targetDir = body_collider.position - _centerPoint.position;
				float angle = Vector3.SignedAngle(targetDir, _centerPoint.forward, Vector3.up);
				//if (angle < -5.0F)
				//	Debug.Log("turn left:"+angle);
				//else if (angle > 5.0F)
				//	Debug.Log("turn right:"+angle);
				//else
				//	Debug.Log("forward");
				
				Quaternion q = Quaternion.LookRotation(direction);
				
				
				
				if((angle < 0 && angle > -30) || (angle > 0 && angle < 45)){
					_shotBase[0].rotation = Quaternion.Lerp(_shotBase[0].rotation, q, Time.deltaTime * 5);
					_shotBase[1].rotation = Quaternion.Lerp(_shotBase[1].rotation, q, Time.deltaTime * 5);
				}
				
				
				if(Time.time > _nextFire  && ((angle < 0 && angle > -30) || (angle > 0 && angle < 45)) && pp.ammo > 0) {
					pp.ammo--;
					_nextFire = Time.time + _fireRate;
					
					Rigidbody body = GetComponent<Rigidbody>();
					
					Rigidbody arrow1 = Instantiate<Rigidbody>(_shotPrefab, _shotSpawns[0].position, _shotSpawns[0].rotation);
					arrow1.velocity = body.velocity;
					arrow1.angularVelocity = body.angularVelocity;
					
					arrow1.AddForce(_shotSpawns[0].up * _force, ForceMode.VelocityChange);
					
					
					Rigidbody arrow2 = Instantiate<Rigidbody>(_shotPrefab, _shotSpawns[1].position, _shotSpawns[1].rotation);
					arrow2.velocity = body.velocity;
					arrow2.angularVelocity = body.angularVelocity;
					
					arrow2.AddForce(_shotSpawns[1].up * _force, ForceMode.VelocityChange);
					
					
					//_shotParticles[0].GetComponent<ParticleSystem>().enableEmission = true;
					//_shotParticles[1].GetComponent<ParticleSystem>().enableEmission = true;
					//_shotParticles[2].GetComponent<ParticleSystem>().enableEmission = true;
					//_shotParticles[3].GetComponent<ParticleSystem>().enableEmission = true;
					
					_shotParticles[0].GetComponent<ParticleSystem>().Emit(50);
					_shotParticles[1].GetComponent<ParticleSystem>().Emit(50);
				}
				else{
					//_shotParticles[0].GetComponent<ParticleSystem>().enableEmission = false;
					//_shotParticles[1].GetComponent<ParticleSystem>().enableEmission = false;
					//_shotParticles[2].GetComponent<ParticleSystem>().enableEmission = false;
					//_shotParticles[3].GetComponent<ParticleSystem>().enableEmission = false;
					_shotParticles[0].GetComponent<ParticleSystem>().Emit(0);
					_shotParticles[1].GetComponent<ParticleSystem>().Emit(0);
				}
				
				
				
			}
        }
		
    }
	
	private void OnDrawGizmos()
    {
        Gizmos.color = new Color(0, 0, 0.5f, 0.2f);
        Gizmos.DrawSphere(_centerPoint.position, _radius);
    }
}
