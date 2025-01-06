
# Safe Area Detector

The Safe Area Detector is a lightweight Unity script designed to automatically adjust UI elements to fit within the safe area of modern devices, accounting for notches or rounded corners. This ensures your UI appears correctly on all devices, enhancing user experience.

## Features
- **Dynamic Safe Area Adjustment**: Automatically adjusts UI elements to fit the device's safe area.
- **Offset Support**: Customize the Y-offset to allow fine-tuning of the safe area adjustments.
- **Flexible Runtime Options**: Supports adjustment at runtime for editor testing and resolution changes.
- **Platform-Specific Adjustments**: Includes additional handling for iOS devices.

---

## How to Use

### Step 1: Add the Script to Your Project
1. Include the `SafeAreaDetector` script in your Unity project.

### Step 2: Attach the Script
1. Select the UI GameObject (e.g., Canvas or specific UI element) you want to adjust according to the safe area.
2. Attach the `SafeAreaDetector` script as a component to the selected GameObject.

### Step 3: Configure the Script
- **_Max Y Anchor Offset**
  - This value allows you to apply a vertical offset adjustment to the safe area.
  - Default: `0.02` (adjust as needed based on your design requirements).

- **_Should Use in Awake**
  - When enabled, the script will adjust the UI immediately when the GameObject is loaded.
  - Useful for ensuring the UI is correctly positioned on startup.

- **_Should Adjust on Spacebar Pressed**
  - When enabled, pressing the spacebar will reapply the safe area adjustments.
  - Ideal for testing in the Unity Editor when changing screen resolutions at runtime.

### Step 4: Test and Adjust
1. Run your project and verify that the UI adjusts correctly within the safe area on devices with notches or rounded corners.
2. Use the inspector to tweak the values for your specific needs.

---

## Additional Notes
- This script works best with UI elements that use **RectTransform** components.
- For iOS devices, the script includes additional offset adjustments to ensure compatibility with the platform's unique safe area requirements.
- Testing on multiple devices is recommended to ensure the UI appears as expected across all screen sizes and aspect ratios.

---

## Troubleshooting
- **UI Not Adjusting Correctly:**
  - Ensure the `SafeAreaDetector` script is attached to the correct GameObject.
  - Verify that the GameObject has a **RectTransform** component.

- **Spacebar Adjustment Not Working:**
  - Check if `_Should Adjust on Spacebar Pressed` is enabled in the inspector.
  - Ensure the GameObject is active in the scene during runtime.

---

## Example Use Cases
- Adjusting the Canvas to fit within the safe area on iPhones with notches.
- Dynamically resizing UI elements during resolution changes in the Unity Editor.
- Fine-tuning the position of specific UI panels or buttons to avoid overlap with system UI elements.

---

Thank you for using the Safe Area Detector! For further support or feedback, feel free to reach out.
