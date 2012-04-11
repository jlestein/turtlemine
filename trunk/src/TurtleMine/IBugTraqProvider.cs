using System;
using System.Runtime.InteropServices;

namespace Interop.BugTraqProvider
{
	/// <summary>
	/// Provides the BugTraq interface
	/// </summary>
	[ComImport, InterfaceType(ComInterfaceType.InterfaceIsIUnknown), Guid("298B927C-7220-423C-B7B4-6E241F00CD93")]
	internal interface IBugTraqProvider
	{
		/// <summary>
		/// Validates the parameters.
		/// </summary>
		/// <param name="hParentWnd">Parent window for any UI that needs to be displayed during validation.</param>
		/// <param name="parameters">The parameter string that needs to be validated.</param>
		/// <returns>Is the string valid?</returns>
		[return: MarshalAs(UnmanagedType.VariantBool)]
		bool ValidateParameters(IntPtr hParentWnd,
								[MarshalAs(UnmanagedType.BStr)] string parameters);

		/// <summary>
		/// Gets the link text.
		/// </summary>
		/// <param name="hParentWnd">Parent window for any (error) UI that needs to be displayed.</param>
		/// <param name="parameters">The parameter string, just in case you need to talk to your web service (e.g.) to find out what the correct text is.</param>
		/// <returns>What text do you want to display? Use the current thread locale.</returns>
		[return: MarshalAs(UnmanagedType.BStr)]
		string GetLinkText(IntPtr hParentWnd,
						   [MarshalAs(UnmanagedType.BStr)] string parameters);

		/// <summary>
		/// Gets the commit message.
		/// </summary>
		/// <param name="hParentWnd">Parent window for your provider's UI.</param>
		/// <param name="parameters">Parameters for your provider.</param>
		/// <param name="commonRoot">The common root.</param>
		/// <param name="pathList">The path list.</param>
		/// <param name="originalMessage">The text already present in the commit message. Your provider should include this text in the new message, where appropriate.</param>
		/// <returns>The new text for the commit message. This replaces the original message.</returns>
		[return: MarshalAs(UnmanagedType.BStr)]
		string GetCommitMessage(IntPtr hParentWnd,
								[MarshalAs(UnmanagedType.BStr)] string parameters,
								[MarshalAs(UnmanagedType.BStr)] string commonRoot,
			[MarshalAs(UnmanagedType.SafeArray, SafeArraySubType = VarEnum.VT_BSTR)] string[] pathList,
								[MarshalAs(UnmanagedType.BStr)] string originalMessage);
	}
}
