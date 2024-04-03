using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Chunk : MonoBehaviour
{
	public Difficulties dificult;
	[SerializeField] Transform collectableParentTransform;
	private List<Transform> collectableTransform;

	public void Awake()
	{
		collectableTransform = collectableParentTransform.GetComponentsInChildren<Transform>().ToList();
		collectableTransform.RemoveAt(0);
	}

	public bool GetRandomPointTransform(out Transform transform)
	{
		if (collectableTransform.Count > 0)
		{
			int indexRandom = Random.Range(0, collectableTransform.Count - 1);
			transform = collectableTransform[indexRandom];
			return true;
		}
		else
		{
			transform = null;
			Debug.LogError("No collectableTransform");
			return false;
		}
	}
}