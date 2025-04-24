# Pose-Based Visualizer in Unity

A lightweight system that uses MediaPipe (BlazePose) and Unity to visualize human pose in real time.

## How it works

- Python script (`pose_sender.py`) uses MediaPipe to detect pose landmarks from webcam.
- Joint positions are sent via UDP to Unity.
- Unity renders 33 joint spheres and connects them with lines using LineRenderer.
- Optional: live movement can drive object behavior (e.g., raise hand to move cubes).

## Setup Instructions

### 1. Clone the Repo

```bash
git clone https://github.com/JRKagumba/pose-unity-visualizer.git
cd pose-unity-visualizer
```

### 2. Create & Activate Python Virtual Environment

```bash
python -m venv venv
# On Windows:
venv\Scripts\activate
# On Mac/Linux:
source venv/bin/activate
```

### 3. Install Dependencies

```bash
pip install -r requirements.txt
```

### 4. Open Unity Project

Launch Unity and open the project. Navigate to:
`Assets/Scenes/PoseVisualizerScene.unity`

### 5. Run the App

- Start `pose_sender.py` to begin streaming pose data.
- Click Play in Unity.
- Watch the 33-point skeleton animate.
- Optionally move your hands to control cubes in the scene.

## Project Structure

```
Assets/
├── Prefabs/             # Sphere and line prefabs for rendering joints/skeleton
├── Scripts/             # Pose parsing, rendering, interaction logic
├── Scenes/              # Unity scenes including main visualizer
pose_sender.py           # Python UDP streamer with MediaPipe BlazePose
requirements.txt         # Python dependencies
```

## Features

- 33-point full body tracking
- Real-time UDP communication between Python and Unity
- Pose-based interaction with scene objects (e.g., cubes)
- Easy to extend and prototype pose-based mechanics

## Future Ideas

- Animate humanoid avatars using inverse kinematics (IK)
- Add UI overlays to track specific joints
- Record and replay poses
- WebGL export for browser demo

## Author

Joe Kagumba  
GitHub: https://github.com/JRKagumba
