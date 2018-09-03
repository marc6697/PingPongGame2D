using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GerakBola : MonoBehaviour {

//Bola
public int force;
Rigidbody2D rigid;

//score
int score1;
int score2;


//textscore
Text scoretext1;
Text scoretext2;

//endofgame
GameObject EndPanel;
Text Juara;

//audio
AudioSource audio;
public AudioClip hitSound;
public AudioSource test;


	// Use this for initialization
	void Start () {
		rigid=GetComponent<Rigidbody2D>();
		Vector2 arah=new Vector2(2,0).normalized;
		rigid.AddForce(arah*force);

		score1=0;
		score2=0;

	scoretext1 = GameObject.Find ("Skor").GetComponent<Text> ();
  scoretext2 = GameObject.Find ("SkorLawan").GetComponent<Text> ();

	EndPanel=GameObject.Find("EndPanel");
	EndPanel.SetActive(false);

	audio=GetComponent<AudioSource>();
//	test1=GetComponent<AudioSource>();
	}

	// Update is called once per frame
	void Update () {

	}



	private void OnCollisionEnter2D (Collision2D coll)
  {
//		test.Play(test);
		audio.PlayOneShot(hitSound);
		if (coll.gameObject.name == "TepiKanan") {
			score1 += 1;
			TampilkanScore ();
			if(score1==5){
				EndPanel.SetActive(true);
				Juara=GameObject.Find("End Juara").GetComponent<Text>();
				Juara.text="Left Side Victory!";
				Destroy(gameObject);
				return;
			}

		ResetBall ();
		Vector2 arah = new Vector2 (2, 0).normalized;
		rigid.AddForce (arah * force);
		}
		if (coll.gameObject.name == "TepiKiri") {
			score2 += 1;
			TampilkanScore ();
			if(score2==5){
				EndPanel.SetActive(true);
				Juara=GameObject.Find("End Juara").GetComponent<Text>();
				Juara.text="Right Side Victory!";
				Destroy(gameObject);
				return;
			}
		ResetBall ();
		Vector2 arah = new Vector2 (-2, 0).normalized;
		rigid.AddForce (arah * force);
		}
		if(coll.gameObject.name=="PemukulKiri" || coll.gameObject.name=="PemukulKanan")
		{
			float sudut=(transform.position.y-coll.transform.position.y)*5f;
			Vector2 arah=new Vector2(rigid.velocity.x,sudut).normalized;
			rigid.velocity=new Vector2(0,0);
			rigid.AddForce(arah*force*2);
		}

  }

	void ResetBall()
	{
		transform.localPosition=new Vector2(0,0);
		rigid.velocity=new Vector2(0,0);
	}

	void TampilkanScore ()
  {
  Debug.Log ("Score 1: " + score1 + " Score 2: " + score2);
  scoretext1.text = score1 + "";
  scoretext2.text = score2 + "";
  }
}
