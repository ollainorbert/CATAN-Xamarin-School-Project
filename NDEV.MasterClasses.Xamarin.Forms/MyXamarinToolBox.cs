using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace NDEV.MasterClasses.Xamarin.Forms
{
    public class MyXamarinGrid : Grid
    {
        public MyXamarinGrid()
        {
            this.BackgroundColor = Color.AliceBlue;
        }
    }

    public class MyXamarinLabel : Label
    {
        public MyXamarinLabel()
        {
            this.BackgroundColor = Color.YellowGreen;
            this.VerticalTextAlignment = TextAlignment.Center;
            this.HorizontalTextAlignment = TextAlignment.Center;
        }

        public string Name { get; private set; }
    }

    public class MyXamarinButton : Button
    {
        public MyXamarinButton()
        {
            this._defaultBackgroundColor = this.BackgroundColor;
            this._defaultBorderColor = this.BorderColor;
            this._defaultBorderWidth = this.BorderWidth;
            this.IsClicked = false;
        }

        private Color _defaultBackgroundColor;
        private Color _defaultBorderColor;
        private double _defaultBorderWidth;
        public bool IsClicked { get; private set; }

        public void MyXamarinButton_Clicked()
        {
            if (!this.IsClicked)
            {
                this._clickedProps();
            }
            else
            {
                this._unClickedProps();
            }

            this.IsClicked = !this.IsClicked;
        }

        private void _clickedProps()
        {
            this._switchActiveDesign(Color.Orange, Color.DarkOrange, 3);
        }

        private void _unClickedProps()
        {
            this._switchActiveDesign(this._defaultBackgroundColor, this._defaultBorderColor, this._defaultBorderWidth);
        }

        private void _switchActiveDesign(Color backgroundColor, Color borderColor, double borderWidth)
        {
            this.BackgroundColor = backgroundColor;
            this.BorderColor = borderColor;
            this.BorderWidth = borderWidth; 
        }
    }

    public class MyXamarinTwoOptionRadioButton : MyXamarinGrid
    {
        public MyXamarinTwoOptionRadioButton() : base()
        {
            this.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
            this.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });

            this.Button1 = new MyXamarinButton();
            this.Button2 = new MyXamarinButton();

            this.Button1.Clicked += this.MyXamarinRadioButton_Clicked;
            this.Button2.Clicked += this.MyXamarinRadioButton_Clicked;

            this.Children.Add(this.Button1, 0, 0);
            this.Children.Add(this.Button2, 1, 0);   
        }

        private const string BUTTON_BINDING_PATTERN = "{0}{1}";
        private const string BUTTON_TEXT_EXT = "Text";
        private const int BUTTON_NUMBER = 2;

        public MyXamarinButton Button1 { get; private set; }
        public MyXamarinButton Button2 { get; private set; }

        public static readonly BindableProperty Button1stringProperty = BindableProperty.Create
            (
                 string.Format(BUTTON_BINDING_PATTERN, nameof(Button1), BUTTON_TEXT_EXT),
                 typeof(string),
                 typeof(MyXamarinTwoOptionRadioButton),
                 null,
                 BindingMode.OneWay,
                 propertyChanged: OnTextChangedButton1Text
            );

        public static readonly BindableProperty Button2stringProperty = BindableProperty.Create
            (
                 string.Format(BUTTON_BINDING_PATTERN, nameof(Button2), BUTTON_TEXT_EXT),
                 typeof(string),
                 typeof(MyXamarinTwoOptionRadioButton),
                 null,
                 BindingMode.OneWay,
                 propertyChanged: OnTextChangedButton2Text
            );

        public string Button1Text
        {
            get { return (string)GetValue(Button1stringProperty); }
            set { SetValue(Button1stringProperty, value); }
        }

        public string Button2Text
        {
            get { return (string)GetValue(Button2stringProperty); }
            set { SetValue(Button2stringProperty, value); }
        }

        private static void OnTextChangedButton1Text(BindableObject bindable, object oldValue, object newValue)
        {
            var radioGrid = (MyXamarinTwoOptionRadioButton)bindable;
            radioGrid.Button1.Text = (string)newValue;
        }

        private static void OnTextChangedButton2Text(BindableObject bindable, object oldValue, object newValue)
        {
            var radioGrid = (MyXamarinTwoOptionRadioButton)bindable;
            radioGrid.Button2.Text = (string)newValue;
        }

        private void MyXamarinRadioButton_Clicked(object sender, EventArgs e)
        {
            MyXamarinButton clickedButton = (MyXamarinButton)sender;

            if (clickedButton.IsClicked) return;

            if ((this.Button1.IsClicked == false) && (this.Button2.IsClicked == false))
            {
                clickedButton.MyXamarinButton_Clicked();
            }
            else
            {
                this.Button1.MyXamarinButton_Clicked();
                this.Button2.MyXamarinButton_Clicked();
            }
        }
    }

    public class MyXamarinEntry : Entry
    {
        public MyXamarinEntry()
        {
            this.BackgroundColor = Color.LightBlue;
            this.HorizontalTextAlignment = TextAlignment.Center;
            this.VerticalOptions = LayoutOptions.Center;
            this.HorizontalOptions = LayoutOptions.FillAndExpand;
        }
    }

    
}
