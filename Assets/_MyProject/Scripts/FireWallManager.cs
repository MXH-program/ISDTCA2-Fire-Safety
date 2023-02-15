using UnityEngine;
using System.Collections;
public class FireWallManager : MonoBehaviour 
{
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

	public GameObject GAMEOVER;
    public GameObject GAMEWIN;
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

	private void OnTriggerEnter(Collider other)
	{
		if(other.transform.name == "Beer")
		{
			Debug.Log("Game over");
			Invoke("ShowGameOver", 3f);
		}
        if (other.transform.name == "Water")
        {
            Debug.Log("Fire put off");
			gameObject.SetActive(false);
			GAMEWIN.SetActive(true);
        }
    }

	void ShowGameOver()
	{
		GAMEOVER.SetActive(true);
	}



}