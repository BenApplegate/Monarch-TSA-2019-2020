// GENERATED AUTOMATICALLY FROM 'Assets/InputActions.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class InputActions : IInputActionCollection, IDisposable
{
    private InputActionAsset asset;
    public InputActions()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""InputActions"",
    ""maps"": [
        {
            ""name"": ""Archery"",
            ""id"": ""6998fda7-6cc2-4a90-a087-16538326d249"",
            ""actions"": [
                {
                    ""name"": ""Aim"",
                    ""type"": ""Value"",
                    ""id"": ""15b2ca23-bee5-4111-82ba-95754f99beb2"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""FireArrow"",
                    ""type"": ""Value"",
                    ""id"": ""03546c46-8429-4f7c-b0c3-829e65878f84"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""827076e7-daec-423a-93fe-ab643e5d29d8"",
                    ""path"": ""<Gamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Aim"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""68e10f65-0b1b-40cc-b9e6-49ed85ce3642"",
                    ""path"": ""<Mouse>/delta"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Aim"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""9feb4f24-00f9-4914-b015-a2ec3df89fcc"",
                    ""path"": ""<Gamepad>/rightTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""FireArrow"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""5ccd23bb-e660-4eaa-81c6-29f068d9e065"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""FireArrow"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Archery
        m_Archery = asset.FindActionMap("Archery", throwIfNotFound: true);
        m_Archery_Aim = m_Archery.FindAction("Aim", throwIfNotFound: true);
        m_Archery_FireArrow = m_Archery.FindAction("FireArrow", throwIfNotFound: true);
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

    // Archery
    private readonly InputActionMap m_Archery;
    private IArcheryActions m_ArcheryActionsCallbackInterface;
    private readonly InputAction m_Archery_Aim;
    private readonly InputAction m_Archery_FireArrow;
    public struct ArcheryActions
    {
        private InputActions m_Wrapper;
        public ArcheryActions(InputActions wrapper) { m_Wrapper = wrapper; }
        public InputAction @Aim => m_Wrapper.m_Archery_Aim;
        public InputAction @FireArrow => m_Wrapper.m_Archery_FireArrow;
        public InputActionMap Get() { return m_Wrapper.m_Archery; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(ArcheryActions set) { return set.Get(); }
        public void SetCallbacks(IArcheryActions instance)
        {
            if (m_Wrapper.m_ArcheryActionsCallbackInterface != null)
            {
                Aim.started -= m_Wrapper.m_ArcheryActionsCallbackInterface.OnAim;
                Aim.performed -= m_Wrapper.m_ArcheryActionsCallbackInterface.OnAim;
                Aim.canceled -= m_Wrapper.m_ArcheryActionsCallbackInterface.OnAim;
                FireArrow.started -= m_Wrapper.m_ArcheryActionsCallbackInterface.OnFireArrow;
                FireArrow.performed -= m_Wrapper.m_ArcheryActionsCallbackInterface.OnFireArrow;
                FireArrow.canceled -= m_Wrapper.m_ArcheryActionsCallbackInterface.OnFireArrow;
            }
            m_Wrapper.m_ArcheryActionsCallbackInterface = instance;
            if (instance != null)
            {
                Aim.started += instance.OnAim;
                Aim.performed += instance.OnAim;
                Aim.canceled += instance.OnAim;
                FireArrow.started += instance.OnFireArrow;
                FireArrow.performed += instance.OnFireArrow;
                FireArrow.canceled += instance.OnFireArrow;
            }
        }
    }
    public ArcheryActions @Archery => new ArcheryActions(this);
    public interface IArcheryActions
    {
        void OnAim(InputAction.CallbackContext context);
        void OnFireArrow(InputAction.CallbackContext context);
    }
}
