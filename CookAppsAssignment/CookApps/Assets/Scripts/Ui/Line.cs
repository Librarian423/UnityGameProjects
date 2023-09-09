using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Line : MonoBehaviour
{
	[SerializeField] private int count = 0;

	public bool IsFull()
	{
		if (count >= 3)
		{
			return false;
		}
		return true;
	}
	public void IncreaseCount()
	{
		if (count < 3) 
		{
			count++;
			//players.Add(icon);
		}
	}

	public void DecreaseCount()
	{
		if (count > 0)
		{
			count--;
			//players.Remove(icon);
		}
	}
}
