using UnityEngine;

namespace SAD
{
    /// <summary>
    /// Adjusts the UI elements to fit within the device's safe area, accounting for notches or rounded corners on modern devices.
    /// </summary>
    public class SafeAreaDetector : MonoBehaviour
    {
        [Header("Safe Area Y-Offset")]
        public float _maxYAnchorOffset = 0.02f; // Maximum Y offset adjustment for devices with notches

        private RectTransform _rectTransform; // Cached RectTransform of the UI element
        private Rect _safeArea; // Device's safe area rect
        private Vector2 _minAnchor; // Minimum anchor point of the UI element
        private Vector2 _maxAnchor; // Maximum anchor point of the UI element
        private bool _hasNotch = true; // Flag to check if the device has a notch

        private void Awake()
        {
            // Initialize the safe area adjustment when the script is loaded
            SetDataForDeviceSafeArea();
        }

        /// <summary>
        /// Sets the UI to match the device's safe area dimensions.
        /// </summary>
        private void SetDataForDeviceSafeArea()
        {
            GetRefrences(); // Fetch safe area and RectTransform references
            GetMinandMaxAnchors(); // Calculate min and max anchor points
            GetMinimumAnchorsOfDevice(); // Adjust for devices with notches
            SetMinimumAnchors(); // Apply the anchor settings to the RectTransform
        }

        /// <summary>
        /// Gets references to the RectTransform and the device's safe area.
        /// </summary>
        private void GetRefrences()
        {
            _rectTransform = GetComponent<RectTransform>(); // Cache the RectTransform
            _safeArea = Screen.safeArea; // Get the device's safe area

            // Convert safe area position and size to normalized anchor values
            _minAnchor = _safeArea.position;
            _maxAnchor = _minAnchor + _safeArea.size;

            _minAnchor.x /= Screen.width;
            _minAnchor.y /= Screen.height;
        }

        /// <summary>
        /// Calculates the normalized maximum anchor points and determines if the device has a notch.
        /// </summary>
        private void GetMinandMaxAnchors()
        {
            if (_maxAnchor.x == Screen.width && _maxAnchor.y == Screen.height)
            {
                _hasNotch = false; // Device does not have a notch
            }

            _maxAnchor.x /= Screen.width;
            _maxAnchor.y /= Screen.height;
        }

        /// <summary>
        /// Adjusts the anchors for devices with notches.
        /// </summary>
        private void GetMinimumAnchorsOfDevice()
        {
            if (_hasNotch)
            {
                // Adjust the max anchor for Y offset
                _maxAnchor = _maxAnchor + new Vector2(0, _maxYAnchorOffset);

#if UNITY_IPHONE
                // Further adjustments for iOS devices
                _minAnchor = _minAnchor - new Vector2(_minAnchor.x, _maxYAnchorOffset);
#endif
            }
        }

        /// <summary>
        /// Applies the calculated anchor points to the RectTransform.
        /// </summary>
        private void SetMinimumAnchors()
        {
            _rectTransform.anchorMax = _maxAnchor;
            _rectTransform.anchorMin = _minAnchor;
        }
    }
}
