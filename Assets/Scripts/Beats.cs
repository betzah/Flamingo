using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Beats : MonoBehaviour 
{
	public float beatDuration = 1.0f;
	public float beatDelayStart = 5.0f;
	public int beatsTotal = 4;

	float accuracy = 0.0f;
	float timer = 0.0f;
	int beatNumber = 0;
	bool isBeatProcessed = false;
	bool isBeatEnabled = false;
	bool isBeatStart = false;

	float score = 0.0f;
	int scoreCounter = 0;

	bool isToTheRight = false;

	GameObject canvasID;
	List<GameObject> objects = new List<GameObject>();


	// Use this for initialization
	void Start ()
	{
		BeatStart();
		canvasID = GameObject.Find("Canvas");
		CanvasAddSprite("UI/UI_Marker", 10.0f, 5.0f);
	}
	
	// Update is called once per frame
	void Update () 
	{
		foreach (GameObject obj in objects)
		{
			Vector3 posNew = obj.transform.position;
			
			posNew.x -= 0.5f;
/*
			if (posNew.x < -5.0f)
				posNew.x += 25.0f;
			*/
			obj.transform.position = posNew;
		}


		if (!isBeatEnabled) return;
		
		if (!isBeatStart)
		{
			beatDelayStart -= Time.deltaTime;
			if (beatDelayStart <= 0.0f)
			{
				beatDelayStart = 0.0f;
				isBeatStart = true;
			}
		}


		timer += Time.deltaTime;
		if (timer >= beatDuration * 1.5f)
		{
			timer -= beatDuration;
			beatNumber++;
			isBeatProcessed = false;
		}
		accuracy = Mathf.Clamp(1.0f - Mathf.Abs((timer - beatDuration) * 2.0f / beatDuration), 0.0f, 1.0f);

	}




	void CanvasAddSprite(string path, float posX, float posY)
	{
		GameObject obj = new GameObject();
		objects.Add(obj);
		obj.transform.parent = canvasID.transform;

		//isToTheRight = (Random.value > 0.5f) ? (true) : (false);
		//SpriteRenderer spr;
		// spr = obj.AddComponent<SpriteRenderer>();
		//spr.sprite = Resources.Load(path, typeof(Sprite)) as Sprite;
		//spr.flipX = isToTheRight;

		obj.AddComponent<SpriteRenderer>();
		obj.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>(path);

		Vector3 posNew = obj.transform.position;
		posNew.x = posX;
		posNew.y = posY;
		posNew.z = 1;
		obj.transform.position = posNew;
	}



	public void BeatHit()
	{
		if (!isBeatProcessed)
		{
			isBeatProcessed = true;
			score = score * (scoreCounter / (scoreCounter + 1)) + accuracy / (scoreCounter + 1);
			scoreCounter++;
		}
	}


	public int BeatGetCount()
	{
		return scoreCounter;
	}


	public float BeatGetAverageAccuracy()
	{
		float average = score;
		score = 0.0f;
		return average;
	}


	public void BeatEnable()
	{
		isBeatEnabled = true;
	}

	public void BeatStart()
	{
		isBeatEnabled = true;
		isBeatStart = true;
	}
}
