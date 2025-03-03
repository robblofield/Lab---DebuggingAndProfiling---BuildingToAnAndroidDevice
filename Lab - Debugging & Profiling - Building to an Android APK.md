# Lab - Debugging & Profiling - Building to an Android APK
*In this lab we will build a simple project to an Android APK so that it can be tested on a target device for debugging and profiling.*

![Screenshot from lab game](image-1.png)

### Core Concept: Keystore
The keystore process in Android development is crucial for signing your application. When you build an Android app, it needs to be signed with a cryptographic signature before it can be installed and run on a device. The signature serves multiple purposes, including:

1. **App Authentication**: The signature verifies the identity of the app's developer. Users can be confident that the app they're installing is from the developer they trust.

2. **Integrity Check**: The signature ensures that the app hasn't been altered or tampered with since it was signed. If someone modifies the APK after signing, the signature becomes invalid, alerting users and Android's security mechanisms.

3. **App Updates**: If you release updates to your app, they must be signed with the same key as the original version. This ensures that users can seamlessly update their apps without losing app data or encountering conflicts.

Here's a breakdown of the keystore process:

### Keystore Manager:
When you generate a new keystore using Unity's Keystore Manager or any other tool, you're essentially creating a digital certificate. This certificate contains:

- **Private Key**: A secret key used for signing your app. It should be kept secure and private.
  
- **Public Key**: A corresponding public key is included in the certificate and can be freely distributed.

- **Certificate Information**: Details about the certificate issuer (you), expiration date, and other metadata.

### Key Alias and Password:
- **Alias**: When you create a keystore, you provide an alias (name) for the key. This alias helps you manage multiple keys within a single keystore if needed.
  
- **Password**: You also set a password to protect the keystore file. This password is used to access the private key and ensure its security.

### Signing Your App:
When you build your Android app in Unity, you specify the keystore file and the alias of the key to use for signing. Unity then signs the APK with the private key from the keystore.

### Importance of Keeping the Keystore Secure:
- Losing the keystore or forgetting the password can be catastrophic. Without the original keystore, you can't update your app on the Play Store. Users would have to uninstall the old version and install the new one, resulting in data loss.
  
- It's recommended to back up the keystore file and password in a secure location. Additionally, consider using version control systems or password managers to safeguard this sensitive information.

In summary, the keystore process ensures the authenticity, integrity, and continuity of your Android app. It's a critical aspect of Android development, particularly when distributing apps through official channels like the Google Play Store.

### Additional Notes & Documentation
For this lab a sample project has been provided, which includes a basic constant runner player controller and a UI joystick for controlling movement when playing on mobile. Please download the project from GitHub:
* [Example Project - GitHub](https://github.com/robblofield/Lab---DebuggingAndProfiling---BuildingToAnAndroidDevice.git)

This lab works through the same methods displayed in this video, take a look at it if you are unable to work through the printed instructions:
* [Samyam - YouTube - How to EASILY Build to an Android Phone in Unity](https://www.youtube.com/watch?v=Nb62z3J4A_A)

**Documentation:**
* [Unity Docs - Android Build Process](https://docs.unity3d.com/Manual/android-BuildProcess.html)
  

## Section 1 - Build to an Android APK
### Preparing Your Unity Environment:
1. **Install Required Modules:**
   - Open Unity Hub.
   - Navigate to the "Installs" section.
   - Locate your Unity version and click on the three dots.
   - Select "Add Modules."
   - Install the following:
     - Android Build Support
     - Android SDK NDK
     - Open JDK Tools
   - Close and reopen Unity Editor to apply changes.

2. **Verify External Tools Paths:**
   - Go to "Edit" -> "Preferences."
   - Under "External Tools," ensure the following paths are updated:
     - JDK
     - SDK
     - NDK
   - If not updated, there might be an issue with installation.

### Setting Up Your Android Device:
3. **Enable Developer Mode on Your Device:**
   - Navigate to your device's "Settings."
   - Scroll down and select "General" or "About Phone."
   - Tap on "Software Info."
   - Find "Build Number" and tap on it seven times to enable Developer Mode.
   - Once enabled, Developer Options will appear in the Settings menu.
   - Enable "USB Debugging Mode" within Developer Options.
   - Optionally, enable "Stay Awake" to prevent the screen from turning off while charging.

4. **Connect Your Device to Your Computer:**
   - Use a USB cable to connect your Android device to your computer.
   - If prompted on your device, allow the computer to send information.

### Configuring Player Settings in Unity:
5. **Configure Player Settings:**
   - Go to "File" -> "Build Settings."
   - Ensure your scene is added.
   - Switch the platform to Android.
   - Check "Development Build".
   - Configure other settings in "Player Settings":
     - Company Name
     - Product Name
     - Version
     - Icon
     - Orientation
     - Splash Image
     - Package Name
     - API Levels
*N.B - For development, using the minimum API level means you can test on a wider range of devices, but you should check the documentation for the Google Play store to check current guidelines on the minimum API for new apps for when you want to build and publish your game*

1. **Create a Keystore:**
   - Under "Player Settings," scroll down to "Publishing Settings."
   - Click on "Keystore Manager."
   - Create a new key and set a password.
   - Enter additional information like your name, organization, etc.
   - Save the key and keep it safe
   - Uncheck "Custom Keystore" from the publishing settings
*N.B - For further notes on the Keystore process check the core concept at the beginning of these lab notes. Note that because we are using development build. We have setup the Keystore here for best practices, but because we are signing the application as a development build, it wont actually be using the keystore key to identify and run the program*

### Building Your APK:
7. **Build and Run:**
   - Ensure your Android device is detected in Unity's build settings.
   - Select "Build and Run."
   - Choose a location to save your APK.
   - If prompted on your device, select "Photo Transfer" mode.
   - If prompted, authorize your computer to build to the phone.
   - Monitor the console for any errors.
   - Once completed, your APK should be installed on your device.

8. **Troubleshooting:**
   - If errors occur, check the console for details.
   - Ensure correct API levels and key settings.
   - Verify USB debugging and device connectivity.

### Task - Add some further functionality and test
Decide on some functionality to add to the game:
* Obstacles
* Jump
* Dash
* SlowMo 
Once it is functioning in the editor, build to the android phone again and test, you can also open the profiler and set it to readback the performance from the phone to see how the game is running on the target hardware.
