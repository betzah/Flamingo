using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

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
	float scoreAveraged = 0.0f;

	bool isToTheRight = false;

	GameObject canvasID;
	List<GameObject> objects = new List<GameObject>();

	GameObject left, right;
	GameObject[] beat;

	// Use this for initialization
	void Start ()
	{
		BeatStart();
		isToTheRight = (Random.value > 0.5f) ? (false) : (true);
		canvasID = GameObject.Find("Canvas");
		left = GameObject.Find("Left");
		right = GameObject.Find("Right");

		beat = new GameObject[4];
		for (int i = 0; i < beat.Length; i++)
		{
			beat[i] = GameObject.Find("Beat" + i);
		}
		//CanvasAddSprite("UI/UI_Marker", 10.0f, 5.0f, isToTheRight);
	}
	
	// Update is called once per frame
	void Update ()
	{
		foreach (GameObject obj in objects)
		{
			Vector3 posNew = obj.transform.position;
			
//			posNew.x -= 0.5f;
/*
			if (posNew.x < -5.0f)
				posNew.x += 25.0f;
			*/
			obj.transform.position = posNew;
		}

		UIProcess();


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
			isToTheRight = (Random.value > 0.5f) ? (false) : (true);
		}
		accuracy = Mathf.Clamp(1.0f - Mathf.Abs((timer - beatDuration) * 2.0f / beatDuration), 0.0f, 1.0f);

	}


	void UIProcess()
	{
		if (isToTheRight)
		{
			left.GetComponent<Image>().enabled = false;
			right.GetComponent<Image>().enabled = true;

			Vector3 scale = right.GetComponent<RectTransform>().localScale;
			float size = 0.75f + 0.5f * Mathf.Sin(Mathf.PI * (timer - 0.5f));
			scale.x = size;
			scale.y = size;
			right.GetComponent<RectTransform>().localScale = scale;
		}
		else
		{
			left.GetComponent<Image>().enabled = true;
			right.GetComponent<Image>().enabled = false;

			Vector3 scale = left.GetComponent<RectTransform>().localScale;
			float size = 0.75f + 0.5f * Mathf.Sin(Mathf.PI * (timer - 0.5f));
			scale.x = size;
			scale.y = size;
			left.GetComponent<RectTransform>().localScale = scale;
		}
	}


	/*
	void CanvasAddSprite(string path, float posX, float posY)
	{
		CanvasAddSprite(path, posX, posY, false);
	}

	void CanvasAddSprite(string path, float posX, float posY, bool flip)
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
		obj.GetComponent<SpriteRenderer>().flipX = flip;

		Vector3 posNew = obj.transform.position;
		posNew.x = posX;
		posNew.y = posY;
		posNew.z = 1;
		obj.transform.position = posNew;
	}
	*/


	public void BeatHit(bool isRight)
	{
		if (!isBeatProcessed)
		{
			isBeatProcessed = true;
			if (isRight == isToTheRight)
			{
				score += accuracy; //score * (scoreCounter / (scoreCounter + 1)) + accuracy / (scoreCounter + 1);
				
				Debug.Log("Beat Hit: Correct! Score: " + scoreAveraged);
			}
			else
				Debug.Log("Beat Hit: Wrong!");
		}
		else
			Debug.Log("Beat Hit: Double Click!");

	}


	public int BeatGetCount()
	{
		return beatNumber;
	}


	public float BeatGetAverageAccuracy()
	{
		scoreAveraged = score / (beatNumber + 1);
		score = 0.0f;
		beatNumber = 0;

		return scoreAveraged;
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
