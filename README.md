# Cardboard Demo Audio Visualizer
A very basic VR demo in Unity using Google's Cardboard SDK. This project accepts an input audio file (preferably a 48kHz Stereo MP3) and displays a 3D visualization of the music based on a live audio analysis of the frequency amplitudes. 

Setup
----
* Open either the MultiStadium or SingleStadium scene in Unity
* Press Ctrl+P (⌘ + P) to play in the editor. Alt can be used to move the stereoscopic camera in the editor
* Press Ctrl + Shift + B (⌘ + Shift + B) to open the build dialog and switch the selected platform to Android. If you have an Android device already connected through ADB for debugging, simply press "Build and Run" to compile and deploy on the spot! This project can also be compiled to an Android Studio project and deployed there if needed.
