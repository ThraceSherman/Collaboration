using UnityEngine;
using UnityEngine.InputSystem;

namespace ithappy.Animals_FREE
{
    [RequireComponent(typeof(CreatureMover))]
    public class MovePlayerInput : MonoBehaviour
    {
        [Header("Character")]
        [SerializeField]
        private InputAction moveAction; // Movement input action
        [SerializeField]
        private InputAction jumpAction; // Jump input action
        [SerializeField]
        private InputAction runAction; // Run input action

        [Header("Camera")]
        [SerializeField]
        private PlayerCamera m_Camera;
        [SerializeField]
        private InputAction lookAction; // Look input action
        [SerializeField]
        private InputAction scrollAction; // Scroll input action

        private CreatureMover m_Mover;

        private Vector2 m_Axis;
        private bool m_IsRun;
        private bool m_IsJump;

        private Vector3 m_Target;
        private Vector2 m_MouseDelta;
        private float m_Scroll;

        private void Awake()
        {
            m_Mover = GetComponent<CreatureMover>();

            // Enable input actions
            moveAction.Enable();
            jumpAction.Enable();
            runAction.Enable();
            lookAction.Enable();
            scrollAction.Enable();
        }

        private void Update()
        {
            GatherInput();
            SetInput();
        }

        public void GatherInput()
        {
            // Get movement input
            m_Axis = moveAction.ReadValue<Vector2>();
            m_IsRun = runAction.ReadValue<float>() > 0.5f; // Assuming run is a button press
            m_IsJump = jumpAction.triggered;

            // Get camera input
            m_Target = (m_Camera == null) ? Vector3.zero : m_Camera.Target;
            m_MouseDelta = lookAction.ReadValue<Vector2>();
            m_Scroll = scrollAction.ReadValue<float>();
        }

        public void BindMover(CreatureMover mover)
        {
            m_Mover = mover;
        }

        public void SetInput()
        {
            if (m_Mover != null)
            {
                m_Mover.SetInput(in m_Axis, in m_Target, in m_IsRun, m_IsJump);
            }

            if (m_Camera != null)
            {
                m_Camera.SetInput(in m_MouseDelta, m_Scroll);
            }
        }
    }
    // {
    //     [Header("Character")]
    //     [SerializeField]
    //     private string m_HorizontalAxis = "Horizontal";
    //     [SerializeField]
    //     private string m_VerticalAxis = "Vertical";
    //     [SerializeField]
    //     private string m_JumpButton = "Jump";
    //     [SerializeField]
    //     private KeyCode m_RunKey = KeyCode.LeftShift;

    //     [Header("Camera")]
    //     [SerializeField]
    //     private PlayerCamera m_Camera;
    //     [SerializeField]
    //     private string m_MouseX = "Mouse X";
    //     [SerializeField]
    //     private string m_MouseY = "Mouse Y";
    //     [SerializeField]
    //     private string m_MouseScroll = "Mouse ScrollWheel";

    //     private CreatureMover m_Mover;

    //     private Vector2 m_Axis;
    //     private bool m_IsRun;
    //     private bool m_IsJump;

    //     private Vector3 m_Target;
    //     private Vector2 m_MouseDelta;
    //     private float m_Scroll;

    //     private void Awake()
    //     {
    //         m_Mover = GetComponent<CreatureMover>();
    //     }

    //     private void Update()
    //     {
    //         GatherInput();
    //         SetInput();
    //     }

    //     public void GatherInput()
    //     {
    //         m_Axis = new Vector2(Input.GetAxis(m_HorizontalAxis), Input.GetAxis(m_VerticalAxis));
    //         m_IsRun = Input.GetKey(m_RunKey);
    //         m_IsJump = Input.GetButton(m_JumpButton);

    //         m_Target = (m_Camera == null) ? Vector3.zero : m_Camera.Target;
    //         m_MouseDelta = new Vector2(Input.GetAxis(m_MouseX), Input.GetAxis(m_MouseY));
    //         m_Scroll = Input.GetAxis(m_MouseScroll);
    //     }

    //     public void BindMover(CreatureMover mover)
    //     {
    //         m_Mover = mover;
    //     }

    //     public void SetInput()
    //     {
    //         if (m_Mover != null)
    //         {
    //             m_Mover.SetInput(in m_Axis, in m_Target, in m_IsRun, m_IsJump);
    //         }

    //         if (m_Camera != null)
    //         {
    //             m_Camera.SetInput(in m_MouseDelta, m_Scroll);
    //         }
    //     }
    // }
}