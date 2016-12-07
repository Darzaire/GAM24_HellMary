using UnityEngine;
using System.Collections;
using System;

public class FPSController : MonoBehaviour {
	public float lookSensitivity = 1.0f;
	public float lookSmooth = 2.0f;
	public Transform toonHead;
	public float walkSpeed = 6.0f;
	public float runSpeed = 12.0f;
	public float jumpForce = 1000.0f;
	public KeyCode runKey = KeyCode.LeftShift;
	public KeyCode jumpKey = KeyCode.Space;

	private float speed = 6.0f;
	private KeyCode esc = KeyCode.Escape;
	private CursorLockMode originalLockMode;
	private Vector2 mouseLook;
	private Vector2 smoothV;
	private float lookMod;
	private float groundedMargin;
	private Transform toonBody;
	private Rigidbody rb;
    public bool isActive = false;
    public Animator anim;
    public float dirtAmt = 0;
    public float stoneAmt = 0;
    //public float 
	#region Properties
	public float Speed { get { return speed; } set { speed = value; } }
	#endregion

	#region MonoBehaviour
	void Awake() {
		Speed = walkSpeed;
		toonBody = this.transform;
		rb = this.GetComponent<Rigidbody>();
	}

	void Start() {
		Cursor.lockState = CursorLockMode.Locked;
		Cursor.visible = false;
		lookMod = lookSensitivity * lookSmooth;
		groundedMargin = this.transform.localScale.y;
        //anim = GetComponent<Animator>();
    }

	void Update() {
		GetInput();
        DiggingHand();
	}
	#endregion

	#region Class Methods
	void GetInput() {
		MoveToon(Input.GetAxis("Vertical"), Input.GetAxis("Horizontal"));
		Vector2 mouseDir = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y"));
		LookToon(mouseDir);
		if(Input.GetKeyDown(esc)) {
			if(Cursor.visible) {
				Cursor.lockState = CursorLockMode.Locked;
				Cursor.visible = false;
			} else {
				Cursor.lockState = CursorLockMode.None;
				Cursor.visible = true;
			}
		}
		if(Input.GetKey(runKey)) {
			Speed = runSpeed;
		}
		if(Input.GetKeyUp(runKey)) {
			Speed = walkSpeed;
		}
		if(Input.GetKey(jumpKey)) {
			Jump();
		}
	}

	private void LookToon(Vector2 mMouseDir) {
		mMouseDir = Vector2.Scale(mMouseDir, new Vector2(lookMod, lookMod));
		smoothV.x = Mathf.Lerp(smoothV.x, mMouseDir.x, 1.0f / lookSmooth);
		smoothV.y = Mathf.Lerp(smoothV.y, mMouseDir.y, 1.0f / lookSmooth);
		mouseLook += smoothV;
		mouseLook.y = Mathf.Clamp(mouseLook.y, -90, 90);
		toonBody.rotation = Quaternion.AngleAxis(mouseLook.x, toonBody.up);
		toonHead.localRotation = Quaternion.AngleAxis(-mouseLook.y, Vector3.right);
	}

	private void MoveToon(float mVert, float mHor) {
		if(mVert != 0.0f || mHor != 0.0f) {
			Vector3 movementDir = this.transform.forward * mVert;
			movementDir += this.transform.right * mHor;
			movementDir.Normalize();
			this.rb.MovePosition(this.transform.position + movementDir * (Speed * Time.deltaTime));
		}
	}

	private void Jump() {
		Ray ray = new Ray(this.transform.position, -this.transform.up);
		RaycastHit hit;
		if(Physics.Raycast(ray, out hit, groundedMargin)) {
			this.rb.isKinematic = true;
			this.rb.velocity = Vector3.zero;
			this.rb.isKinematic = false;
			this.rb.AddForce(Vector3.up * (jumpForce * (this.rb.mass * 100)));
		}
	}

    public void DiggingHand()
    {
        if (Input.GetMouseButton(0))
        {
            isActive = true;
            anim.SetTrigger("Digging");
        }
        else 
        {
            isActive = false;
            anim.SetTrigger("Idle");
        }

    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Dirt") 
        {
            dirtAmt += 1;
        }
        if(other.gameObject.tag == "Stone")
        {
            stoneAmt += 1;
        }
    }
	#endregion
}