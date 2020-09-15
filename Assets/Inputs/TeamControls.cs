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
                    ""name"": ""Arrow Keys"",
                    ""id"": ""6bfdc053-252e-4f0f-bfee-02fb0b5975cc"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Team2Keyboard"",
                    ""action"": ""Movement"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""edffc77d-888f-44db-835c-578ca8c48449"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Team2Keyboard"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""27a1dad3-1cd5-4d86-b4d9-89ffa6e3ed4d"",
                    ""path"": ""<Keyboard>/downArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Team2Keyboard"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""ff6c28e8-1a6a-45fb-8118-f5fc9eb7ed1f"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Team2Keyboard"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""64ac5a91-3bb1-4d37-b307-b4ee26f202b6"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Team2Keyboard"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""6fda9504-9e88-45d6-8683-3c992c18de64"",
                    ""path"": ""<Keyboard>/rightMeta"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Team2Keyboard"",
                    ""action"": ""Kick"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""86bfc018-705d-4324-8558-dca8a6dab932"",
                    ""path"": ""<Keyboard>/c"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Team1Keyboard"",
                    ""action"": ""Kick"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""WASD"",
                    ""id"": ""113e844d-152f-487f-ace7-1efce2e476c9"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Team1Keyboard"",
                    ""action"": ""Movement"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""fe2d826e-d142-4637-9d86-33b4059469c1"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Team1Keyboard"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""4d03bd59-8597-41e4-8d85-a312cbbdc0f7"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Team1Keyboard"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""68b39db4-9d91-4850-9307-f3a6e05aa9a7"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Team1Keyboard"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""e61a248e-05df-4b9c-94e9-8ee515349925"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Team1Keyboard"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""Team1Keyboard"",
            ""bindingGroup"": ""Team1Keyboard"",
            ""devices"": [
                {
                    ""devicePath"": ""<Keyboard>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        },
        {
            ""name"": ""Team2Keyboard"",
            ""bindingGroup"": ""Team2Keyboard"",
            ""devices"": [
                {
                    ""devicePath"": ""<Keyboard>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        }
    ]
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
    private int m_Team1KeyboardSchemeIndex = -1;
    public InputControlScheme Team1KeyboardScheme
    {
        get
        {
            if (m_Team1KeyboardSchemeIndex == -1) m_Team1KeyboardSchemeIndex = asset.FindControlSchemeIndex("Team1Keyboard");
            return asset.controlSchemes[m_Team1KeyboardSchemeIndex];
        }
    }
    private int m_Team2KeyboardSchemeIndex = -1;
    public InputControlScheme Team2KeyboardScheme
    {
        get
        {
            if (m_Team2KeyboardSchemeIndex == -1) m_Team2KeyboardSchemeIndex = asset.FindControlSchemeIndex("Team2Keyboard");
            return asset.controlSchemes[m_Team2KeyboardSchemeIndex];
        }
    }
    public interface ITeamActions
    {
        void OnMovement(InputAction.CallbackContext context);
        void OnKick(InputAction.CallbackContext context);
    }
}
