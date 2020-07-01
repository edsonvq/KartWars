using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class WindRigidbody : MonoBehaviour
{
    private Rigidbody m_Body;

    public List<WindArea> WindAreas { get; set; } = new List<WindArea>();

    public void FixedUpdate()
    {
        foreach (WindArea wind in WindAreas)
            m_Body.AddForce(wind.WindForce);
    }

    private void Awake()
    {
        m_Body = GetComponent<Rigidbody>();
    }
}
