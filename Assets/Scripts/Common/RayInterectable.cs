using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using NewtonVR;

public class RayInterectable : MonoBehaviour 
{
	public NVRHand AttachedHand = null;
	/*
	public virtual bool IsAttached
	{
		get
		{
			return AttachedHand != null;
		}
	}
	*/	
	public virtual void BeginInteraction(NVRHand hand)
	{
		AttachedHand = hand;
	}

	public virtual void EndInteraction()
	{
		AttachedHand = null;
	}

	public virtual void InteractingUpdate(NVRHand hand)
	{
		if (hand.UseButtonUp == true)
		{
			UseButtonUp();
		}

		if (hand.UseButtonDown == true)
		{
			UseButtonDown();
		}
	}

	public virtual void UseButtonUp()
	{

	}

	public virtual void UseButtonDown()
	{

	}
}
