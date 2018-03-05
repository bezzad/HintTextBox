using System;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Drawing;
using System.Globalization;
using System.Numerics;
using System.Windows.Forms;

namespace Windows.Forms
{
    [ProvideProperty("HintTextBox", typeof(Control))]
    public sealed class HintTextBox : TextBox
    {
        #region Members

        private readonly MathParser _mathParser = new MathParser();

        [Browsable(true), EditorBrowsable(EditorBrowsableState.Always)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [Description("Hint text, when text box is empty this value be superseded."), Category("Appearance")]
        [Localizable(true)]
        [Editor(typeof(MultilineStringEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public string HintValue
        {
            set
            {
                _hintValue = value;
                Text = value;
                ForeColor = HintColor;
            }
            get => _hintValue;
        }
        private string _hintValue;


        [Browsable(true), EditorBrowsable(EditorBrowsableState.Always)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [Description("Hint value text's fore color."), Category("Appearance")]
        public Color HintColor
        {
            set
            {
                if (ForeColor == _hintColor || Text == string.Empty || Text == HintValue)
                {
                    ForeColor = value;
                }
                _hintColor = value;
            }
            get => _hintColor;
        }
        private Color _hintColor;


        [Browsable(true), EditorBrowsable(EditorBrowsableState.Always)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [Description("Main text's fore color."), Category("Appearance")]
        public Color TextForeColor { get; set; }

        [Browsable(true), EditorBrowsable(EditorBrowsableState.Always)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [Description("Is Numerical TextBox? if value is true then just typed numbers, and if false then typed any chars."), Category("Behavior")]
        [DefaultValue(false)]
        public bool IsNumerical
        {
            get => _isNumerical;
            set
            {
                _isNumerical = value;

                if (!value)
                {
                    ThousandsSeparator = false;
                    AcceptMathChars = false;
                }
            }
        }
        private bool _isNumerical;

        [Browsable(true), EditorBrowsable(EditorBrowsableState.Always)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [Description("Show Thousands Separator in TextBox? if value is true then split any 3 numerical digits by char ',' .\n\rNote: IsNumerical must be 'true' for runes this behavior."), Category("Behavior")]
        [DisplayName("Thousands Separator"), DefaultValue(false)]
        public bool ThousandsSeparator
        {
            get => _thousandsSeparator;
            set
            {
                _thousandsSeparator = value;
                if (value)
                {
                    IsNumerical = true;
                    AcceptMathChars = false;
                }
            }
        }
        private bool _thousandsSeparator;

        [Browsable(true), EditorBrowsable(EditorBrowsableState.Always)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [Description("Convert Enter key press to TAB and focus next controls."), Category("Behavior")]
        [DisplayName("Enter key To Tab")]
        public bool EnterToTab { get; set; }



        [Browsable(true), EditorBrowsable(EditorBrowsableState.Always)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [Description("Accepting mathematical operators such as + , - , * and /"), Category("Behavior")]
        [DefaultValue(false)]
        public bool AcceptMathChars
        {
            get => _acceptMathChars;
            set
            {
                _acceptMathChars = value;
                if (value)
                {
                    IsNumerical = true;
                    ThousandsSeparator = false;
                }
            }
        }
        private bool _acceptMathChars;

        public string MathParserResult { get; private set; }

        [Browsable(true), EditorBrowsable(EditorBrowsableState.Always)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [Description("The real text of text box"), Category("Appearance")]
        [Localizable(true)]
        [Editor(typeof(MultilineStringEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public string Value
        {
            get => (_hintValue != null && Text == HintValue) ? string.Empty : Text;
            set
            {
                if (value != string.Empty && value != HintValue)
                    ForeColor = TextForeColor;

                Text = value;
            }
        }

        #endregion

        #region Constructors
        public HintTextBox()
        {
            TextForeColor = Color.Black;
            HintColor = Color.Gray;
            HintValue = "Hint Value";

            HandleCreated += (s, e) => { if (string.IsNullOrEmpty(Value)) Text = HintValue; };
        }

        public HintTextBox(IContainer container)
            : this() { container.Add(this); }

        #endregion

        #region PreInitialized Events

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            //
            if (Text == HintValue)
            {
                // Clean hint text
                Text = string.Empty;
                ForeColor = TextForeColor;
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
            //
            if (Text == string.Empty)
            {
                // Set to hint text
                ForeColor = HintColor;
                Text = HintValue;
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        protected override void OnKeyUp(KeyEventArgs e)
        {
            base.OnKeyUp(e);
            //
            if (Text == string.Empty)
            {
                // Set to hint text
                ForeColor = HintColor;
                Text = HintValue;
            }

            if (ThousandsSeparator && !AcceptMathChars)
            {
                var indexSelectionBuffer = SelectionStart;
                if (!string.IsNullOrEmpty(Text) && e.KeyData != Keys.Left && e.KeyData != Keys.Right)
                {
                    BigInteger valueBefore;
                    // Parse currency value using en-GB culture. 
                    // value = "�1,097.63";
                    // Displays:  
                    //       Converted '�1,097.63' to 1097.63
                    var style = NumberStyles.Number | NumberStyles.AllowCurrencySymbol;
                    var culture = CultureInfo.CreateSpecificCulture("en-US");
                    if (BigInteger.TryParse(Text, style, culture, out valueBefore))
                    {
                        Text = String.Format(culture, "{0:N0}", valueBefore);
                        if (e.KeyData != Keys.Delete && e.KeyData != Keys.Back) Select(Text.Length, 0);
                        else Select(indexSelectionBuffer, 0);
                    }
                }
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        protected override void OnKeyDown(KeyEventArgs e)
        {
            base.OnKeyDown(e);
            //
            if (e.KeyCode == Keys.Enter && EnterToTab) SendKeys.Send("{TAB}");
            else if (Text == HintValue)
            {
                // Clean hint text
                Text = string.Empty;
                ForeColor = TextForeColor;
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        protected override void OnKeyPress(KeyPressEventArgs e)
        {
            base.OnKeyPress(e);
            //
            if (!char.IsDigit(e.KeyChar) && IsNumerical)
            {
                int charValue = e.KeyChar;
                const int backKeyCharValue = 8; // 8 or '\b'
                const int deleteKeyCharValue = 13; // 13 or '\d'

                if (charValue == backKeyCharValue || charValue == deleteKeyCharValue)
                {
                    e.Handled = false;
                    return;
                }

                if (AcceptMathChars && !ThousandsSeparator)
                {
                    if (e.KeyChar == '+' || e.KeyChar == '-' ||
                        e.KeyChar == '*' || e.KeyChar == '/' ||
                        e.KeyChar == '(' || e.KeyChar == ')')
                    {
                        e.Handled = false;
                        return;
                    }
                }

                e.Handled = true;
            }
            else
            {
                e.Handled = false;
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        protected override void OnTextChanged(EventArgs e)
        {
            base.OnTextChanged(e);
            //
            if (IsNumerical && AcceptMathChars && !string.IsNullOrEmpty(Text))
            {
                try
                {
                    MathParserResult = _mathParser.Calculate(Text).ToString(CultureInfo.InvariantCulture);
                }
                catch { MathParserResult = ""; }
            }
            else MathParserResult = "";
        }


        #endregion
        
    }
}