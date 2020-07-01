using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectCollision : MonoBehaviour
{
	
	public Item effect;
	public int amount;
	private int speed;
	
	public enum Item{
		coin,
		box_ammo,
		box_missile,
		health_up,
        speed_up
	}
	
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
	
	private void OnTriggerEnter(Collider other)
	{
		
        PlayerPoints pp = other.GetComponent<PlayerPoints>();
		
		if(pp != null)
		{
			if (effect == Item.coin) {
				pp.score += amount;
			}
			if (effect == Item.box_ammo) {
				pp.ammo += amount;
			}

			if (effect == Item.box_missile) {
				PlayerShot ps = other.GetComponent<PlayerShot>();
				
				Transform arrow1 = Instantiate(ps.missil, ps.canhao.position, Quaternion.identity);
				arrow1.GetComponent<MissileGuidance>().m_Target = ps.target;
                
                arrow1.GetComponent<Rigidbody>().velocity = other.GetComponent<Rigidbody>().velocity * 10;
				arrow1.GetComponent<Rigidbody>().angularVelocity = other.GetComponent<Rigidbody>().angularVelocity;


			}
			if (effect == Item.health_up) {
				pp.life += amount;
			}
			
			if (effect == Item.speed_up) {
				speed++;
				if (speed < 5)
				{
					other.GetComponent<CarKinematics>().m_MaxMotorTorque+= 100;
				}
			}
			Destroy(gameObject);
		}
	}
}
