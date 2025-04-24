import cv2
import mediapipe as mp
import socket

mp_pose = mp.solutions.pose
pose = mp_pose.Pose()
cap = cv2.VideoCapture(1)

# Set up UDP socket
sock = socket.socket(socket.AF_INET, socket.SOCK_DGRAM)
UNITY_IP = "127.0.0.1"
PORT = 5005

while cap.isOpened():
    success, image = cap.read()
    if not success:
        break

    image_rgb = cv2.cvtColor(image, cv2.COLOR_BGR2RGB)
    results = pose.process(image_rgb)

    if results.pose_landmarks:
        # Flatten keypoints into a list of floats
        flat_landmarks = []
        for lm in results.pose_landmarks.landmark:
            flat_landmarks.extend([lm.x, lm.y, lm.z])

        # Convert to CSV string and send to Unity
        message = ','.join(str(v) for v in flat_landmarks)
        sock.sendto(message.encode('utf-8'), (UNITY_IP, PORT))

    cv2.imshow('Pose', image)
    if cv2.waitKey(5) & 0xFF == 27:
        break

cap.release()
sock.close()
cv2.destroyAllWindows()
