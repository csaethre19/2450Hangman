using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleCameraComponents : MonoBehaviour
{
	public VHSPostProcessEffect glitch;

	void Start(){
		glitch = GetComponent<VHSPostProcessEffect>();
	}
	
	public void enableGlitch(){
		glitch.enabled = true;
	}
	
	public void disableGlitch(){
		glitch.enabled = false;
	}
}