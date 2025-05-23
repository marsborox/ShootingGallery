//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.7.0
//     from Assets/Controls/PlayerControls.inputactions
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

public partial class @PlayerControls: IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerControls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerControls"",
    ""maps"": [
        {
            ""name"": ""Shooting"",
            ""id"": ""32570a18-dea7-40c6-adb7-e20ebc7fed64"",
            ""actions"": [
                {
                    ""name"": ""Shoot"",
                    ""type"": ""Value"",
                    ""id"": ""597ccb2d-c458-45dd-a0f6-413e3c9183ab"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Hold(duration=0.02)"",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Reload"",
                    ""type"": ""Button"",
                    ""id"": ""b816c124-c9c1-44d6-b0fb-baa86eeede8b"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""AutoShoot"",
                    ""type"": ""Button"",
                    ""id"": ""68cab590-3573-432c-8e56-e5bf07eb3d27"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""6a47899c-8eb1-4140-956b-2be13fc55974"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Shoot"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""16c87593-1502-4445-b55d-d36b522be49b"",
                    ""path"": ""<Mouse>/rightButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Reload"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""e053c8f5-3e0d-4af1-beac-bcf17eab9e93"",
                    ""path"": ""<Keyboard>/r"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Reload"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""762ce5ec-e7c1-4c54-a7cb-6ea390d52f68"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""AutoShoot"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""WeaponSwitch"",
            ""id"": ""1b327678-08cb-495e-97db-6f8800b8ab33"",
            ""actions"": [
                {
                    ""name"": ""SetPistol"",
                    ""type"": ""Button"",
                    ""id"": ""89f2d6f0-40e0-48d5-8913-19715d811760"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""SetShotgun"",
                    ""type"": ""Button"",
                    ""id"": ""84aa4292-00ac-4dc6-a3f0-23928030f51d"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""SetMachineGun"",
                    ""type"": ""Button"",
                    ""id"": ""dfadbe25-021a-46c2-bb0b-d23a2aa0f037"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""9019ee4d-3d54-4389-824d-e87960fbb4a8"",
                    ""path"": ""<Keyboard>/1"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""SetPistol"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""71121bf2-c7e7-4668-9833-85478bf0cb10"",
                    ""path"": ""<Keyboard>/2"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""SetShotgun"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""4162a6e2-f590-4836-a23d-6f5415473e13"",
                    ""path"": ""<Keyboard>/3"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""SetMachineGun"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""MenuControl"",
            ""id"": ""bf44112c-7406-44dc-886e-4f4e9abc59ab"",
            ""actions"": [
                {
                    ""name"": ""New action"",
                    ""type"": ""Button"",
                    ""id"": ""76f30088-460a-4fc8-8d34-cd2dea4ab210"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""EscapeMenu"",
                    ""type"": ""Button"",
                    ""id"": ""2b031123-c5ae-4d51-9216-cbde4b6b92a1"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""UpgradeMenu"",
                    ""type"": ""Button"",
                    ""id"": ""322fe449-4cbe-4473-835f-83113874a1cd"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""b4a6d6e6-0b8d-4d7c-a3fd-f7c59336f1a2"",
                    ""path"": """",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""New action"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""9defb201-3576-4493-8448-14a7001ffc23"",
                    ""path"": ""<Keyboard>/escape"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""EscapeMenu"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""264f22ad-56ce-4bfb-b3a3-7378dc4bc8ac"",
                    ""path"": ""<Keyboard>/p"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""EscapeMenu"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""c72d1543-4696-40d9-910b-dcf8e9753478"",
                    ""path"": """",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""UpgradeMenu"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Shooting
        m_Shooting = asset.FindActionMap("Shooting", throwIfNotFound: true);
        m_Shooting_Shoot = m_Shooting.FindAction("Shoot", throwIfNotFound: true);
        m_Shooting_Reload = m_Shooting.FindAction("Reload", throwIfNotFound: true);
        m_Shooting_AutoShoot = m_Shooting.FindAction("AutoShoot", throwIfNotFound: true);
        // WeaponSwitch
        m_WeaponSwitch = asset.FindActionMap("WeaponSwitch", throwIfNotFound: true);
        m_WeaponSwitch_SetPistol = m_WeaponSwitch.FindAction("SetPistol", throwIfNotFound: true);
        m_WeaponSwitch_SetShotgun = m_WeaponSwitch.FindAction("SetShotgun", throwIfNotFound: true);
        m_WeaponSwitch_SetMachineGun = m_WeaponSwitch.FindAction("SetMachineGun", throwIfNotFound: true);
        // MenuControl
        m_MenuControl = asset.FindActionMap("MenuControl", throwIfNotFound: true);
        m_MenuControl_Newaction = m_MenuControl.FindAction("New action", throwIfNotFound: true);
        m_MenuControl_EscapeMenu = m_MenuControl.FindAction("EscapeMenu", throwIfNotFound: true);
        m_MenuControl_UpgradeMenu = m_MenuControl.FindAction("UpgradeMenu", throwIfNotFound: true);
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

    // Shooting
    private readonly InputActionMap m_Shooting;
    private List<IShootingActions> m_ShootingActionsCallbackInterfaces = new List<IShootingActions>();
    private readonly InputAction m_Shooting_Shoot;
    private readonly InputAction m_Shooting_Reload;
    private readonly InputAction m_Shooting_AutoShoot;
    public struct ShootingActions
    {
        private @PlayerControls m_Wrapper;
        public ShootingActions(@PlayerControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Shoot => m_Wrapper.m_Shooting_Shoot;
        public InputAction @Reload => m_Wrapper.m_Shooting_Reload;
        public InputAction @AutoShoot => m_Wrapper.m_Shooting_AutoShoot;
        public InputActionMap Get() { return m_Wrapper.m_Shooting; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(ShootingActions set) { return set.Get(); }
        public void AddCallbacks(IShootingActions instance)
        {
            if (instance == null || m_Wrapper.m_ShootingActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_ShootingActionsCallbackInterfaces.Add(instance);
            @Shoot.started += instance.OnShoot;
            @Shoot.performed += instance.OnShoot;
            @Shoot.canceled += instance.OnShoot;
            @Reload.started += instance.OnReload;
            @Reload.performed += instance.OnReload;
            @Reload.canceled += instance.OnReload;
            @AutoShoot.started += instance.OnAutoShoot;
            @AutoShoot.performed += instance.OnAutoShoot;
            @AutoShoot.canceled += instance.OnAutoShoot;
        }

        private void UnregisterCallbacks(IShootingActions instance)
        {
            @Shoot.started -= instance.OnShoot;
            @Shoot.performed -= instance.OnShoot;
            @Shoot.canceled -= instance.OnShoot;
            @Reload.started -= instance.OnReload;
            @Reload.performed -= instance.OnReload;
            @Reload.canceled -= instance.OnReload;
            @AutoShoot.started -= instance.OnAutoShoot;
            @AutoShoot.performed -= instance.OnAutoShoot;
            @AutoShoot.canceled -= instance.OnAutoShoot;
        }

        public void RemoveCallbacks(IShootingActions instance)
        {
            if (m_Wrapper.m_ShootingActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(IShootingActions instance)
        {
            foreach (var item in m_Wrapper.m_ShootingActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_ShootingActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public ShootingActions @Shooting => new ShootingActions(this);

    // WeaponSwitch
    private readonly InputActionMap m_WeaponSwitch;
    private List<IWeaponSwitchActions> m_WeaponSwitchActionsCallbackInterfaces = new List<IWeaponSwitchActions>();
    private readonly InputAction m_WeaponSwitch_SetPistol;
    private readonly InputAction m_WeaponSwitch_SetShotgun;
    private readonly InputAction m_WeaponSwitch_SetMachineGun;
    public struct WeaponSwitchActions
    {
        private @PlayerControls m_Wrapper;
        public WeaponSwitchActions(@PlayerControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @SetPistol => m_Wrapper.m_WeaponSwitch_SetPistol;
        public InputAction @SetShotgun => m_Wrapper.m_WeaponSwitch_SetShotgun;
        public InputAction @SetMachineGun => m_Wrapper.m_WeaponSwitch_SetMachineGun;
        public InputActionMap Get() { return m_Wrapper.m_WeaponSwitch; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(WeaponSwitchActions set) { return set.Get(); }
        public void AddCallbacks(IWeaponSwitchActions instance)
        {
            if (instance == null || m_Wrapper.m_WeaponSwitchActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_WeaponSwitchActionsCallbackInterfaces.Add(instance);
            @SetPistol.started += instance.OnSetPistol;
            @SetPistol.performed += instance.OnSetPistol;
            @SetPistol.canceled += instance.OnSetPistol;
            @SetShotgun.started += instance.OnSetShotgun;
            @SetShotgun.performed += instance.OnSetShotgun;
            @SetShotgun.canceled += instance.OnSetShotgun;
            @SetMachineGun.started += instance.OnSetMachineGun;
            @SetMachineGun.performed += instance.OnSetMachineGun;
            @SetMachineGun.canceled += instance.OnSetMachineGun;
        }

        private void UnregisterCallbacks(IWeaponSwitchActions instance)
        {
            @SetPistol.started -= instance.OnSetPistol;
            @SetPistol.performed -= instance.OnSetPistol;
            @SetPistol.canceled -= instance.OnSetPistol;
            @SetShotgun.started -= instance.OnSetShotgun;
            @SetShotgun.performed -= instance.OnSetShotgun;
            @SetShotgun.canceled -= instance.OnSetShotgun;
            @SetMachineGun.started -= instance.OnSetMachineGun;
            @SetMachineGun.performed -= instance.OnSetMachineGun;
            @SetMachineGun.canceled -= instance.OnSetMachineGun;
        }

        public void RemoveCallbacks(IWeaponSwitchActions instance)
        {
            if (m_Wrapper.m_WeaponSwitchActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(IWeaponSwitchActions instance)
        {
            foreach (var item in m_Wrapper.m_WeaponSwitchActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_WeaponSwitchActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public WeaponSwitchActions @WeaponSwitch => new WeaponSwitchActions(this);

    // MenuControl
    private readonly InputActionMap m_MenuControl;
    private List<IMenuControlActions> m_MenuControlActionsCallbackInterfaces = new List<IMenuControlActions>();
    private readonly InputAction m_MenuControl_Newaction;
    private readonly InputAction m_MenuControl_EscapeMenu;
    private readonly InputAction m_MenuControl_UpgradeMenu;
    public struct MenuControlActions
    {
        private @PlayerControls m_Wrapper;
        public MenuControlActions(@PlayerControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Newaction => m_Wrapper.m_MenuControl_Newaction;
        public InputAction @EscapeMenu => m_Wrapper.m_MenuControl_EscapeMenu;
        public InputAction @UpgradeMenu => m_Wrapper.m_MenuControl_UpgradeMenu;
        public InputActionMap Get() { return m_Wrapper.m_MenuControl; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(MenuControlActions set) { return set.Get(); }
        public void AddCallbacks(IMenuControlActions instance)
        {
            if (instance == null || m_Wrapper.m_MenuControlActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_MenuControlActionsCallbackInterfaces.Add(instance);
            @Newaction.started += instance.OnNewaction;
            @Newaction.performed += instance.OnNewaction;
            @Newaction.canceled += instance.OnNewaction;
            @EscapeMenu.started += instance.OnEscapeMenu;
            @EscapeMenu.performed += instance.OnEscapeMenu;
            @EscapeMenu.canceled += instance.OnEscapeMenu;
            @UpgradeMenu.started += instance.OnUpgradeMenu;
            @UpgradeMenu.performed += instance.OnUpgradeMenu;
            @UpgradeMenu.canceled += instance.OnUpgradeMenu;
        }

        private void UnregisterCallbacks(IMenuControlActions instance)
        {
            @Newaction.started -= instance.OnNewaction;
            @Newaction.performed -= instance.OnNewaction;
            @Newaction.canceled -= instance.OnNewaction;
            @EscapeMenu.started -= instance.OnEscapeMenu;
            @EscapeMenu.performed -= instance.OnEscapeMenu;
            @EscapeMenu.canceled -= instance.OnEscapeMenu;
            @UpgradeMenu.started -= instance.OnUpgradeMenu;
            @UpgradeMenu.performed -= instance.OnUpgradeMenu;
            @UpgradeMenu.canceled -= instance.OnUpgradeMenu;
        }

        public void RemoveCallbacks(IMenuControlActions instance)
        {
            if (m_Wrapper.m_MenuControlActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(IMenuControlActions instance)
        {
            foreach (var item in m_Wrapper.m_MenuControlActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_MenuControlActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public MenuControlActions @MenuControl => new MenuControlActions(this);
    public interface IShootingActions
    {
        void OnShoot(InputAction.CallbackContext context);
        void OnReload(InputAction.CallbackContext context);
        void OnAutoShoot(InputAction.CallbackContext context);
    }
    public interface IWeaponSwitchActions
    {
        void OnSetPistol(InputAction.CallbackContext context);
        void OnSetShotgun(InputAction.CallbackContext context);
        void OnSetMachineGun(InputAction.CallbackContext context);
    }
    public interface IMenuControlActions
    {
        void OnNewaction(InputAction.CallbackContext context);
        void OnEscapeMenu(InputAction.CallbackContext context);
        void OnUpgradeMenu(InputAction.CallbackContext context);
    }
}
