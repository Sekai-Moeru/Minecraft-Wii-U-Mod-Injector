using System.Threading.Tasks;
using Avalonia.Controls;

namespace Minecraft_Wii_U_Mod_Injector.Helpers.Win_Forms
{
    internal class Messaging
    {
        public static Window? Owner { get; set; }

        public enum MessageType { Info, Error, Warning, Success, None }

        public static async Task Show(string message)
            => await ShowDialog(message, "", MessageType.Info);

        public static async Task Show(string message, string caption)
            => await ShowDialog(message, caption, MessageType.Info);

        public static async Task Show(MessageType type, string message)
            => await ShowDialog(message, "", type);

        public static async Task<bool> ShowConfirm(string message)
            => await ShowDialogConfirm(message, "");

        private static async Task ShowDialog(string message, string caption, MessageType type)
        {
            var dialog = new Window
            {
                Title = "Minecraft Wii U Mod Injector" + (caption != "" ? " - " + caption : ""),
                Width = 400,
                Height = 180,
                WindowStartupLocation = WindowStartupLocation.CenterOwner,
                CanResize = false,
                Content = new Avalonia.Controls.TextBlock
                {
                    Text = message,
                    Margin = new Avalonia.Thickness(20),
                    TextWrapping = Avalonia.Media.TextWrapping.Wrap
                }
            };
            await dialog.ShowDialog(Owner);
        }

        private static async Task<bool> ShowDialogConfirm(string message, string caption)
        {
            var result = false;
            var dialog = new Window
            {
                Title = "Minecraft Wii U Mod Injector" + (caption != "" ? " - " + caption : ""),
                Width = 400,
                Height = 180,
                WindowStartupLocation = WindowStartupLocation.CenterOwner,
                CanResize = false
            };
            // i have no idea whats going on here, this is 100% from docs. i'll hook up OK and Cancel buttons when something hits a form that uses it
            await dialog.ShowDialog(Owner);
            return result;
        }
    }
}
