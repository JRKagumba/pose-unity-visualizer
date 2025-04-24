# Pose-Based Visualizer in Unity 🎮💻

A lightweight system that uses MediaPipe (BlazePose) + Unity to visualize human pose in real time.

## How it works

- Python script (`pose_sender.py`) uses MediaPipe to detect pose landmarks
- Joint positions are sent via UDP to Unity
- Unity renders 33 joint spheres + connecting skeleton
- Live movement can drive object behavior (e.g., raise hand to move cubes)

## Setup Instructions

1. Clone the repo
2. Create and activate a virtual environment:
