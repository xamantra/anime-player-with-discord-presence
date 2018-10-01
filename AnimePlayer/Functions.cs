using System.Windows.Forms;

namespace AnimePlayer
{
    static class Functions
    {
        public static void NextEpisode(Main main, ComboBox epsList)
        {
            TrayRefresh.RefreshTrayArea();
            if (epsList.Items.Count >= 1)
            {
                if (epsList.SelectedIndex < (epsList.Items.Count - 1))
                    epsList.SelectedIndex += 1;
                else
                    epsList.SelectedIndex = 0;
                main.StartWatch();
            }
        }

        public static void PrevEpisode(Main main, ComboBox epsList)
        {
            TrayRefresh.RefreshTrayArea();
            if (epsList.Items.Count >= 1)
            {
                if (epsList.SelectedIndex != 0)
                    epsList.SelectedIndex -= 1;
                else
                    epsList.SelectedIndex = epsList.Items.Count - 1;
                main.StartWatch();
            }
        }
    }
}