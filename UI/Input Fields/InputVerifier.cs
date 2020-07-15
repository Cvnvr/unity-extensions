using UnityEngine;
using System.Text.RegularExpressions;
using TMPro;

/* *****************************************************************************
 * File: InputVerifier.cs
 * Author: Conor Galvin - 15/07/2020
 * Description:
 *  Unity extension to replace the input of an input field using regex.
 *
 * History:
 *  15/07/2020 - Created
 * ****************************************************************************/

public class InputVerifier : MonoBehaviour
{
	#region Variables
	private TMP_InputField inputField;

	// Edit this field to specify unwanted characters
	private Regex regex = new Regex("['\"/]");
	#endregion Variables

	#region Initialisation
	private void Awake()
	{
		inputField = GetComponent<TMP_InputField>();
	}
	#endregion Initialisation

	/// <summary>
	///    Removes unwanted characters from the input and replaces the input field text.
	/// </summary>
	/// <param name="input"> </param>
	public void VerifyInput(string input)
	{
		if (inputField == null) return;

		input = regex.Replace(input, string.Empty);
		inputField.text = input;
	}
}