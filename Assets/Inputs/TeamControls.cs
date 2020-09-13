// GENERATED AUTOMATICALLY FROM 'Assets/Inputs/TeamControls.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @TeamControls : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @TeamControls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""TeamControls"",
    ""maps"": [
        {
            ""name"": ""Team"",
            ""id"": ""f9f2d629-7a70-481d-add4-73ab1b8f5f23"",
            ""actions"": [
                {
                    ""name"": ""Movement"",
                    ""type"": ""Value"",
                    ""id"": ""90dfba14-6e2e-4463-ae11-187e23601c5b"",
                    ""expectedControlType"": ""Stick"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Kick"",
                    ""type"": ""Button"",
                    ""id"": ""87e206e3-9685-41f2-9c00-5296fb5f43ca"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press""
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""WASD"",
                    ""id"": ""8e356df3-fcc3-4266-ae5d-c173d656a8ae"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""bae22966-ef08-45b9-bf7a-8f0a2c34a968"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""4675007a-6da2-45a4-8bb4-616f340d3e94"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""98220a34-4ebe-4265-8631-9ca4731f4aec"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""f4742df1-1207-49c5-bdb5-a3a70184a1b0"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Arrow Keys"",
                    ""id"": ""e4e85047-8267-4d78-a3fd-60984133c57d"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""0fda616d-5fb0-4572-ac44-5ba7a28e22e0"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""e490dd23-6b33-4d2a-a076-9cb8db9e1e06"",
                    ""path"": ""<Keyboard>/downArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""44128ab4-4668-44d5-b856-c9d825feb573"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""8fd1ca35-5e65-4f58-aaa4-dc186eb08330"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""3e4ea8a8-c2cc-43c5-a7f3-6c64736717a4"",
                    ""path"": ""<Gamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ae8dff8f-3dfe-4ea5-aca2-23e6b87b4df0"",
                    ""path"": ""<Keyboard>/c"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Kick"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Team
        m_Team = asset.FindActionMap("Team", throwIfNotFound: true);
        m_Team_Movement = m_Team.FindAction("Movement", throwIfNotFound: true);
        m_Team_Kick = m_Team.FindAction("Kick", throwIfNotFound: true);
    }

    public void Dispose()
    {
        UnityEngine.Object.Destroy(asset);
    }

    public InputBinding? bindingMask
    {
        get => asset.bindingMask;
        set => asset.bindingMask = value;
    }

    public ReadOnlyArray<InputDevice>? devices
    {
        get => asset.devices;
        set => asset.devices = value;
    }

    public ReadOnlyArray<InputControlScheme> controlSchemes => asset.controlSchemes;

    public bool Contains(InputAction action)
    {
        return asset.Contains(action);
    }

    public IEnumerator<InputAction> GetEnumerator()
    {
        return asset.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public void Enable()
    {
        asset.Enable();
    }

    public void Disable()
    {
        asset.Disable();
    }

    // Team
    private readonly InputActionMap m_Team;
    private ITeamActions m_TeamActionsCallbackInterface;
    private readonly InputAction m_Team_Movement;
    private readonly InputAction m_Team_Kick;
    public struct TeamActions
    {
        private @TeamControls m_Wrapper;
        public TeamActions(@TeamControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Movement => m_Wrapper.m_Team_Movement;
        public InputAction @Kick => m_Wrapper.m_Team_Kick;
        public InputActionMap Get() { return m_Wrapper.m_Team; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(TeamActions set) { return set.Get(); }
        public void SetCallbacks(ITeamActions instance)
        {
            if (m_Wrapper.m_TeamActionsCallbackInterface != null)
            {
                @Movement.started -= m_Wrapper.m_TeamActionsCallbackInterface.OnMovement;
                @Movement.performed -= m_Wrapper.m_TeamActionsCallbackInterface.OnMovement;
                @Movement.canceled -= m_Wrapper.m_TeamActionsCallbackInterface.OnMovement;
                @Kick.started -= m_Wrapper.m_TeamActionsCallbackInterface.OnKick;
                @Kick.performed -= m_Wrapper.m_TeamActionsCallbackInterface.OnKick;
                @Kick.canceled -= m_Wrapper.m_TeamActionsCallbackInterface.OnKick;
            }
            m_Wrapper.m_TeamActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Movement.started += instance.OnMovement;
                @Movement.performed += instance.OnMovement;
                @Movement.canceled += instance.OnMovement;
                @Kick.started += instance.OnKick;
                @Kick.performed += instance.OnKick;
                @Kick.canceled += instance.OnKick;
            }
        }
    }
    public TeamActions @Team => new TeamActions(this);
    public interface ITeamActions
    {
        void OnMovement(InputAction.CallbackContext context);
        void OnKick(InputAction.CallbackContext context);
    }
}
