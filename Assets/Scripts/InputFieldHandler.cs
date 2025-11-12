// 11.11.2025 AI-Tag
// This was created with the help of Assistant, a Unity Artificial Intelligence product.

using UnityEngine;
using TMPro;

public class InputFieldHandler : MonoBehaviour
{
    // Reference to the TMP InputField
    public TMP_InputField inputField;

    


    // Start is called before the first frame update
    void Start()
    {
        // Optional: Add a listener to detect when the text changes
        inputField.onValueChanged.AddListener(OnTextChanged);

        // Optional: Add a listener to detect when the user submits the input
        inputField.onEndEdit.AddListener(OnTextSubmitted);
    }

    // Method called when the text in the InputField changes
    private void OnTextChanged(string newText)
    {
        Debug.Log("Text changed: " + newText);
    }

    // Method called when the user submits the input (e.g., presses Enter)
    private void OnTextSubmitted(string submittedText)
    {
        Debug.Log("Text submitted: " + submittedText); // You can process the submitted text here
        MainDataManager.Instance.PlayerName = submittedText; // Store the player name in MainDataManager

    }

    // Example method to get the current text from the InputField
    public void GetInputText()
    {
        string currentText = inputField.text;
        Debug.Log("Current InputField text: " + currentText);
    }

    // Example method to set text in the InputField
    public void SetInputText(string newText)
    {
        inputField.text = newText;
    }
}