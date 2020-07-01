using UnityEngine;

[RequireComponent(typeof(CarKinematics))]
public class CarController : MonoBehaviour
{
    private CarKinematics m_CarKinematics;

    [Header("Player Input Names")]
    public string m_HorizontaAxisName = "Horizontal";
    public string m_VerticalAxisName = "Vertical";
    public string m_BrakeButtonName = "Brake";

    public Transform[] _wheel;   //Base da metralhadora

    private float _nextFire;
	
	[SerializeField]
	private Transform _dust;   //Base da metralhadora
	
	[SerializeField]
    private CarKinematics m_Car;
	
    private void Awake()
    {
        m_CarKinematics = GetComponent<CarKinematics>();
    }

    public void Update()
    {

        //Debug.Log("AxisHorizontal:" + Input.GetAxis(m_HorizontaAxisName));

        if (Input.GetAxis(m_HorizontaAxisName) != 0)
        {
            m_CarKinematics.Horizontal = Input.GetAxis(m_HorizontaAxisName);

            if (Time.time > _nextFire && m_Car.GetSpeed() < 15f)
            {
                //_nextFire = Time.time + 5f;

				//Transform arrow1 = Instantiate(_dust, _wheel[0].position, _wheel[0].rotation);
				//arrow1.GetComponent<ParticleSystem>().Play();
				
				//Transform arrow2 = Instantiate(_dust, _wheel[1].position, _wheel[1].rotation);
				//arrow2.GetComponent<ParticleSystem>().Play();
            }
        }

        if (Input.GetAxis(m_VerticalAxisName) != 0)
        {
            m_CarKinematics.Vertical = Input.GetAxis(m_VerticalAxisName);

            if (Time.time > _nextFire && m_Car.GetSpeed() < 15f)
            {
				_nextFire = Time.time + 5f;
				
				Transform arrow3 = Instantiate(_dust, _wheel[0].position, _wheel[0].rotation);
				arrow3.GetComponent<ParticleSystem>().Play();
				
				Transform arrow4 = Instantiate(_dust, _wheel[1].position, _wheel[1].rotation);
				arrow4.GetComponent<ParticleSystem>().Play();
            }
        }
        
        m_CarKinematics.Brake = Input.GetButton(m_BrakeButtonName);
    }
}
