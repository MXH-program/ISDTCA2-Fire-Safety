using UnityEngine;
using System.Collections;

//---------------------------------------------------------------------------------
// Author		: Vincent
// Date  		: 2021-08-21
// Description	: This is where you write a summary of what the role of this file.
//---------------------------------------------------------------------------------
//#define DEBUG_DrawMousePoint

//[RequireComponent(typeof(Rigidbody))]
public class LiftManager : MonoBehaviour 
{
	#region Variables
	//===================
	// Public Variables
	//===================
	//[Header("Header / Separator in Inspector")]
    //[Tooltip("Pop up description if put on top of variable.")]
	//public GameObject go;
	
	//====================================
	// [SerializeField] Private Variables
	//====================================
	//[SerializeField] private int size;


	//===================
	// Private Variables
	//===================
	//private float _speed;

#if DEBUG_DrawMousePoint
    public bool         DrawMousePoint = false;
#endif

	#endregion
	
	#region Unity Methods
	//---------------------------------------------------------------------------------
	// protected mono methods. 
	// Unity5: Rigidbody, Collider, Audio and other Components need to use GetComponent<name>()
	//---------------------------------------------------------------------------------
	//---------------------------------------------------------------------------------
	// Awake is when the file is just loaded ... for other function blah blah
	//---------------------------------------------------------------------------------
	protected void Awake() 
	{
	}

	//---------------------------------------------------------------------------------
	// Start is when blah blah
	//---------------------------------------------------------------------------------
	protected void Start() 
	{
	}
	
	//---------------------------------------------------------------------------------
	// XXX is when blah blah
	//---------------------------------------------------------------------------------
	protected void Update() 
	{
       
    }

	//---------------------------------------------------------------------------------
	// FixedUpdate for Physics update
	//---------------------------------------------------------------------------------
	protected void FixedUpdate() 
	{
	}
	
	//---------------------------------------------------------------------------------
	// XXX is when blah blah
	//---------------------------------------------------------------------------------
	protected void OnEnable()
	{
	}

	//---------------------------------------------------------------------------------
	// XXX is when blah blah
	//---------------------------------------------------------------------------------
	protected void OnDestroy()
	{
	}
	#endregion

	#region Own Methods
	//  Use PascalCase for methods
	/// <summary>
	/// Write a summary of the method. Then when you hover over the method
	/// this summary and how to use will pop up. 
	/// <para/>
	/// </summary>
	/// <param name="speed">A reference to the Speed variable.</param>
	//private void MoveAgent(Float speed) {
	//}
	#endregion

#if DEBUG_TurretPointAtMouse_DrawMousePoint
    private void OnDrawGizmos()
    {
        if (DrawMousePoint && Application.isPlaying)
        {
            Gizmos.color = Color.white;
            Gizmos.DrawWireSphere(mousePoint3D, 0.2f);
            Gizmos.DrawLine(transform.position, mousePoint3D);
        }
    }
#endif

	private void OnCollisionStay(Collision collision)
	{
		if(collision.transform.name.Contains("moniplayer"))
		{
            transform.Translate(-transform.up * 0.01f, Space.World);
        }
	}
}
