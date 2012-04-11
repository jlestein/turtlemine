using System;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace TurtleMine
{
	public partial class ErrorDialog : Form
	{
		#region Constructors

		public ErrorDialog()
		{
			InitializeComponent();
		}

		/// <summary>
		/// Determine which buttons to show.
		/// </summary>
		public enum ButtonState
		{
			/// <summary>
			/// 
			/// </summary>
			CloseContinue,
			/// <summary>
			/// 
			/// </summary>
			OkCancel,
			/// <summary>
			/// 
			/// </summary>
			OkOnly
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="ErrorDialog"/> class.
		/// </summary>
		/// <param name="title">The title.</param>
		/// <param name="message">The message.</param>
		/// <param name="buttons">The buttons.</param>
		public ErrorDialog(string title, string message, ButtonState buttons) : this(title, message, null, buttons) { }

		/// <summary>
		/// Initializes a new instance of the <see cref="ErrorDialog"/> class.
		/// </summary>
		/// <param name="exception">The exception.</param>
		/// <param name="buttons">The buttons.</param>
		public ErrorDialog(Exception exception, ButtonState buttons) : this(null, null, exception, buttons) { }

		/// <summary>
		/// Initializes a new instance of the <see cref="ErrorDialog"/> class.
		/// </summary>
		/// <param name="title">The title.</param>
		/// <param name="message">The message.</param>
		/// <param name="exception">The exception.</param>
		/// <param name="buttons">The buttons.</param>
		public ErrorDialog(string title, string message, Exception exception, ButtonState buttons)
			: this()
		{
			ErrorTitle = title;
			ErrorMessage = message;
			ErrorException = exception;

			switch (buttons)
			{
				case ButtonState.CloseContinue:
					btnContinue.Visible = true;
					btnClose.Visible = true;
					btnOk.Visible = false;
					btnCancel.Visible = false;
					break;
				case ButtonState.OkCancel:
					btnContinue.Visible = false;
					btnClose.Visible = false;
					btnOk.Visible = true;
					btnCancel.Visible = true;
					break;
				case ButtonState.OkOnly:
					btnContinue.Visible = false;
					btnClose.Visible = false;
					btnOk.Visible = true;
					btnCancel.Visible = false;
					break;
			}
		}

		#endregion

		#region Properties

		/// <summary>Gets or sets the error title.</summary>
		/// <value>The error title.</value>
		public string ErrorTitle { get; set; }

		/// <summary>Gets or sets the error message.</summary>
		/// <value>The error message.</value>
		public string ErrorMessage { get; set; }

		/// <summary>Gets or sets the error exception.</summary>
		/// <value>The error exception.</value>
		public Exception ErrorException { get; set; }

		#endregion

		private void ErrorDialog_Load(object sender, EventArgs e)
		{
			Text = string.IsNullOrEmpty(ErrorTitle) ? Resources.Strings.Error : ErrorTitle;
			txtMessage.Text = ErrorMessage;

			btnDetails.Visible = (ErrorException != null);
		}

		private void btnDetails_Click(object sender, EventArgs e)
		{
			if (Size.Height == 228)
			{
				loadDetails();
				txtDetails.Visible = true;
				Size = new Size(Size.Width, 567);
			}
			else
			{
				txtDetails.Visible = false;
				Size = new Size(Size.Width, 228);
			}

			CenterToParent();
		}

		private void btnClose_Click(object sender, EventArgs e)
		{
			Close();
			Application.OpenForms[0].Close();
		}

		private void loadDetails()
		{
			//Build detailed message
			var msg = new StringBuilder();

			try
			{
				//Operating System
				msg.AppendLine(string.Format("OS: {0}", OsInfo.GetOSInfo()));
			}
			catch { /* Don't die if can't get Info */ }

			try
			{

				//Language
				msg.AppendLine(string.Format("Language: {0}", OsInfo.GetOSLanguage()));
			}
			catch { /* Don't die if can't get Info */ }

			try
			{

				//Plugin Version
				msg.AppendLine(string.Format("Plugin: {0}, Version={1}", ProductName, ProductVersion));
			}
			catch { /* Don't die if can't get Info */ }

			try
			{
				//Tortoise Version
				var tortoiseproc = System.Diagnostics.Process.GetCurrentProcess().MainModule.FileVersionInfo;
				msg.AppendLine(string.Format("Tortoise: {0}, Version={1}", tortoiseproc.ProductName, tortoiseproc.ProductVersion));
			}
			catch { /* Don't die if can't get Info */ }

			//Divider
			msg.AppendLine(string.Empty);

			//Title
			msg.AppendLine(string.Format("{0}:", Text));

			//Message
			if (!string.IsNullOrEmpty(ErrorMessage))
			{
				msg.AppendLine(ErrorMessage);
			}

			//Divider
			msg.AppendLine(string.Empty);

			//Exception to String
			if (ErrorException != null)
			{
				msg.AppendLine(ErrorException.ToString());
			}

			txtDetails.Text = msg.ToString();
		}
	}
}
