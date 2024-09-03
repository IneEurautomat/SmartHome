let mediaRecorder;
let recordedChunks = [];
let isRecording = false;

function startRecording() {
    const videoElement = document.getElementById('securityFeed');

    if (!navigator.mediaDevices || !navigator.mediaDevices.getUserMedia) {
        console.error('MediaDevices API not supported.');
        return;
    }

    navigator.mediaDevices.getUserMedia({ video: true, audio: false })
        .then(stream => {
            mediaRecorder = new MediaRecorder(stream);

            mediaRecorder.ondataavailable = function (event) {
                if (event.data.size > 0) {
                    recordedChunks.push(event.data);
                }
            };

            mediaRecorder.onstop = function () {
                const blob = new Blob(recordedChunks, { type: 'video/webm' });
                recordedChunks = [];

                const videoURL = URL.createObjectURL(blob);
                const container = document.getElementById('recordingsContainer');
                const videoElement = document.createElement('video');

                videoElement.controls = true;
                videoElement.src = videoURL;
                container.appendChild(videoElement);

                videoElement.play();
            };

            mediaRecorder.start();
            isRecording = true;
            console.log('Recording started.');
        })
        .catch(error => {
            console.error('Error accessing media devices.', error);
        });
}

function stopRecording() {
    if (isRecording && mediaRecorder) {
        mediaRecorder.stop();
        isRecording = false;
        console.log('Recording stopped.');
    }
}
