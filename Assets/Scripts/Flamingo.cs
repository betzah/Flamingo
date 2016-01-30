using UnityEngine;
using System.Collections;

public class Flamingo : MonoBehaviour
{


	public float columnSpeed = 0.1f;
	public float laneSpeed = 0.1f;

	float columnSpeedMultiplier = 1.0f;

	SpawnFlamingos settings;

	bool laneNow = false; // true is backwards
	int columnNow = 0;
	int counter = 0;
	bool isAlive = true;

	// Use this for initialization
	public virtual void Start()
	{
		settings = GameObject.Find("GameManager").GetComponent<SpawnFlamingos>();
		columnNow = settings.columnTotal / 2;

	}


	public void movementProcess()
	{
		// Read current position
		Vector3 posNew = this.transform.position;

		// Lanes
		if (laneNow)
		{
			posNew.z = Mathf.Clamp(posNew.z + laneSpeed, 0.0f, settings.laneWidth);
		}
		else
		{
			posNew.z = Mathf.Clamp(posNew.z - laneSpeed, 0.0f, settings.laneWidth);
		}

		// Colomns
		float afwijking = posNew.x - (settings.columnWidth * (float)columnNow);
		posNew.x -= Mathf.Clamp(afwijking, -columnSpeed, columnSpeed);

		// Save new position
		this.transform.position = posNew;
	}


	public void DoSwitchLane()
	{
		laneNow = !laneNow;
	}


	public void SetMovementSpeed(float speed)
	{
		columnSpeedMultiplier = speed;
	}


	public void GoForward()
	{
		if (columnNow < settings.columnTotal)
		{
			columnNow += 1;
		}
		else
		{
			// flamingo dead
		}
	}



	public void GoBackward()
	{
		columnNow -= 1;
		/*for (int i = 0; i < settings.listOfFlamingos.; i++)
		{ 
			
		}*/
	}

	public void DoDie()
	{
		/*RaycastHit hit;
		Vector3 fwd = transform.TransformDirection(Vector3.down);
		if (Physics.Raycast(transform.position, fwd, out hit, 10))
		{
			this.gameObject.transform.parent = hit.transform;
			isAlive = false;
		}*/
	}
}
