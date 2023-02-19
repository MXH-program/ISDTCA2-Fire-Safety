using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.InputSystem;
using TMPro;
using UnityEngine.XR.Interaction.Toolkit.Samples.StarterAssets;
using UnityEngine.UI;
using UnityEngine.InputSystem.Processors;

public class fireman : MonoBehaviour
{
    public float playerHealth;
    public BoxCollider myCollider;
    //public bool isCrouch;
    [SerializeField]
    [Tooltip("The Locomotion Provider object to listen to.")]
    LocomotionProvider m_LocomotionProvider;
    public InputActionReference inptRef;
    public Transform cameraOffset;
    public TextMeshProUGUI healthText;
    public DynamicMoveProvider moveComponent;
    public Image backgroundColorImage; 
    public bool isDead = false;
    public Canvas gameOverCanvas;

    // Start is called before the first frame update
    void Start()
    {
        // binding callback for Crouch Button press
        inptRef.action.performed += ToggleCrouch;
        isDead = false;
    }

    private void OnDestroy()
    {
        // unbinding callback for Crouch Button press
        inptRef.action.performed -= ToggleCrouch;
    }

    // Update is called once per frame
    void Update()
    {
        if (healthText && backgroundColorImage && !isDead)
        {
            Color c = backgroundColorImage.color;
            c.a = (playerHealth <= 0) ? 1 : 1-(playerHealth / 100);
            backgroundColorImage.color = c;
            if (playerHealth <= 0)
            {
                healthText.text = $"You are dead!";
                isDead = true;
            }
            else
            {
                
                healthText.text = $"Health: {playerHealth:f0}";
            }

        }

        if (isDead)
        {
            gameOverCanvas.enabled = true;
        }
    }


    public void ToggleCrouch(InputAction.CallbackContext ctx) {
        //Debug.Log("X button Bool:"+ctx.ReadValueAsButton());
        bool isCrouch = ctx.ReadValueAsButton();
        Vector3 temp = cameraOffset.localPosition;
        temp.y = (isCrouch) ? -1.0f : 0f;
        cameraOffset.localPosition = temp;
        moveComponent.moveSpeed = (isCrouch) ? 2.0f : 5f;

    }

    private void OnTriggerStay(Collider other)
    {
        if(other.tag == "Fumes")
        {
            playerHealth -= Time.fixedDeltaTime * 10;
            Debug.Log($"Take Fumes damange HP Left: {playerHealth}");
            
        }
    }
}

