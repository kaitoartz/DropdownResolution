using UnityEngine;
using TMPro;

public class FPSSelector : MonoBehaviour
{
    public TMP_Dropdown fpsDropdown;
    public int selectedFPS;

    private void Start()
    {
        // Load saved FPS setting
        int savedFPS = PlayerPrefs.GetInt("SelectedFPS", 60); // Default to 60 FPS
        SetFPS(savedFPS);

        // Set the dropdown to the saved value
        fpsDropdown.value = GetDropdownIndexFromFPS(savedFPS);

        // Add listener for dropdown changes
        fpsDropdown.onValueChanged.AddListener(delegate {
            DropdownValueChanged(fpsDropdown);
        });
    }

    public void DropdownValueChanged(TMP_Dropdown change)
    {
        selectedFPS = GetFPSFromDropdownIndex(change.value);
    }

    public void ApplyFPSSetting()
    {
        SetFPS(selectedFPS);
    }

    public void SetFPS(int fps)
    {
        if (fps == 0)
        {
            Application.targetFrameRate = -1; // Unlock FPS
        }
        else
        {
            Application.targetFrameRate = fps;
        }
    }

    public int GetFPSFromDropdownIndex(int index)
    {
        switch (index)
        {
            case 0: return 30;
            case 1: return 60;
            case 2: return 120;
            case 3: return 0; // Unlock FPS
            default: return 60;
        }
    }

    public int GetDropdownIndexFromFPS(int fps)
    {
        switch (fps)
        {
            case 30: return 0;
            case 60: return 1;
            case 120: return 2;
            case 0: return 3; // Unlock FPS
            default: return 1; // Default to 60 FPS
        }
    }
}