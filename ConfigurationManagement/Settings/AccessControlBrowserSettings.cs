using AquariusShell.ConfigurationManagement.Reflection;

namespace AquariusShell.ConfigurationManagement.Settings
{
    /// <summary>
    /// Settings for the Access Control Browser
    /// </summary>
    [RegistryKeyName("ShellApps\\AccessControlBrowser")]
    internal class AccessControlBrowserSettings : IAquariusShellSettings
    {
        /// <summary>
        /// Show the app on the launcher
        /// </summary>
        [RegistryValueName("ShowOnLauncher")]
        public bool ShowOnLauncher
        {
            get; set;

        } = true;

        /// <summary>
        /// Only if ShowOnLauncher is TRUE. Customization of the ShellApp icon on the launcher.
        /// </summary>
        [RegistryValueName("CustomButton")]
        public CustomButtonSettings CustomButton
        {
            get; set;

        } = new();

        /// <summary>
        /// Enable "take ownership"
        /// </summary>
        [RegistryValueName("AllowTakeOwnership")]
        public bool AllowTakeOwnership
        {
            get; set;

        } = true;

        /// <summary>
        /// Enable setting another principal as the owner
        /// </summary>
        [RegistryValueName("AllowReplaceOwnerWithPrincipal")]
        public bool AllowReplaceOwnerWithPrincipal
        {
            get; set;

        } = true;

        /// <summary>
        /// Enable "delete principal"
        /// </summary>
        [RegistryValueName("AllowDeletePrincipal")]
        public bool AllowDeletePrincipal
        {
            get; set;

        } = true;

        /// <summary>
        /// Enable "edit principal"
        /// </summary>
        [RegistryValueName("AllowEditPrincipal")]
        public bool AllowEditPrincipal
        {
            get; set;

        } = true;

        /// <summary>
        /// Enable "add principal"
        /// </summary>
        [RegistryValueName("AllowAddPrincipal")]
        public bool AllowAddPrincipal
        {
            get; set;

        } = true;

        /// <summary>
        /// Enable the "Allow" type of ACLs
        /// </summary>
        [RegistryValueName("AllowSettingAllowAcls")]
        public bool AllowSettingAllowAcls
        {
            get; set;

        } = true;

        /// <summary>
        /// Enable the "Deny" type of ACLs
        /// </summary>
        [RegistryValueName("AllowSettingDenyAcls")]
        public bool AllowSettingDenyAcls
        {
            get; set;

        } = true;

        /// <summary>
        /// Enable the "DI/CI" (directory/container inherited) type of ACLs
        /// </summary>
        [RegistryValueName("AllowSettingDirectoryInheritedAcls")]
        public bool AllowSettingDirectoryInheritedAcls
        {
            get; set;

        } = true;

        /// <summary>
        /// Enable the "OI" (object inherited) type of ACLs
        /// </summary>
        [RegistryValueName("AllowSettingObjectInheritedAcls")]
        public bool AllowSettingObjectInheritedAcls
        {
            get; set;

        } = true;

        /// <summary>
        /// Enable the "X" (inheritance broken or not-inherited) type of ACLs
        /// </summary>
        [RegistryValueName("AllowSettingStandaloneAcls")]
        public bool AllowSettingStandaloneAcls
        {
            get; set;

        } = true;


    }
}
