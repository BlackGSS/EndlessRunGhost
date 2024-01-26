using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
	[SerializeField]
	private float speed = 10;

	[SerializeField]
	private float gravity = 12;

	[SerializeField]
	private float jumpSpeed;

	public bool isDead = false;

	private CharacterController control;
	private Vector3 vector3Movement;

	private float animationDuration = 1.8f;
	private float startTime;

	[SerializeField]
	private Animator anim;

	public SessionData sessionData;


	// Use this for initialization
	void Start()
	{
		control = GetComponent<CharacterController>();
		startTime = Time.time;
	}

	// Update is called once per frame
	void Update()
	{
		if (!sessionData.playerAlive || Time.timeScale <= 0)
			return;

		if (Time.time - startTime < animationDuration)
		{
			control.Move(Vector3.forward * speed * Time.deltaTime);
			return;
		}

		vector3Movement = Vector3.zero;

		if (control.isGrounded)
		{
			jumpSpeed = -0.5f;
		}
		else
		{
			jumpSpeed -= gravity * Time.deltaTime;
		}

		if (Input.GetMouseButton(0))
		{
			if (Input.mousePosition.y < Screen.height / 2)
			{
				if (Input.mousePosition.x > Screen.width / 2)
				{
					vector3Movement.x = speed;
				}
				else
				{
					vector3Movement.x = -speed;
				}
			}
		}

		vector3Movement.y = jumpSpeed;
		vector3Movement.z = speed;

		control.Move(vector3Movement * Time.deltaTime);
	}

	public void SetSpeed(float newLevel)
	{
		NewLevel();
		speed = speed + newLevel;
	}

	private void NewLevel()
	{
		anim.SetTrigger("LevelUp");
	}

	private void OnControllerColliderHit(ControllerColliderHit hit)
	{
		if (hit.point.z > transform.position.z + control.radius && hit.collider.tag == "Enemy")
		{
			Debug.Log(hit.collider);
			Death();
		}
	}

	private void Death()
	{
		sessionData.playerAlive = false;
		sessionData.UpdateScriptable(sessionData);
	}
}