using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityStandardAssets.CrossPlatformInput;

using ANET.Networking;

[RequireComponent(typeof(CharacterController))]
public class SimpleMoveController : INetworkBehaviour {

    #region Private Fields
    private bool matchStarted = false;

    [SerializeField]
    private Camera m_camera = null;

    [SerializeField]
    private float simpleSpeed = 5.0f;

    [SerializeField]
    [Range(0.01f,0.1f)]
    private float interpolationFactor = 5.0f;

    private CharacterController controller = null;

    [SerializeField]
    [Tooltip("How often this entity sends its data through network to the server. In seconds")]
    private float networkSendRate = 1.0f;

    private float elapsedTime = 0.0f;

    private Vector3 moveAmount;
    #endregion

    #region Public Fields and Properties
    public CharacterController Controller
    {
        get
        {
            return controller;
        }
    }
    #endregion

    public override void Start()
    {
        base.Start();
        if (m_camera)
        {
            /**
             * Disable head-mounted display if no gyro is available
             */
            if (!Input.gyro.enabled)
            {
                m_camera.stereoTargetEye = StereoTargetEyeMask.None; 
            }
        }
    }

    private void Awake()
    {
        controller = GetComponent<CharacterController>();
    }

    private void LateUpdate()
    {
        if (Networking.Instance)
        {
            if (controller && Networking.Instance.Host)  // Se existir networking e o cara for o host (por que o host eh o player VR, ele que anda)
            {
                elapsedTime += Time.deltaTime;
                if (elapsedTime >= networkSendRate)
                {
                    if (matchStarted)
                    {
                        Networking.Instance.MoveAlien(gameObject.transform.position);
                    }
                    elapsedTime = 0.0f;
                }
            }
        }

    }

    // Update is called once per frame
    void Update ()
    {
        if (Networking.Instance)
        {
            if (controller && Networking.Instance.Host) // Se existir networking e o cara for o host (por que o host eh o player VR, ele que anda)
            {
                /*Vector3 newPosition = new Vector3(
                    Input.GetAxis("Horizontal"),
                    0.0f,
                    Input.GetAxis("Vertical")
                ) * simpleSpeed;

                controller.SimpleMove(newPosition);*/

                transform.Rotate(0, CrossPlatformInputManager.GetAxis("Horizontal") * 1f, 0);
                Vector3 forward = transform.TransformDirection(Vector3.forward);
                float curSpeed = simpleSpeed * CrossPlatformInputManager.GetAxis("Vertical");
                controller.SimpleMove(forward * curSpeed);
            }
            else // Se ele nao for o host a posicao dele eh interpolada
            {
                transform.position = Vector3.LerpUnclamped(transform.position, moveAmount, interpolationFactor);
            }
        }
        else // Fallback para testar offline
        {
            transform.Rotate(0, CrossPlatformInputManager.GetAxis("Horizontal") * 1f, 0);
            Vector3 forward = transform.TransformDirection(Vector3.forward);
            float curSpeed = simpleSpeed * CrossPlatformInputManager.GetAxis("Vertical");
            controller.SimpleMove(forward * curSpeed);
        }
        
	}

    public override void OnAlienMove(JSONObject payload) // Recebido a cada 100 ms
    {
        if (!Networking.Instance.Host) // Soh se nao for o host
        {
            Vector3 newPosition = new Vector3(
                payload.GetField("x").n,
                payload.GetField("y").n,
                payload.GetField("z").n
            );

            moveAmount = newPosition;
        }
    }

    public override void OnMatchStarted()
    {
        matchStarted = true;
    }

    public override void OnGameOver(JSONObject payload)
    {
        matchStarted = false;
    }
}
