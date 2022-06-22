using UnityEngine;
using System.Collections;

public class SetSortingOrder : MonoBehaviour 
{
	public int sortingOrder = 1;

	void Start () 
	{
		MeshRenderer mr = GetComponent<MeshRenderer>();
		if(mr != null) mr.sortingOrder = sortingOrder;
	}
}
