
using Gma.System.MouseKeyHook;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace AnimePlayer
{
    static class GlobalHotkey
    {
        private static IKeyboardEvents globalHook;

        public static void Subscribe()
        {
            globalHook = Hook.GlobalEvents();

            globalHook.KeyPress += GlobalHook_KeyPress;

            var altN = Combination.FromString("Alt+N");
            Action nextEpisode = () => {
                Functions.NextEpisode(Main.Default, Main.Default.epsList);
            };

            var altP = Combination.FromString("Alt+P");
            Action prevEpisode = () =>
            {
                Functions.PrevEpisode(Main.Default, Main.Default.epsList);
            };

            var altQ = Combination.FromString("Alt+Q");
            Action quit = () =>
            {
                Main.Default.QuitApp();
            };

            var keyCombs = new Dictionary<Combination, Action>
            {
                {altN, nextEpisode },
                {altP, prevEpisode },
                {altQ, quit }
            };

            Hook.GlobalEvents().OnCombination(keyCombs);
        }

        private static void GlobalHook_KeyPress(object sender, KeyPressEventArgs e)
        {
            Console.WriteLine(e.KeyChar);
        }

        public static void Unsubscribe()
        {
            globalHook.KeyPress -= GlobalHook_KeyPress;
        }
    }
}