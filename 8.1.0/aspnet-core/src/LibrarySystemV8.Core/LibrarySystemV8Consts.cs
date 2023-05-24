using LibrarySystemV8.Debugging;

namespace LibrarySystemV8
{
    public class LibrarySystemV8Consts
    {
        public const string LocalizationSourceName = "LibrarySystemV8";

        public const string ConnectionStringName = "Default";

        public const bool MultiTenancyEnabled = true;


        /// <summary>
        /// Default pass phrase for SimpleStringCipher decrypt/encrypt operations
        /// </summary>
        public static readonly string DefaultPassPhrase =
            DebugHelper.IsDebug ? "gsKxGZ012HLL3MI5" : "6f9182023f024b9c879cf5f1d708af56";
    }
}
