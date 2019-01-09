using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    [System.Serializable]
    public class MouseInput
    {
        public Vector2 Damping;
        public Vector2 Sensitivity;
        public bool MouseLocked;
    }

    [SerializeField] float runSpeed;
    [SerializeField] float walkSpeed;
    [SerializeField] float sprintSpeed;
    [SerializeField] float crouchSpeed;

    [SerializeField] MouseInput MouseControl;

    private MoveController m_MoveController;
    public MoveController MoveController
    {
        get
        {
            if (m_MoveController == null)
                m_MoveController = GetComponent<MoveController>();
            return m_MoveController;
        }
    }

    private Crosshair m_Crosshair;
    private Crosshair Crosshair
    {
        get
        {
            if (m_Crosshair == null)
                m_Crosshair = GetComponentInChildren<Crosshair>();
            return m_Crosshair;
        }
    }

    Vector2 mouseInput;
    InputController playerInput;

    void Awake()
    {
        playerInput = GameManager.Instance.InputController;
        GameManager.Instance.LocalPlayer = this;
        if(MouseControl.MouseLocked){
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }

    }
    // Use this for initialization
    void Start () {

	}
	
	// Update is called once per frame
	void Update ()
    {
        Move();
        LookArround();
    }

    private void LookArround()
    {
        mouseInput.x = Mathf.Lerp(mouseInput.x, playerInput.MouseInput.x, 1f / MouseControl.Damping.x);
        mouseInput.y = Mathf.Lerp(mouseInput.y, playerInput.MouseInput.y, 1f / MouseControl.Damping.y);

        transform.Rotate(Vector3.up * mouseInput.x * MouseControl.Sensitivity.x);

        Crosshair.LookHeight(mouseInput.y * MouseControl.Sensitivity.y);
    }

    private void Move()
    {
        Vector2 direction = new Vector2(playerInput.Vertical * runSpeed, playerInput.Horizontal * runSpeed);
        MoveController.Move(direction);
    }
}
