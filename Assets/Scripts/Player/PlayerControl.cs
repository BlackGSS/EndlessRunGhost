using System.Collections.Generic;
using Neisum.ScriptableUpdaters;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerControl : MonoBehaviour, IScriptableUpdaterListener<PlayerData>
{
	//TODO: Move anim behaviour to another script
	[SerializeField] private Animator anim;

	[SerializeField] PlayerDataUpdater playerDataUpdater;
	[SerializeField] SessionDataUpdater sessionData;
	[SerializeField] AudioClip hitPlayerClip;
	[SerializeField] AudioClip levelUpClip;
	private float speed;
	private float gravity;
	private float jumpSpeed;

	private CharacterController control;
	private Vector3 vector3Movement;
	private bool isInvincible = false;

	private float animationDuration = 1.8f;
	private float startTime;

	public bool IsInvincible { set { isInvincible = value; playerDataUpdater.data.isInvincible = value; } }

	void Start()
	{
		//TODO: RequireComponent CharacterController
		control = GetComponent<CharacterController>();
		startTime = Time.time;
		speed = playerDataUpdater.data.speed;
		gravity = playerDataUpdater.data.gravity;
		jumpSpeed = playerDataUpdater.data.jumpSpeed;
	}

	void Update()
	{
		if (!sessionData.data.playerAlive || Time.timeScale <= 0)
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
			if (!IsPointerOverUIObject())
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

	private void NewLevel()
	{
		anim.ResetTrigger("LevelUp");
		anim.SetTrigger("LevelUp");
		SoundSystem.PlaySound(levelUpClip, 0.5f);
	}

	private void Death()
	{
		if (!isInvincible)
		{
			SoundSystem.PlaySound(hitPlayerClip, 0.8f);
			sessionData.data.playerAlive = false;
			sessionData.Notify();
		}
	}

	public void ScriptableResponse(PlayerData data)
	{
		if (speed != data.speed)
		{
			speed = data.speed;
			NewLevel();
		}
	}
	private bool IsPointerOverUIObject()
	{
		PointerEventData eventDataCurrentPosition = new PointerEventData(EventSystem.current);
		eventDataCurrentPosition.position = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
		List<RaycastResult> results = new List<RaycastResult>();
		EventSystem.current.RaycastAll(eventDataCurrentPosition, results);
		return results.Count > 0;
	}
}