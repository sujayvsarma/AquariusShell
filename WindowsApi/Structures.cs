namespace AquariusShell.WindowsApi
{
    /// <summary>
    /// LUID structure used with privilege operations
    /// </summary>
    public struct LUID
    {
        public int LowPart;
        public int HighPart;
    }

    /// <summary>
    /// LUID structure used with privilege operations
    /// </summary>
    public struct LUID_AND_ATTRIBUTES
    {
        public LUID pLuid;
        public int Attributes;
    }

    /// <summary>
    /// Privilege lookup/demand structure
    /// </summary>
    public struct TOKEN_PRIVILEGES
    {
        public int PrivilegeCount;
        public LUID_AND_ATTRIBUTES Privileges;
    }
}
