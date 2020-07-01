using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileGuidance : MonoBehaviour
{
    public Transform m_Target;

    [Header("Guidance")]
    public float m_GuidanceSpeed;
    public float m_GuidanceSmoothRotation;

    [Header("Boost")]
    public float m_BoostTime;
    public float m_BoostSpeed;

    private Rigidbody m_Body;
    private float m_StartFlightTime;

    public Transform _explosionPrefab;

    public void Start()
    {
        m_Body = GetComponent<Rigidbody>();
        m_StartFlightTime = Time.time;
		
    }

    public void FixedUpdate()
    {
        if (Time.time - m_StartFlightTime < m_BoostTime)
        {
            Debug.Log(">>X:passou >> "+ transform.forward);
            //m_Body.AddForce(transform.forward * m_BoostSpeed * Time.deltaTime, ForceMode.VelocityChange);
        }
        else
        {
            var velocity = (m_Target.position - transform.position).normalized * m_GuidanceSpeed;

            var steering = Vector3.ClampMagnitude(velocity - transform.forward, m_GuidanceSmoothRotation);

            steering = Vector3.ClampMagnitude(velocity + steering , m_GuidanceSpeed);
;
            m_Body.MovePosition(transform.position + steering * Time.deltaTime);
            m_Body.MoveRotation(Quaternion.LookRotation(steering.normalized));
        }
    }

    //private void OnCollisionEnter(Collision collision)
    //{
     //   Destroy(gameObject);
    //}

    private void OnTriggerEnter(Collider other)
    {
		if(other.gameObject.GetComponent<PlayerPoints>() != null){
			if (other.gameObject.GetComponent<PlayerPoints>().typePlayer == m_Target.GetComponent<PlayerPoints>().typePlayer)
			{
				Debug.Log(">>Missil:");
				Destroy(gameObject);

				Transform explosion = Instantiate(_explosionPrefab, gameObject.transform.position, gameObject.transform.rotation);

				other.gameObject.GetComponent<Rigidbody>().AddForce(other.transform.up * 10f, ForceMode.VelocityChange);
			}
		}
    }
}
