using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindArea : MonoBehaviour
{
    public Vector3 m_Direction = Vector3.zero;
    public bool m_UseRandomDirection;
    public float m_RandomDirectionTimeRate;
    public float m_MinWindForce;
    public float m_MaxWindForce;

    public Vector3 WindForce => m_Direction * Random.Range(m_MinWindForce, m_MaxWindForce);

	
    private void Start()
    {
        InvokeRepeating("ChangeWindDirection", 0.0f, m_RandomDirectionTimeRate);
    }

    public void ChangeWindDirection()
    {
        if (m_UseRandomDirection)
            m_Direction = Random.insideUnitSphere;
    }

    private void OnTriggerEnter(Collider other)
    {
        WindRigidbody body = other.GetComponent<WindRigidbody>();
        if (body != null) body.WindAreas.Add(this);
    }

    private void OnTriggerExit(Collider other)
    {
        WindRigidbody body = other.GetComponent<WindRigidbody>();
        if (body != null) body.WindAreas.Remove(this);
    }
}
