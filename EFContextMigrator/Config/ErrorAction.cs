namespace EFContextMigrator.Config
{
    /// <summary>
    /// Error actions
    /// </summary>
    public enum ErrorAction
    {
        /// <summary>
        /// Continue execution and log error
        /// </summary>
        IgnoreAndLog,

        /// <summary>
        /// Stop work and throw an exception
        /// </summary>
        Break,

        /// <summary>
        /// Continue execution and do not log error
        /// </summary>
        SilentlyContinue
    }
}