using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace AnimePlayer
{
    public partial class Main : Form
    {
        private const char slash = '\\';
        public NotifyIcon icon;
        public Process easyrp;
        public Process playingEpisode;
        private string startTime = null;
        private bool isHidden = false;

        public static Main Default { get; private set; }

        public Main()
        {
            Default = this;
            InitializeComponent();
        }

        private void animeName_TextChanged(object sender, EventArgs e)
        {
            epsList.Items.Clear();
            foreach (var item in AnimeLoader.Animes[animeList.SelectedItem.ToString()].Episodes)
            {
                epsList.Items.Add(item.Key);
            }

            epsList.SelectedIndex = 0;

            SetButtons();
        }

        private void UpdateConfig()
        {
            string details = "Details=";
            string state = "State=";
            if (startTime == null)
                startTime = "StartTimestamp=" + DateTimeOffset.UtcNow.ToUnixTimeSeconds().ToString();
            string presence = File.ReadAllText(@"easyrp\configDefault.ini");
            string newPresence = "";
            if (animeList.SelectedItem != null) newPresence = presence.Replace(details, details + animeList.SelectedItem.ToString());
            string currentEpisode = "";
            try
            {
                currentEpisode = Convert.ToInt32(epsList.SelectedItem.ToString()).ToString();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            if (animeList.SelectedItem != null) newPresence = newPresence.Replace(state, state + "Episode " + currentEpisode + "/" + AnimeLoader.Animes[animeList.SelectedItem.ToString()].MaxEpisode.ToString());
            newPresence = newPresence.Replace("StartTimestamp=", startTime);
            File.WriteAllText("config.ini", newPresence);
        }

        private void ToggleTray()
        {
            isHidden = !isHidden;
            icon.Visible = isHidden;
            if (isHidden) Hide();
            else Show();
        }

        private void hideOnTray_Click(object sender, EventArgs e)
        {
            ToggleTray();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            TrayRefresh.RefreshTrayArea();
            GlobalHotkey.Subscribe();
            SetButtons();
            AnimeLoader.Loadlist();
            icon = new NotifyIcon
            {
                Icon = Icon,
                Visible = false,
                Text = "Easy RP Helper"
            };

            icon.MouseClick += Icon_MouseClick;
            icon.Text = "AnimePlayer with Discord Presence";

            foreach (var item in AnimeLoader.Animes)
            {
                if (item.Value.Name != "Name")
                    animeList.Items.Add(item.Value.Name);
            }
        }

        private void Icon_MouseClick(object sender, MouseEventArgs e)
        {
            ToggleTray();
        }

        private void rpcUpdate_Click(object sender, EventArgs e)
        {
            StartPresence();
        }

        private void StartPresence()
        {
            ProcessStartInfo processStartInfo = new ProcessStartInfo(@"easyrp\easyrp.exe");
            processStartInfo.CreateNoWindow = true;
            processStartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            easyrp = Process.Start(processStartInfo);
        }

        private void browseDirectory_Click(object sender, EventArgs e)
        {
            if (folderBrowser.ShowDialog(this) == DialogResult.OK)
            {
                string path = folderBrowser.SelectedPath;
                var files = Directory.GetFiles(path).ToList();
                if (files.Count == 0)
                {
                    return;
                }

                files.Sort();
                string animeName = path.Substring(path.LastIndexOf(slash) + 1);
                var episodes = new Dictionary<string, string>();
                foreach (var item in files)
                {
                    string fileName = item.Substring(item.LastIndexOf(slash) + 1);
                    string episode = fileName.Replace(fileName.Substring(fileName.LastIndexOf('.')), "");
                    episodes.Add(episode.ToString(), item);
                }
                AnimeLoader.Add(new Anime(animeName, files.Count.ToString(), episodes));
                animeList.Items.Clear();
                foreach (var item in AnimeLoader.Animes)
                {
                    if (item.Value.Name != "Name")
                        animeList.Items.Add(item.Value.Name);
                }
                animeList.SelectedItem = animeName;
            }
        }

        private void nextEp_Click(object sender, EventArgs e)
        {
            Functions.NextEpisode(this, epsList);
        }

        private void prevEp_Click(object sender, EventArgs e)
        {
            Functions.PrevEpisode(this, epsList);
        }

        private void SetButtons()
        {
            if (epsList.Items.Count > 0)
            {
                nextEp.Enabled = true;
                prevEp.Enabled = true;
            }
            else
            {
                nextEp.Enabled = false;
                prevEp.Enabled = false;
            }

            if (animeList.SelectedItem == null || epsList.SelectedItem == null)
            {
                startWatch.Enabled = false;
            }
            else
            {
                startWatch.Enabled = true;
            }
        }

        private void episode_Changed(object sender, EventArgs e)
        {
            UpdateConfig();
        }

        private void quit_Click(object sender, EventArgs e)
        {
            QuitApp();
        }

        private void startWatch_Click(object sender, EventArgs e)
        {
            StartPresence();
            StartWatch();
        }

        public void StartWatch()
        {
            if (playingEpisode == null)
                StartProcess();
            else
            {
                if (!playingEpisode.HasExited)
                    playingEpisode.Kill();
                playingEpisode.Dispose();
                playingEpisode = null;
                StartProcess();
            }
        }

        private void StartProcess()
        {
            playingEpisode = Process.Start(AnimeLoader.Animes[animeList.SelectedItem.ToString()].Episodes[epsList.SelectedItem.ToString()]);
        }

        private void Main_FormClosed(object sender, FormClosedEventArgs e)
        {
            QuitApp();
        }

        public void QuitApp()
        {
            GlobalHotkey.Unsubscribe();
            if (easyrp != null && easyrp.HasExited == false)
            {
                easyrp.Kill();
                easyrp.Dispose();
                easyrp = null;
            }
            if (playingEpisode != null && !playingEpisode.HasExited)
            {
                playingEpisode.Kill();
                playingEpisode.Dispose();
                playingEpisode = null;
            }
            Application.Exit();
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            if (animeList.SelectedItem == null || animeList.SelectedItem.ToString() == "")
            {
                return;
            }
            else
            {
                AnimeLoader.Remove(animeList.SelectedItem.ToString());
                animeList.Items.Remove(animeList.SelectedItem);
                if (animeList.Items.Count > 0)
                {
                    animeList.SelectedIndex = 0;
                }
            }
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            if (animeList.Items.Count == 0)
            {
                startWatch.Enabled = false;
                deleteButton.Enabled = false;
                epsList.Items.Clear();
                nextEp.Enabled = false;
                prevEp.Enabled = false;
            }

            if (playingEpisode == null) return;
            if (!playingEpisode.HasExited)
            {
                startWatch.Enabled = false;
                deleteButton.Enabled = false;
            }
            else
            {
                if (animeList.Items.Count == 0)
                {
                    startWatch.Enabled = false;
                    deleteButton.Enabled = false;
                }
                else
                {
                    startWatch.Enabled = true;
                    deleteButton.Enabled = true;
                }
            }
        }

        private void wallpaper_Click(object sender, EventArgs e)
        {

        }
    }
}