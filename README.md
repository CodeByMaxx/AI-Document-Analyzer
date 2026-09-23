# GStreamer Sync Overlay

A C++17 example demonstrating how to synchronize video frames with independently generated detection results using **GStreamer timestamps**.

The project simulates a camera stream and an AI detection pipeline. Detection results are matched to video frames based on their Presentation Timestamps (PTS) and rendered as bounding boxes using GStreamer's `cairooverlay`.

## Features

* Simulated camera producing RGB video frames
* GStreamer `appsrc` pipeline
* 30 FPS video stream at 640×480
* Presentation Timestamp (PTS) handling
* Independent detection thread
* Timestamp-based detection matching
* Configurable timestamp tolerance
* Bounding-box rendering with `cairooverlay`
* Unit tests for synchronization logic

## Pipeline

```text
DummyCamera
     |
     | RGB frames + PTS
     v
   appsrc
     |
     v
 videoconvert
     |
     v
cairooverlay <---- Detection results
     |
     v
 videoconvert
     |
     v
autovideosink
```

The camera and detection pipeline operate independently. The overlay uses timestamps to find the detection result that best matches the current video frame.

## How Synchronization Works

Each video frame receives a **Presentation Timestamp (PTS)** when it is generated.

For example:

```text
Frame 1 -> PTS = 1000 ms
Frame 2 -> PTS = 1033 ms
Frame 3 -> PTS = 1066 ms
```

The detection thread also assigns timestamps to its results:

```text
Detection 1 -> PTS = 1015 ms
Detection 2 -> PTS = 1062 ms
Detection 3 -> PTS = 1098 ms
```

When `cairooverlay` processes a video frame, the implementation searches for the detection with the closest timestamp.

For a frame at `1066 ms`:

```text
Current frame:      1066 ms

Available detections:
1015 ms
1062 ms  <-- selected
1098 ms
```

If the timestamp difference is within the configured tolerance, the corresponding bounding boxes are rendered. The current implementation uses a tolerance of **200 ms**.

This approach demonstrates how video and asynchronous inference results can remain synchronized even when the detection process introduces variable latency.

## Components

### DummyCamera

`DummyCamera` simulates a camera source.

It:

* Generates 640×480 RGB frames
* Produces frames at 30 FPS
* Assigns Presentation Timestamps
* Pushes frames to the video source

### VideoSource

`VideoSource` manages the GStreamer pipeline.

Its responsibilities include:

* Creating the GStreamer elements
* Connecting the pipeline
* Pushing frames through `appsrc`
* Preserving frame timestamps

### Overlay

The overlay uses GStreamer's `cairooverlay`.

It:

* Stores detection results
* Compares detection timestamps with video-frame timestamps
* Selects the closest matching detection
* Draws the corresponding bounding boxes

## Requirements

* C++17
* CMake 3.16 or newer
* GStreamer 1.0
* GStreamer Base Plugins
* Cairo
* GoogleTest

## Install Dependencies

On Ubuntu:

```bash
sudo apt update

sudo apt install \
    build-essential \
    cmake \
    libgstreamer1.0-dev \
    libgstreamer-plugins-base1.0-dev \
    libcairo2-dev \
    libgtest-dev
```

## Build

Clone the repository:

```bash
git clone https://github.com/CodeByMaxx/gstreamer-sync.git
cd gstreamer-sync
```

Create a build directory:

```bash
mkdir build
cd build
```

Configure and build:

```bash
cmake ..
cmake --build . -j$(nproc)
```

## Run

After building, start the application with:

```bash
./overlay
```

A video window should open displaying the generated frames together with synchronized bounding boxes.

## Tests

Run the unit tests from the build directory:

```bash
ctest --verbose
```

The current test suite covers:

* Detection timestamp matching
* Detection timeout handling
* Selection of the closest detection

## Project Structure

```text
gstreamer-sync/
├── src/
│   ├── main.cpp
│   ├── VideoSource.hpp
│   ├── Overlay.hpp
│   └── DummyCamera.hpp
│
├── tests/
│   └── OverlayTest.cpp
│
├── CMakeLists.txt
├── Picture1.png
├── Picture2.png
├── Picture3.png
├── Picture4.png
└── README.md
```

The repository currently contains four image files that can be used to document the project visually.

## Example

The core idea of the project can be summarized as:

```text
Camera frames
     |
     | PTS
     v
  GStreamer
     |
     |-------------------|
     |                   |
     v                   v
 Video frame       Detection result
     |                   |
     |       timestamp   |
     |<------------------|
     |
     v
 Timestamp matching
     |
     v
 Bounding box overlay
```

The important part is that the detection result does not need to arrive at exactly the same time as the corresponding video frame. Instead, both streams are associated using timestamps.

## Goal

The project provides a small and focused example for building real-time video pipelines where camera frames and asynchronous AI inference results need to be synchronized.

The same synchronization concept can be applied to real camera streams and external object-detection or machine-learning pipelines.

## Screenshots

The repository contains four example images:

![GStreamer Sync](Picture1.png)

![GStreamer Sync](Picture2.png)

![GStreamer Sync](Picture3.png)

![GStreamer Sync](Picture4.png)

## License

No license file is currently visible in the repository root. If this project is intended to be distributed as open-source software, an appropriate `LICENSE` file should be added.

