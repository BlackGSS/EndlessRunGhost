using Neisum.ScriptableUpdaters;
using UnityEngine;

public class PlayerControl : MonoBehaviour, IScriptableEventListener<PlayerData>
{
	//TODO: Move anim behaviour to another script
	[SerializeField]
	private Animator anim;

	[SerializeField] PlayerDataUpdater playerDataUpdater;
	[SerializeField] SessionDataUpdater sessionData;
	private float speed;
	private float gravity;
	private float jumpSpeed;

	private CharacterController control;
	private Vector3 vector3Movement;

	private float animationDuration = 1.8f;
	private float startTime;

	public static PlayerControl Instance;

	void Awake()
	{
		if (Instance == null)
		{
			Instance = this;
			DontDestroyOnLoad(gameObject);
		}
		else
		{
			Destroy(gameObject);
		}
	}

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
		anim.SetTrigger("LevelUp");
	}

	private void OnControllerColliderHit(ControllerColliderHit hit)
	{
		if (hit.point.z > transform.position.z + control.radius)
		{
			if (hit.collider.tag == "Enemy")
				Death();
		}
	}

	private void Death()
	{
		sessionData.data.playerAlive = false;
		sessionData.UpdateScriptable();
	}

	public void ScriptableResponse(PlayerData data)
	{
		speed = data.speed;
		NewLevel();
	}

	void OnDestroy()
	{
		Instance = null;    // because destroy doesn't happen until end of frame
	}
}