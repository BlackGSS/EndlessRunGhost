using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
	[SerializeField]
	private float _speedMoving = 8;
	private Transform target;
	private Vector3 _offset;
	private Vector3 _vector3Movement;
	private float _transition = 0f;
	private float _animationDuration = 1.5f;
	private Vector3 _offsetAnim = new Vector3(0, 5, 5);

	void LateUpdate()
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
		_offset = transform.position - target.position;
	}

	public void GivePlayerCamera(PlayerControl player)
	{
		player.TryGetComponent(out CircleSync component);
		component?.SetCamera(GetComponent<Camera>());
	}
}