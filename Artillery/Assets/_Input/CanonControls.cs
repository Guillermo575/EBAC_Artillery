//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.7.0
//     from Assets/_Input/CanonControls.inputactions
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public partial class @CanonControls: IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @CanonControls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""CanonControls"",
    ""maps"": [
        {
            ""name"": ""Canon"",
            ""id"": ""81b3a437-f7cd-4ff3-83dd-0a77c2ce18bc"",
            ""actions"": [
                {
                    ""name"": ""Apuntar"",
                    ""type"": ""Button"",
                    ""id"": ""005d05a9-4d5a-492b-8a44-29226215d01c"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Disparar"",
                    ""type"": ""Button"",
                    ""id"": ""7f06a90e-6ea8-45b9-a349-1d92714b8be4"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Modificar_Fuerza"",
                    ""type"": ""Button"",
                    ""id"": ""e04639ea-5da2-4caf-a7e2-841aaf046780"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""Teclado_WASD"",
                    ""id"": ""0fbedc78-c6e9-4702-9065-4c7fae988e4e"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Apuntar"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""f4fd46df-63ba-4fa6-a326-8ca02f5ec61e"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Apuntar"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""3ba5f73a-11db-488e-a161-00785f2fa731"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Apuntar"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Teclado_Flechas"",
                    ""id"": ""4f04d6d7-9135-486e-a8fc-36fb452163b4"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Apuntar"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""3142d019-7cc3-4886-a5c4-e0c1aba05cc8"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Apuntar"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""796c29e4-0470-45b9-a3fb-87fa08d72aeb"",
                    ""path"": ""<Keyboard>/downArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Apuntar"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""GamePad"",
                    ""id"": ""b17b871a-fe6d-4837-b9d8-b80f16bdbd94"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Apuntar"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""98a96833-f6db-4821-abae-6d5ff39204a6"",
                    ""path"": ""<Gamepad>/rightStick/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Apuntar"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""79dfde6b-29a3-4c2d-ae4e-3589ade6bbbc"",
                    ""path"": ""<Gamepad>/rightStick/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Apuntar"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""5658a13b-5854-405d-a074-6e5502b2be97"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Disparar"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""71ab37d5-ef82-4d7c-bfc5-743c44b94197"",
                    ""path"": ""<Gamepad>/buttonEast"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Disparar"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""Teclado_WASD"",
                    ""id"": ""67c462c2-9a73-4666-8b4e-23cf5b0a9611"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Modificar_Fuerza"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""c0497bab-9894-4424-83da-09865ad0ef40"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Modificar_Fuerza"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""bcb6fc9a-0726-4245-a106-dd9ed966dbe2"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Modificar_Fuerza"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Teclado_Flechas"",
                    ""id"": ""8a30a5db-9aa2-40be-bbbb-997bb022c7f6"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Modificar_Fuerza"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""e32e6b11-b99b-42df-912e-453de639458c"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Modificar_Fuerza"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""bc4e7c5a-e428-461a-843f-aa949820ab62"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Modificar_Fuerza"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""GamePad"",
                    ""id"": ""2b5575d9-6124-440c-95b5-600f36d28be7"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Modificar_Fuerza"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""120fd122-523c-4f07-929c-047691590be8"",
                    ""path"": ""<Gamepad>/leftStick/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Modificar_Fuerza"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""55401ab5-2243-43f7-a132-7cae862287b5"",
                    ""path"": ""<Gamepad>/leftStick/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Modificar_Fuerza"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                }
            ]
        },
        {
            ""name"": ""HUD_Time"",
            ""id"": ""86f78f7c-3788-4340-adb1-e50b265c49d8"",
            ""actions"": [
                {
                    ""name"": ""Time_Slow"",
                    ""type"": ""Button"",
                    ""id"": ""67eebdda-504d-400b-af91-21d2771063cb"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Time_Fast"",
                    ""type"": ""Button"",
                    ""id"": ""7c397205-9f23-4313-8ec5-b9ce80dd37ff"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""3a03c875-2057-4404-9822-c3351a7e685f"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Time_Slow"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b9a88bcb-f57e-4353-b2c2-9423873e596b"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Time_Slow"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""958ac54a-7fbb-4177-8b0c-5d75443c2b43"",
                    ""path"": ""<Gamepad>/buttonWest"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Time_Slow"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""c5222c14-a6aa-4a28-9806-8d5773d282b5"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Time_Fast"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d5157941-b7b2-4a89-b648-169bd19302e2"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Time_Fast"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""8efb56ad-80b8-47d8-91c3-c70e3115c159"",
                    ""path"": ""<Gamepad>/buttonEast"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Time_Fast"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""Generic"",
            ""bindingGroup"": ""Generic"",
            ""devices"": [
                {
                    ""devicePath"": ""<Gamepad>"",
                    ""isOptional"": false,
                    ""isOR"": false
                },
                {
                    ""devicePath"": ""<Keyboard>"",
                    ""isOptional"": false,
                    ""isOR"": false
                },
                {
                    ""devicePath"": ""<Touchscreen>"",
                    ""isOptional"": true,
                    ""isOR"": false
                }
            ]
        }
    ]
}");
        // Canon
        m_Canon = asset.FindActionMap("Canon", throwIfNotFound: true);
        m_Canon_Apuntar = m_Canon.FindAction("Apuntar", throwIfNotFound: true);
        m_Canon_Disparar = m_Canon.FindAction("Disparar", throwIfNotFound: true);
        m_Canon_Modificar_Fuerza = m_Canon.FindAction("Modificar_Fuerza", throwIfNotFound: true);
        // HUD_Time
        m_HUD_Time = asset.FindActionMap("HUD_Time", throwIfNotFound: true);
        m_HUD_Time_Time_Slow = m_HUD_Time.FindAction("Time_Slow", throwIfNotFound: true);
        m_HUD_Time_Time_Fast = m_HUD_Time.FindAction("Time_Fast", throwIfNotFound: true);
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

    public IEnumerable<InputBinding> bindings => asset.bindings;

    public InputAction FindAction(string actionNameOrId, bool throwIfNotFound = false)
    {
        return asset.FindAction(actionNameOrId, throwIfNotFound);
    }

    public int FindBinding(InputBinding bindingMask, out InputAction action)
    {
        return asset.FindBinding(bindingMask, out action);
    }

    // Canon
    private readonly InputActionMap m_Canon;
    private List<ICanonActions> m_CanonActionsCallbackInterfaces = new List<ICanonActions>();
    private readonly InputAction m_Canon_Apuntar;
    private readonly InputAction m_Canon_Disparar;
    private readonly InputAction m_Canon_Modificar_Fuerza;
    public struct CanonActions
    {
        private @CanonControls m_Wrapper;
        public CanonActions(@CanonControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Apuntar => m_Wrapper.m_Canon_Apuntar;
        public InputAction @Disparar => m_Wrapper.m_Canon_Disparar;
        public InputAction @Modificar_Fuerza => m_Wrapper.m_Canon_Modificar_Fuerza;
        public InputActionMap Get() { return m_Wrapper.m_Canon; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(CanonActions set) { return set.Get(); }
        public void AddCallbacks(ICanonActions instance)
        {
            if (instance == null || m_Wrapper.m_CanonActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_CanonActionsCallbackInterfaces.Add(instance);
            @Apuntar.started += instance.OnApuntar;
            @Apuntar.performed += instance.OnApuntar;
            @Apuntar.canceled += instance.OnApuntar;
            @Disparar.started += instance.OnDisparar;
            @Disparar.performed += instance.OnDisparar;
            @Disparar.canceled += instance.OnDisparar;
            @Modificar_Fuerza.started += instance.OnModificar_Fuerza;
            @Modificar_Fuerza.performed += instance.OnModificar_Fuerza;
            @Modificar_Fuerza.canceled += instance.OnModificar_Fuerza;
        }

        private void UnregisterCallbacks(ICanonActions instance)
        {
            @Apuntar.started -= instance.OnApuntar;
            @Apuntar.performed -= instance.OnApuntar;
            @Apuntar.canceled -= instance.OnApuntar;
            @Disparar.started -= instance.OnDisparar;
            @Disparar.performed -= instance.OnDisparar;
            @Disparar.canceled -= instance.OnDisparar;
            @Modificar_Fuerza.started -= instance.OnModificar_Fuerza;
            @Modificar_Fuerza.performed -= instance.OnModificar_Fuerza;
            @Modificar_Fuerza.canceled -= instance.OnModificar_Fuerza;
        }

        public void RemoveCallbacks(ICanonActions instance)
        {
            if (m_Wrapper.m_CanonActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(ICanonActions instance)
        {
            foreach (var item in m_Wrapper.m_CanonActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_CanonActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public CanonActions @Canon => new CanonActions(this);

    // HUD_Time
    private readonly InputActionMap m_HUD_Time;
    private List<IHUD_TimeActions> m_HUD_TimeActionsCallbackInterfaces = new List<IHUD_TimeActions>();
    private readonly InputAction m_HUD_Time_Time_Slow;
    private readonly InputAction m_HUD_Time_Time_Fast;
    public struct HUD_TimeActions
    {
        private @CanonControls m_Wrapper;
        public HUD_TimeActions(@CanonControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Time_Slow => m_Wrapper.m_HUD_Time_Time_Slow;
        public InputAction @Time_Fast => m_Wrapper.m_HUD_Time_Time_Fast;
        public InputActionMap Get() { return m_Wrapper.m_HUD_Time; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(HUD_TimeActions set) { return set.Get(); }
        public void AddCallbacks(IHUD_TimeActions instance)
        {
            if (instance == null || m_Wrapper.m_HUD_TimeActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_HUD_TimeActionsCallbackInterfaces.Add(instance);
            @Time_Slow.started += instance.OnTime_Slow;
            @Time_Slow.performed += instance.OnTime_Slow;
            @Time_Slow.canceled += instance.OnTime_Slow;
            @Time_Fast.started += instance.OnTime_Fast;
            @Time_Fast.performed += instance.OnTime_Fast;
            @Time_Fast.canceled += instance.OnTime_Fast;
        }

        private void UnregisterCallbacks(IHUD_TimeActions instance)
        {
            @Time_Slow.started -= instance.OnTime_Slow;
            @Time_Slow.performed -= instance.OnTime_Slow;
            @Time_Slow.canceled -= instance.OnTime_Slow;
            @Time_Fast.started -= instance.OnTime_Fast;
            @Time_Fast.performed -= instance.OnTime_Fast;
            @Time_Fast.canceled -= instance.OnTime_Fast;
        }

        public void RemoveCallbacks(IHUD_TimeActions instance)
        {
            if (m_Wrapper.m_HUD_TimeActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(IHUD_TimeActions instance)
        {
            foreach (var item in m_Wrapper.m_HUD_TimeActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_HUD_TimeActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public HUD_TimeActions @HUD_Time => new HUD_TimeActions(this);
    private int m_GenericSchemeIndex = -1;
    public InputControlScheme GenericScheme
    {
        get
        {
            if (m_GenericSchemeIndex == -1) m_GenericSchemeIndex = asset.FindControlSchemeIndex("Generic");
            return asset.controlSchemes[m_GenericSchemeIndex];
        }
    }
    public interface ICanonActions
    {
        void OnApuntar(InputAction.CallbackContext context);
        void OnDisparar(InputAction.CallbackContext context);
        void OnModificar_Fuerza(InputAction.CallbackContext context);
    }
    public interface IHUD_TimeActions
    {
        void OnTime_Slow(InputAction.CallbackContext context);
        void OnTime_Fast(InputAction.CallbackContext context);
    }
}
