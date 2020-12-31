using Godot;

public class Localization : HBoxContainer
{
    ConfigFile config = new ConfigFile();

    public override void _Ready()
    {
        Error error = config.Load("user://settings.cfg"); // Load settings.cfg
        if (error == Error.Ok) TranslationServer.SetLocale(config.GetValue("config", "locale", "en").ToString());
        // Here, if (error == Error.Ok) is a positive result, if it returns true, it changes locale to the value in settings.cfg or 'en' (by default) if the key doesn't exist
        else GD.Print("Error reading config file. (File not found?)"); // If loading failed, print message
    }

    /*
        These methods are all linked to their respective buttons via signals. They set the locale then save it in the settings.cfg file. Similar to Unity's PlayerPrefs
                                                                                                                                                      (but not really)
    */

    private void _Bulgarian()
    {
        TranslationServer.SetLocale("bg");
        config.SetValue("config", "locale", "bg");
        config.Save("user://settings.cfg");
    }

    private void _Czech()
    {
        TranslationServer.SetLocale("cs");
        config.SetValue("config", "locale", "cs");
        config.Save("user://settings.cfg");
    }

    private void _English()
    {
        TranslationServer.SetLocale("en");
        config.SetValue("config", "locale", "en");
        config.Save("user://settings.cfg");
    }

    private void _French()
    {
        TranslationServer.SetLocale("fr");
        config.SetValue("config", "locale", "fr");
        config.Save("user://settings.cfg");
    }

    private void _Romanian()
    {
        TranslationServer.SetLocale("ro");
        config.SetValue("config", "locale", "ro");
        config.Save("user://settings.cfg");
    }
}
