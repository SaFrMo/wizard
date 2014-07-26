using UnityEngine;
using System.Collections;

public class Wizard : MonoBehaviour {

	public static string SELECTED_SPELL = "No Spell";
	public static bool going = false;
	public static bool returning = false;
	public static bool phasing = false;
	public static void Go() { going = true; }
	public static void Stop() { going = false; }

	public static GameObject WIZARD;

	public static void ReturnSpell()
	{
		returning = true;
	}

	private void Start ()
	{
		startPosition = transform.position;
		animator = GetComponentInChildren<Animator>();
		Stop ();
		WIZARD = gameObject;
	}

	public float speed = 3f;

	private Vector3 startPosition;
	private bool climbingLadder = false;
	private Animator animator;

	private void OnCollisionEnter2D (Collision2D c)
	{
		if (c.collider.gameObject.GetComponent<Ladder>() != null)
		{
			climbingLadder = true;
		}
	}

	private void OnCollisionExit2D (Collision2D c)
	{
		if (c.collider.gameObject.GetComponent<Ladder>() != null)
			climbingLadder = false;
	}

	public void AnimateSpell (Spell.SpellType s)
	{
		switch (s)
		{
		case Spell.SpellType.Earth:
			animator.SetTrigger("CastMountain");
			break;

		case Spell.SpellType.Ice:
			animator.SetTrigger("CastIce");
			break;

		case Spell.SpellType.Lightning:
			animator.SetTrigger("CastLightning");
			break;

		case Spell.SpellType.Rain:
			animator.SetTrigger("CastRain");
			break;

		case Spell.SpellType.Wind:
			animator.SetTrigger("CastWind");
			break;

		case Spell.SpellType.Return:
		case Spell.SpellType.Phase:
			animator.SetTrigger("CastReturnOrPhase");
			break;
		}
	}

	private Vector3 targetPos = Vector3.zero;
	private Vector3 lastPos;
	private bool falling;

	private void Update ()
	{
		if (transform.position.y < lastPos.y)
			falling = true;
		else 
			falling = false;
		lastPos = transform.position;

		AnimatorStateInfo currentState = animator.GetCurrentAnimatorStateInfo(0);

		if (returning || phasing) 
		{
			if (returning) targetPos = startPosition;
			else if (phasing) targetPos = startPosition + -Vector3.right * 3f;

			rigidbody2D.gravityScale = 0;

			animator.SetTrigger ("CastReturnOrPhase");

			returning = false;
			phasing = false;
		}
		if (currentState.IsName("ReturnOrPhaseAppear") && targetPos != Vector3.zero)
		{
			transform.position = targetPos; 
			rigidbody2D.gravityScale = 1f;
			targetPos = Vector3.zero;
		}

		if (!going) {
			animator.SetBool("Moving", false);
			return;
		}
		else { animator.SetBool ("Moving", true); }


		if (currentState.IsName("Walking") || currentState.IsName("Idle"))
		{
			rigidbody2D.velocity = (climbingLadder ? Vector2.up : Vector2.right) 
				* (falling ? 0 : speed);
			print (falling);
		}
	}


}
