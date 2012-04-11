using System;
using System.Threading;
using System.Windows.Forms;

namespace TurtleMine.Controls
{
	/// <summary>
	/// Provide Template Control
	/// </summary>
	public partial class Template : UserControl
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="Template"/> class.
		/// </summary>
		public Template()
		{
			Thread.CurrentThread.CurrentUICulture = Thread.CurrentThread.CurrentCulture;
			InitializeComponent();

			//Determine which header to show
			if (ProjectInfo.IsNull())
			{
				//Global Settings
				lblHeading.Visible = true;
				rdoGlobalSettings.Visible = false;
				rdoCustomSettings.Visible = false;
			}
			else
			{
				//Per project Settings
				lblHeading.Visible = false;
				rdoGlobalSettings.Visible = true;
				rdoCustomSettings.Visible = true;
			}
		}

		/// <summary>
		/// Handles the CheckedChanged event of the rdoGlobalSettings control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
		public void rdoGlobalSettings_CheckedChanged(object sender, EventArgs e)
		{
			if (rdoGlobalSettings.Visible)
			{
				pnlSettings.Enabled = false;
			}
		}

		/// <summary>
		/// Handles the CheckedChanged event of the rdoCustomSettings control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
		public void rdoCustomSettings_CheckedChanged(object sender, EventArgs e)
		{
				pnlSettings.Enabled = true;
		}

		/// <summary>
		/// Handles the Load event of the Template control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
		public void Template_Load(object sender, EventArgs e)
		{
			if (!ProjectInfo.IsEmpty()) return;

			//Default to global settings
			if (rdoGlobalSettings.Visible)
			{
				rdoGlobalSettings.Checked = true;
			}
		}

		/// <summary>
		/// Method to override in inherting control to Apply Settings to the Settings Manager for the current Control
		/// </summary>
		public virtual void ApplyChanges() {}

		/// <summary>
		/// Gets the settings.
		/// </summary>
		internal virtual void getSettings() {}

		/// <summary>
		/// Gets or sets a value indicating whether [property changed].
		/// </summary>
		/// <value><c>true</c> if [property changed]; otherwise, <c>false</c>.</value>
		private bool _propertyChanged;
		public bool PropertyChanged
		{
			get { return _propertyChanged; }
			set 
			{
				_propertyChanged = value;

				try
				{
					if (ParentForm != null)
					{
						//The Config Utility Apply Button
						if (ParentForm.Controls["splitContainer1"] != null)
						{
							var btnApply = ParentForm.Controls["splitContainer1"].Controls[1].Controls["pnlButtons"].Controls["btnApply"];
							if (btnApply != null)
							{
								btnApply.Enabled = _propertyChanged;
							}
						}
						else
						{
							//Apply button righ ton the form
							var btnApply = ParentForm.Controls["btnApply"];
							if (btnApply != null)
							{
								btnApply.Enabled = _propertyChanged;
							}
						}
					}
				}
				catch
				{
					//If failed to find the Apply button then do not crash.
				}
			}
		}
	}
}
