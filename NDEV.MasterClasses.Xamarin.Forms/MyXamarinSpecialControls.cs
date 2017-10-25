using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace NDEV.MasterClasses.Xamarin.Forms
{
    public class GridPlayerSettings : MyXamarinGrid
    {
        public GridPlayerSettings() : base()
        {
            this._setTheGrid();
            this._initThePlayerRowList();

        }

        private List<GridPlayerRow> _gridPlayerRowList;

        private const int MAX_PLAYER_NUMBER = 4;

        private void _setTheGrid()
        {
            this.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });
            this.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });
            this.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });
            this.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });

            this.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
            this.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
            this.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
        }

        private void _initThePlayerRowList()
        {
            this._gridPlayerRowList = new List<GridPlayerRow>();
            for(int i = 0; i < MAX_PLAYER_NUMBER; ++i)
            {
                this._gridPlayerRowList.Add(new GridPlayerRow());
            }
        }



        public class GridPlayerRow
        {
            public GridPlayerRow()
            {
                this.Label = new MyXamarinLabel
                {
                    Text = string.Format(LABEL_TEXT_PATTERN, _playerNumber)
                };

                this.RadioButton = new MyXamarinTwoOptionRadioButton
                {
                    Button1Text = RADIO_BUTTON_PLAYER1_HUMAN,
                    Button2Text = RADIO_BUTTON_PLAYER2_CPU
                };

                this.Entry = new MyXamarinEntry
                {
                    Placeholder = ENTRY_PLACEHOLDER
                };

                ++_playerNumber;
            }

            public MyXamarinLabel Label { get; private set; }
            public MyXamarinTwoOptionRadioButton RadioButton { get; private set; }
            public MyXamarinEntry Entry { get; private set; }

            private static int _playerNumber = 1;

            private const string LABEL_TEXT_PATTERN = "Player {0}";
            private const string RADIO_BUTTON_PLAYER1_HUMAN = "Human";
            private const string RADIO_BUTTON_PLAYER2_CPU = "CPU";
            private const string ENTRY_PLACEHOLDER = "Enter name!";
        }


    }
}
