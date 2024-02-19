using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chunk : MonoBehaviour
{
	public Difficulties dificult;
	[SerializeField] Transform collectableParentTransform;
	private Transform[] collectableTransform;

	public void Awake()
	{
		collectableTransform = collectableParentTransform.GetComponentsInChildren<Transform>();
	}

	public bool GetRandomPointTransform(out Transform transform)
	{
		if (collectableTransform.Length > 0)
		{
			int indexRandom = Random.Range(0, collectableTransform.Length - 1);
			transform = collectableTransform[indexRandom];
			return true;
		}
		else
		{
			transform = null;
			return false;
		}
	}
}
