using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Magnetism : MonoBehaviour
{
    public enum MagnetismType { Repulsion = -1, None = 0, Attraction = 1};

    public MagnetismType m_Type = MagnetismType.None;
    public Transform m_CenterPoint;
    public float m_Radius;
    public float m_Force;
    public float m_StopRadius;
    public LayerMask m_Layers;
	public bool reverse = false;
	private Rigidbody body1;
	private Rigidbody body2;
    private void FixedUpdate()
    {
        Collider[] colliders = Physics.OverlapSphere(m_CenterPoint.position, m_Radius, m_Layers);

        float signal = (int)m_Type;

        foreach (var collider in colliders)
        {

			body1 = collider.GetComponent<Rigidbody>();
			body2 = GetComponent<Rigidbody>();
			
            if (!body1) continue;

            Vector3 direction = m_CenterPoint.position - body1.position;

			if(!reverse){
				direction = m_CenterPoint.position - body1.position;
			}else{
				direction = body1.position - m_CenterPoint.position;
			}
            float distance = direction.magnitude;

            if (distance < m_StopRadius) continue;

			if(!reverse){
				body1.AddForce(direction.normalized * (m_Force / distance) * body1.mass * Time.deltaTime * signal);
			}else{
				body2.AddForce(direction.normalized * (m_Force / distance) * body2.mass * Time.deltaTime * signal);
			}
			

            
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = new Color(0, 0, 0.5f, 0.2f);
        Gizmos.DrawSphere(m_CenterPoint.position, m_Radius);

        Gizmos.color = new Color(0, 0, 0, 0.2f);
        Gizmos.DrawSphere(m_CenterPoint.position, m_StopRadius);
    }
}
