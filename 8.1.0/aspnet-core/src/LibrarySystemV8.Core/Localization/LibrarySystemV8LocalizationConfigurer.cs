using Abp.Configuration.Startup;
using Abp.Localization.Dictionaries;
using Abp.Localization.Dictionaries.Xml;
using Abp.Reflection.Extensions;

namespace LibrarySystemV8.Localization
{
    public static class LibrarySystemV8LocalizationConfigurer
    {
        public static void Configure(ILocalizationConfiguration localizationConfiguration)
        {
            localizationConfiguration.Sources.Add(
                new DictionaryBasedLocalizationSource(LibrarySystemV8Consts.LocalizationSourceName,
                    new XmlEmbeddedFileLocalizationDictionaryProvider(
                        typeof(LibrarySystemV8LocalizationConfigurer).GetAssembly(),
                        "LibrarySystemV8.Localization.SourceFiles"
                    )
                )
            );
        }
    }
}
