using UnityEngine;
using System.Collections;
//using System.IO.Ports;

public class Flamingo : MonoBehaviour
{
	public float columnSpeed = 0.1f;
	public float laneSpeed = 0.1f;

	public int columnNow = 0;
	public bool isAlive = true;
	
	float columnSpeedMultiplier = 1.0f;

	SpawnFlamingos settings;

	int laneNow = 0; // 1 is backwards
	int counter = 0;
	
	// Use this for initialization
	public virtual void Start()
	{
		settings = GameObject.Find("GameManager").GetComponent<SpawnFlamingos>();
		isAlive = true;
	}


	public void movementProcess()
	{
		// Read current position
		Vector3 posNew = this.transform.position;

		// Lanes
		if (laneNow >= 1)
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
		laneNow = 1 - laneNow;
	}


	public void SetMovementSpeed(float speed)
	{
		columnSpeedMultiplier = speed;
	}


	public void GoForward()
	{
		if (columnNow < settings.columnTotal - 1)
		{
			columnNow += 1;
		}
	}



	public void GoBackward()
	{
		int mostLeft = columnNow;
		bool[,] map = new bool[settings.columnTotal, 2];

		object[] obj = GameObject.FindGameObjectsWithTag("Flamingo");
		Debug.Log("START");
		foreach (GameObject o in obj) 
		{
			if (!isAlive) continue;
			Debug.Log(o.name);
			int columnInst = o.GetComponent<Flamingo>().getPosition();
			int laneInst = o.GetComponent<Flamingo>().getLane();
			
			if (columnInst < 0 || columnInst >= settings.columnTotal)
			{
				Debug.Log("Warning!: " + columnInst + ", " + laneInst);
				continue;
			}
			map[columnInst, laneInst] = true;

			if (columnInst < mostLeft)
			{
				mostLeft = columnInst;
			}
		}
		Debug.Log("STOP");

		int columnNew = -1;
		for (int i = columnNow; i >= 0; i--)
		{
			if (map[i, laneNow] == false)
			{
				columnNew = i;
			}
		}

		if (columnNew < mostLeft || columnNew < 0)
		{
			DoDie();
		}
		else
		{
			setPosition(columnNew);
		}
	}

	public void setPosition(int column)
	{
		columnNow = column;
	}

	public void setPosition(int column, int lane)
	{
		columnNow = column;
		laneNow = lane;
	}

	public int getPosition()
	{
		return columnNow;
	}


	public int getLane()
	{
		return laneNow;
	}

	public void DoDie()
	{
		RaycastHit hit;
		Vector3 fwd = transform.TransformDirection(Vector3.down);
		if (Physics.Raycast(transform.position, fwd, out hit, 10))
		{
			this.gameObject.transform.parent = hit.transform;
			isAlive = false;
			Debug.Log("YEAH!");
		}
		else
		{
			Debug.Log("Error: Raycast Not found!");
		}
	}
}
