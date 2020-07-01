using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleManager : MonoBehaviour
{
	
	
    public ParticleSystem particles;
	
    // Start is called before the first frame update
    void Start()
    {
		//ParticleSystem.MainModule psMain = particleLauncher.main;
		//ParticleSystem.ShapeModule psShape = particleLauncher.shape;
		//psShape.radius = 1;
		//psMain.startLifetime = 1.0f;
		//psMain.startSpeed = 30;
		//particleLauncher.Emit (1);

    }

    // Update is called once per frame
    void Update()
    {
        if(Time.timeSinceLevelLoad > 0.24f) {
            particles.Pause();
        }
    }
}
