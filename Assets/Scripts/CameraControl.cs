using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
	[SerializeField]
	private Transform target;
	private Vector3 _offset;
	private Vector3 _vector3Movement;

	[SerializeField]
	private float _speedMoving;

	private float _transition = 0f;
	private float _animationDuration = 1.5f;
	private Vector3 _offsetAnim = new Vector3(0, 5, 5);

	// Use this for initialization
	void Start()
	{
		_offset = transform.position - target.position;
	}

	// Update is called once per frame
	void Update()
	{
		_vector3Movement = target.position + _offset;

		Vector3 moveTo = Vector3.Lerp(transform.position, target.position, Time.deltaTime * _speedMoving);

		_vector3Movement.x = moveTo.x;

		//mirar más sobre Mathf.Clamp
		_vector3Movement.y = Mathf.Clamp(_vector3Movement.y, 4, 6);

		if (_transition > 1.0f)
		{
			transform.position = _vector3Movement;
		}
		else
		{
			transform.position = Vector3.Lerp(_vector3Movement + _offsetAnim, _vector3Movement, _transition);
			transform.LookAt(target.position);
			_transition += Time.deltaTime * 1 / _animationDuration;
		}
	}

	public void SetPlayerTransform(PlayerControl player)
	{
		target = player.transform;
	}
}