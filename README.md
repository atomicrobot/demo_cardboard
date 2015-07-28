# Google Cardboard Audio Visualizer
A very basic VR demo in Unity using Google's Cardboard SDK. This project accepts an input audio file (preferably a 48kHz Stereo MP3) and displays a 3D visualization of the music based on a live audio analysis of the frequency amplitudes.

<p align="center"><img title="" src="https://github.com/madebyatomicrobot/demo_cardboard/raw/master/sample.gif"/></p>

### Quick Start
* With an Android device connected, run `adb devices` from Terminal to verify that your device is connected with debug mode
* Run `adb install -r SingleStadium.apk` to install and run the basic cardboard scene. You can also run `adb install -r MultiStadium.apk` to view a scene with 4 music visualizers surrounding the camera.

###Build From Source
* Open either the MultiStadium or SingleStadium scene in Unity
* Press Ctrl+P (⌘ + P) to play in the editor. Alt handles the pitch and yaw, Ctrl handles the roll.
* Press Ctrl + Shift + B (⌘ + Shift + B) to open the build dialog and switch the selected platform to Android. If you have an Android device already connected through ADB for debugging, simply press "Build and Run" to compile and deploy on the spot! This project can also be compiled to an Android Studio project and deployed there if needed.

### Contribute
1. Fork the repository
2. Make a new branch using the gitflow model "feature/featurename"
3. Make some changes & commit
4. Make a pull request from your feature branch back to this master branch

### Sample Music
All sample tracks included are licensed under the [Creative Commons Attribution License (CC BY)](http://creativecommons.org/licenses/by/3.0/)
    
* [AuX - Stardust](https://youtu.be/LH4jsNjIq4I)
* [DOCTOR VOX - Hero](https://youtu.be/qNuC01Z3lrs)

### License
    Copyright 2015 Atomic Robot, LLC
    
    Licensed under the Apache License, Version 2.0 (the "License");
    you may not use this file except in compliance with the License.
    You may obtain a copy of the License at
    
    http://www.apache.org/licenses/LICENSE-2.0
    
    Unless required by applicable law or agreed to in writing, software
    distributed under the License is distributed on an "AS IS" BASIS,
    WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
    See the License for the specific language governing permissions and
    limitations under the License.
