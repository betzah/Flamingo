using UnityEngine;
using System.Collections;

public class Beats : MonoBehaviour {

	public float beatDuration = 1.0f;
	public float beatDelayStart = 5.0f;

	float accuracy = 0.0f;
	float timer = 0.0f;
	int beatNumber = 0;
	bool isBeatProcessed = false;
	bool isBeatEnabled = false;
	bool isBeatStart = false;

	float score = 0.0f;
	int scoreCounter = 0;

	// Use this for initialization
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void Update () 
	{
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

	void BeatHit()
	{
		if (!isBeatProcessed)
		{
			isBeatProcessed = true;
			score += accuracy;
			scoreCounter++;
		}
	}

	
	void BeatEnable()
	{
		isBeatEnabled = true;
	}
	
	void BeatStart()
	{
		isBeatEnabled = true;
		isBeatStart = true;
	}
}
