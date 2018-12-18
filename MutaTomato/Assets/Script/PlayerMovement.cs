using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class PlayerMovement : MonoBehaviour 
{
	static Animator anim;
	float horAs;
	float verAs;
	[SerializeField] Vector2 v;
	public Rigidbody2D feet;
	int jAmount;
	[SerializeField] int maxJumpAmount;

	public Vector2 movmentVector;
	[SerializeField] float currentSpeed;
	bool m_FacingRight = true;	

	void Start () 
	{
		//anim = GetComponent<Animator>();
		feet = GetComponent<Rigidbody2D>();
	}

	void FixedUpdate () 
	{
		movmentVector.x = Input.GetAxis("Horizontal");
        horAs = Input.GetAxis("Horizontal"); // Get horzontal value.
		transform.Translate(movmentVector * currentSpeed * Time.deltaTime);
		//anim.SetFloat("Walk",Mathf.Abs(horAs));

		if (horAs > 0 && !m_FacingRight)
		{
			currentSpeed = -currentSpeed;
			Flip();
		}
		else if (horAs < 0 && m_FacingRight)
		{
			currentSpeed = -currentSpeed;
			Flip();
		}
	}

	void Update() 
	{
		if(Input.GetButtonDown("Up"))
		{
			if (jAmount < maxJumpAmount)
			{
				feet.velocity = v;
				jAmount +=1;
			}
		}
	}


	void Flip()
	{
		transform.Rotate(0f, 180f, 0f);
		// Switch the way the player is labelled as facing.
		m_FacingRight = !m_FacingRight;	
	}

	void OnCollisionEnter2D(Collision2D other) 
	{
		jAmount = 0;
	}
}
