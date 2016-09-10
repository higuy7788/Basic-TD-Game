using UnityEngine;
using System.Collections;
using System;

public class ListEnemy: IComparable<ListEnemy> {

	public Transform item;

	public ListEnemy(Transform newItem){
		item = newItem;
	}

	public int CompareTo(ListEnemy other){
		if (other == null)
			return 1;
		if (item == null)
			return 1;
		else if (other.item == null)
			return 0;
		return (int) (other.item.gameObject.GetComponent<NavMeshAgent>().remainingDistance - item.gameObject.GetComponent<NavMeshAgent>().remainingDistance);
	}
}
