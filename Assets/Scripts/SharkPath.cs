using UnityEngine;
using System.Collections;

public class SharkPath : MonoBehaviour {
	public Transform wayPointsContainer;
	public int currentSlot = 1;

	public float minDist;
	public float speed;
	public bool rand = false;
	public bool go = true;

	private Transform[] waypoints;
	#region Properties
	public Transform[] Waypoints { get { return waypoints; } set { waypoints = value; } }
	#endregion
	void Wake() {
	}

	/*
	void Update() {
		float dist = Vector3.Distance(gameObject.transform.position, Waypoints[currentSlot].transform.position);

		if(go) {
			if(dist > minDist) {
				Move();
			} else {
				if(!rand) {
					if(currentSlot + 1 == Waypoints.Length) {
						currentSlot = 0;
					} else {
						currentSlot++;
					}

				} else {
					currentSlot = Random.Range(0, Waypoints.Length);
				}
			}
		}
	}
	*/


	void FixedUpdate() {
		Move();
	}

	private int NextWayPointSlot() {
		if(rand) {
			int tmp;
			do {
				tmp = Random.Range(0, wayPointsContainer.childCount);
			} while(tmp == this.currentSlot);
			this.currentSlot = tmp;
		} else {
			if(++currentSlot > wayPointsContainer.childCount) {
				currentSlot = 1;
			}
		}
		return currentSlot;
	}

	public void Move() {
		if(Vector3.Distance(this.transform.position, wayPointsContainer.GetChild(currentSlot).position) < minDist) {
			NextWayPointSlot();
		}
		Vector3 nextWayPoint = wayPointsContainer.GetChild(currentSlot).position;
		gameObject.transform.LookAt(nextWayPoint);
		gameObject.transform.position = Vector3.Lerp(this.transform.position, nextWayPoint, (speed * Time.fixedDeltaTime));
	}
}
