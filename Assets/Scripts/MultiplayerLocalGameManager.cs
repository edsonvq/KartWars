using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MultiplayerLocalGameManager : MonoBehaviour
{
    [Header("UI (User Interface)")]

    [SerializeField]
    private Text m_SpeedTextP1;
    [SerializeField]
    private Text m_SpeedTextP2;
	
    [SerializeField]
    private Text m_ScoreTextP1;
    [SerializeField]
    private Text m_ScoreTextP2;
	
    [SerializeField]
    private Text m_LifeTextP1;
    [SerializeField]
    private Text m_LifeTextP2;
	
    [SerializeField]
    private Text m_AmmoTextP1;
    [SerializeField]
    private Text m_AmmoTextP2;
	
    [SerializeField]
    private Text m_TimeText;

    [Header("Veicles")]
    [SerializeField]
    private CarKinematics m_CarP1;
    [SerializeField]
    private CarKinematics m_CarP2;

    [Header("Gameplay")]
    [SerializeField]
    private float m_MaxTime = 180;
    private float m_StartTime;

	
    private int score_p1;
	private int score_p2;
	
    private int life_p1;
    private int life_p2;

    private int ammo_p1;
    private int ammo_p2;

	private PlayerPoints pp1;
	private PlayerPoints pp2;
	
    public void Start()
    {
        m_StartTime = Time.time;
		
		GameObject[] objs = GameObject.FindGameObjectsWithTag("Player");
		Debug.Log("A: "+objs.Length);
		
       for (var i = 0; i < objs.Length; i++){
			if(objs[i].GetComponent<PlayerPoints>().typePlayer == 1){
				pp1 = objs[i].GetComponent<PlayerPoints>();
			}
			if(objs[i].GetComponent<PlayerPoints>().typePlayer == 2){
				pp2 = objs[i].GetComponent<PlayerPoints>();
			}
		}
			
			
		score_p1 = pp1.score;
		score_p2 = pp2.score;
		
		life_p1 = pp1.life;
		life_p2 = pp2.life;

		ammo_p1 = pp1.ammo;
		ammo_p2 = pp2.ammo;
			
    }
	
    public void UpdateUI()
    {
		
        m_SpeedTextP1.text = m_CarP1.GetSpeed().ToString("0");
        m_SpeedTextP2.text = m_CarP2.GetSpeed().ToString("0");
		
        m_ScoreTextP1.text = score_p1.ToString("0");
        m_ScoreTextP2.text = score_p2.ToString("0");
		
		m_LifeTextP1.text = life_p1.ToString("0");
        m_LifeTextP2.text = life_p2.ToString("0");
		
		m_AmmoTextP1.text = ammo_p1.ToString("0");
        m_AmmoTextP2.text = ammo_p2.ToString("0");
		
        m_TimeText.text = (m_MaxTime - (Time.time - m_StartTime)).ToString("0");
    }

    public void LateUpdate()
    {
        UpdateUI();
    }
	
    public void Update() {
		
		score_p1 = pp1.score;
		score_p2 = pp2.score;
		
		life_p1 = pp1.life;
		life_p2 = pp2.life;

		ammo_p1 = pp1.ammo;
		ammo_p2 = pp2.ammo;
		
		
        PlayerPrefs.SetInt("score_p1", score_p1);
		PlayerPrefs.SetInt("score_p2", score_p2);
		
		if(life_p1 == 0){
			LoadScene("win2");
		}
		
		if(life_p2 == 0){
			LoadScene("win1");
		}
		
		
    }
	
    public void GameOver()
    {

		
		//PlayerPrefs.SetInt("score", score);

        //StartCoroutine(SaveGame());

        Destroy(this.gameObject);
		
        LoadScene("win1");
    }

	
	
    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
