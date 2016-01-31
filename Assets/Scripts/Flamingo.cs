using UnityEngine;
using System.Collections;
//using System.IO.Ports;

public class Flamingo : MonoBehaviour
{
    Animator animator;

    public float columnSpeed = 0.02f;
	public float laneSpeed = 0.01f;

	public int columnNow = 0;
	public bool isAlive = true;

	public float gravity = 0.01f;
	public float jumpSpeed = 0.2f;
	public float jumpFloorDist = 0.05f;

	float vspeed = 0.0f;
	float ystart = 0.0f;

	float columnSpeedMultiplier = 1.0f;

	SpawnFlamingos settings;

	int laneNow = 0; // 1 is backwards
	int counter = 0;

	int mostLeft;
	bool[,] map;


	// Use this for initialization
	public virtual void Start()
	{
        animator = GetComponent<Animator>();
        settings = GameObject.Find("GameManager").GetComponent<SpawnFlamingos>();
		isAlive = true;
		ystart = this.transform.position.y;
		
		mostLeft = columnNow;
		map = new bool[settings.columnTotal, 2];
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
		posNew.x -= Mathf.Clamp(afwijking, -columnSpeed * columnSpeedMultiplier, columnSpeed * columnSpeedMultiplier);

		// Jumping
		if (posNew.y < ystart + 0.001f)
		{
			posNew.y = ystart; // Mathf.Round(posNew.y * 100.0f) / 100.0f;
			vspeed = 0.0f;
		} 
		else
		{
			vspeed -= gravity;
			posNew.y += vspeed;
		}

		// Save new position
		this.transform.position = posNew;
	}


	public void doJump()
	{
		//if (this.transform.position.y < ystart + 0.001f)
		//{
			Vector3 posNew = this.transform.position;
			vspeed = jumpSpeed;
			posNew.y += vspeed;
			this.transform.position = posNew;
		//}
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
		updateArray();

		int columnNew = -1;
		for (int i = columnNow; i >= 0; i--)
		{
			if (map[i, laneNow] == false)
			{
				columnNew = i;
				break;
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


	void updateArray()
	{
		object[] obj = GameObject.FindGameObjectsWithTag("Flamingo");

		for (int i = 0; i < settings.columnTotal; i++)
		{
			for (int j = 0; j < 2; j++)
			{
				map[i, j] = false;
			}
		}


		foreach (GameObject o in obj)
		{
			if (!isAlive) continue;
			//Debug.Log(o.name);
			int columnInst = o.GetComponent<Flamingo>().getPosition();
			int laneInst = o.GetComponent<Flamingo>().getLane();
			//Debug.Log("Map[" + columnInst + "," + laneInst + "];");
			if (columnInst < 0 || columnInst >= settings.columnTotal)
			{
				Debug.Log("Warning! : " + columnInst + ", " + laneInst);
				continue;
			}
			map[columnInst, laneInst] = true;

			if (columnInst < mostLeft)
			{
				mostLeft = columnInst;
			}
		}
		/*string str = "";
		for (int i = 0; i < 10; i++)
		{
			for (int j = 0; j < 2; j++)
			{
				str += (map[i, j]) ? (1) : (0);
			}
		}

		Debug.Log(str); //*/
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
            animator.SetBool("isAlive", false);
		}
		else
		{
			Debug.Log("Error: Raycast Not found!");
		}
	}
}
