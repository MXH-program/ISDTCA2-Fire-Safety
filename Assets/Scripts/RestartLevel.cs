using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

//---------------------------------------------------------------------------------
// Author		: Vincent
// Date  		: 2021-08-21
// Description	: This is where you write a summary of what the role of this file.
//---------------------------------------------------------------------------------
//#define DEBUG_DrawMousePoint

//[RequireComponent(typeof(Rigidbody))]
public class RestartLevel : MonoBehaviour 
{
	public void RestartScene()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
	}
}
