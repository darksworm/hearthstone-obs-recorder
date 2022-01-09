using System;
using System.Windows.Media;
using Hearthstone_Deck_Tracker.API;
using Hearthstone_Deck_Tracker.Plugins;
using ToastManager = Hearthstone_Deck_Tracker.Utility.Toasts.ToastManager;

namespace RecorderPlugin
{
    public class RecorderPlugin : IPlugin
    {
        private readonly Recorder Recorder = new Recorder();
        private readonly SettingsDialog SettingsDialog;
        private readonly SettingStore SettingStore = new SettingStore();

        private const int DELAY_AFTER_GAME_END_SECONDS = 10;
        public string ButtonText => "Settings";
        public string Name => "Hearthstone OBS recorder";
        public string Author => "darksworm";
        public string Description => "Starts recording in OBS when HS game begins and stops when the game ends. To use this you will need to install OBS and the obs-websocket plugin.";

        public System.Windows.Controls.MenuItem MenuItem => null;

        public RecorderPlugin()
        {
            if (SettingStore.Load() is SettingStore.Settings settings)
            {
                Recorder.UpdateSettings(settings.IPAddress, settings.Port, settings.Password);
                SettingsDialog = new SettingsDialog(settings.IPAddress, settings.Port, settings.Password);
            }
            else
            {
                SettingsDialog = new SettingsDialog("127.0.0.1", "4444", "");
                Recorder.UpdateSettings("127.0.0.1", "4444", "");
            }

            SettingsDialog.SettingsChanged += OnSettingsChanged;
        }

        private void OnSettingsChanged(object _, SettingsDialog.SettingsChangedEvent e)
        {
            Recorder.UpdateSettings(e.IPAddress, e.Port, e.Password);

            if (!Connect())
            {
                return;
            }

            SettingStore.Save(e.IPAddress, e.Port, e.Password);
            SettingsDialog.Close();
        }

        private bool Connect()
        {
            try
            {
                Recorder.Connect();
            }
            catch (Recorder.ConnectionFailedException)
            {
                ToastManager.ShowCustomToast(Toasts.MakeErrorToast("Connection to OBS failed!"));
                return false;
            }
            catch (Recorder.AuthorizationFailedException)
            {
                ToastManager.ShowCustomToast(Toasts.MakeErrorToast("Invalid password!"));
                return false;
            }

            ToastManager.ShowCustomToast(Toasts.MakeSuccessToast("Connected to OBS!"));

            return true;
        }

        public void OnLoad()
        {
            GameEvents.OnGameEnd.Add(() => Recorder.StopAfter(DELAY_AFTER_GAME_END_SECONDS));
            GameEvents.OnGameStart.Add(Recorder.StartRecording);
            Connect();
        }
        
        public void OnUnload()
        {
            Recorder.Unload();
        }

        public void OnUpdate()
        {
            Recorder.Update();
        }

        public void OnButtonPress()
        {
            if (!SettingsDialog.Visible)
            {
                SettingsDialog.ShowDialog();
            }

            SettingsDialog.Focus();
        }

        public Version Version
        {
            get { return new Version(0, 0, 2); }
        }

        private static class Toasts
        {
            public static System.Windows.Controls.UserControl MakeSuccessToast(string message)
            {
                var content = new System.Windows.Controls.UserControl();
                content.Background = (Brush)(new BrushConverter()).ConvertFromString("#00a124");
                content.Content = message;
                content.Foreground = Brushes.White;
                content.FontSize = 36;
                content.FontFamily = new FontFamily("Arial");
                content.Padding = new System.Windows.Thickness(12);
                return content;
            }

            public static System.Windows.Controls.UserControl MakeErrorToast(string error)
            {
                var content = new System.Windows.Controls.UserControl();
                content.Background = (Brush)(new BrushConverter()).ConvertFromString("#a20010");
                content.Content = error;
                content.Foreground = Brushes.White;
                content.FontSize = 36;
                content.FontFamily = new FontFamily("Arial");
                content.Padding = new System.Windows.Thickness(12);
                return content;
            }
        }
    }
}