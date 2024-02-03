namespace AquariusShell.Modules
{
    /// <summary>
    /// Common extension functions when calling API functions
    /// </summary>
    internal static partial class CommonApiExtensions
    {
        /// <summary>
        /// Check if an integer flag is set
        /// </summary>
        /// <param name="flag">Value with multiple flag bits set</param>
        /// <param name="method">Whether to test all flags or the first match</param>
        /// <param name="check">(Array of) Particular bits to check</param>
        /// <returns>True if flag is present</returns>
        public static bool HasFlag(this uint flag, FlagCheckMethodEnum method, params uint[] check)
        {
            int matchCount = 0;
            foreach (uint i in check)
            {
                if ((flag & i) == i)
                {
                    matchCount++;
                }
            }

            switch (method)
            {
                case FlagCheckMethodEnum.AnyOf:
                    if (matchCount > 0)
                    {
                        return true;
                    }
                    break;

                case FlagCheckMethodEnum.AllOf:
                    if (matchCount == check.Length)
                    {
                        return true;
                    }
                    break;
            }

            return false;
        }
    }
}
