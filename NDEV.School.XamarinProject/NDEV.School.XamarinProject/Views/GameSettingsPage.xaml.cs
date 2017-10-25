using NDEV.MasterClasses.Xamarin.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace NDEV.School.XamarinProject.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class GameSettingsPage : ContentPage
    {
        public GameSettingsPage()
        {
            InitializeComponent();

            this._initSubscribeEvents();
        }

        private const string ENTRY_PLACEHOLDER_NAME = "Enter name!";
        private const string CPU_NAME_1 = "CPU1";
        private const string CPU_NAME_2 = "CPU2";
        private const string CPU_NAME_3 = "CPU3";
        private const string CPU_NAME_4 = "CPU4";

        private void _initSubscribeEvents()
        {
            this.radioButtonPlayerSelecter.Button1.Clicked += buttonPlayerNumberSelecter_Clicked;
            this.radioButtonPlayerSelecter.Button2.Clicked += buttonPlayerNumberSelecter_Clicked;

            this.radioButtonPlayerType1.Button1.Clicked += buttonPlayerTypeSelecter_Clicked;
            this.radioButtonPlayerType1.Button2.Clicked += buttonPlayerTypeSelecter_Clicked;
            this.radioButtonPlayerType2.Button1.Clicked += buttonPlayerTypeSelecter_Clicked;
            this.radioButtonPlayerType2.Button2.Clicked += buttonPlayerTypeSelecter_Clicked;
            this.radioButtonPlayerType3.Button1.Clicked += buttonPlayerTypeSelecter_Clicked;
            this.radioButtonPlayerType3.Button2.Clicked += buttonPlayerTypeSelecter_Clicked;
            this.radioButtonPlayerType4.Button1.Clicked += buttonPlayerTypeSelecter_Clicked;
            this.radioButtonPlayerType4.Button2.Clicked += buttonPlayerTypeSelecter_Clicked;
        }

        private void buttonPremadeMapChecker_Clicked(object sender, EventArgs e)
        {
            //megnyitni egy oldalt
            //a selected gombra mondjuk rairni a nevet
        }

        private void buttonPlayerNumberSelecter_Clicked(object sender, EventArgs e)
        {
            MyXamarinButton button = (MyXamarinButton)sender;
            bool isEnabledThatRow = (button == this.radioButtonPlayerSelecter.Button1) ? false : true;

            this.radioButtonPlayerType4.IsVisible = isEnabledThatRow;
            this.radioButtonPlayerNameEntry4.IsVisible = isEnabledThatRow;
            this.radioButtonPlayer4PlaceHolder.IsVisible = !isEnabledThatRow;
        }

        private void buttonPlayerTypeSelecter_Clicked(object sender, EventArgs e)
        {
            MyXamarinButton button = (MyXamarinButton)sender;
            //MyXamarinTwoOptionRadioButton buttonParent = (MyXamarinTwoOptionRadioButton)button.Parent;
            //string buttonParentName = buttonParent. //parentXName? Reflection off; binding mb later

            if(button.Parent == this.radioButtonPlayerType1)
            {
                this._playerTypeSelecter(button, this.radioButtonPlayerType1, this.radioButtonPlayerNameEntry1, CPU_NAME_1);
            }
            else if(button.Parent == this.radioButtonPlayerType2)
            {
                this._playerTypeSelecter(button, this.radioButtonPlayerType2, this.radioButtonPlayerNameEntry2, CPU_NAME_2);
            }
            else if(button.Parent == this.radioButtonPlayerType3)
            {
                this._playerTypeSelecter(button, this.radioButtonPlayerType3, this.radioButtonPlayerNameEntry3, CPU_NAME_3);
            }
            else
            {
                this._playerTypeSelecter(button, this.radioButtonPlayerType4, this.radioButtonPlayerNameEntry4, CPU_NAME_4);
            }
        }

        private void _playerTypeSelecter(MyXamarinButton button, MyXamarinTwoOptionRadioButton radioButton, MyXamarinEntry entry, string cpuName)
        {
            if(button == radioButton.Button1)
            {
                entry.IsEnabled = true;
                entry.Text = null;
                entry.Placeholder = ENTRY_PLACEHOLDER_NAME;
            }
            else
            {
                entry.IsEnabled = false;
                entry.Text = cpuName;
            }
        }
    }
}