using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DiscordRPC;
using DiscordRPC.Logging;

namespace DiscordRPC1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public DiscordRPC.DiscordRpcClient client;
        bool ayarlimi = false;

        private void button2_Click(object sender, EventArgs e)
        {
            if (!ayarlimi)
                MessageBox.Show("Lütfen ayarla butonuna basınız.");

            else
            {
                DiscordRPC.Button[] buttons = new DiscordRPC.Button[]
                {
                new DiscordRPC.Button
                {
                    Label = textBox1.Text,
                    Url = textBox2.Text
                },
                };

                client.SetPresence(new DiscordRPC.RichPresence()
                {
                    State = yazacakBaslik.Text,
                    Details = yazacakAciklama.Text,
                    Buttons = buttons,
                    Assets = new Assets()
                    {
                        SmallImageKey = kucukResimURL.Text,
                        SmallImageText = kucukYazi.Text,
                        LargeImageKey = resimURL.Text,
                        LargeImageText = buyukYazi.Text
                    }
                });
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            ayarlimi = true;
            client = new DiscordRPC.DiscordRpcClient(appID.Text);
            client.Logger = new ConsoleLogger() { Level = LogLevel.Warning };
            client.Initialize();
        }
    }
}
