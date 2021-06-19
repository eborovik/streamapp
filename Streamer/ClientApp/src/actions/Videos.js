import axios from 'axios';

const BASE_URL = 'http://localhost:7000'

export function addLiveVideo(data) {
    return dispatch => {
        return axios.post(`${BASE_URL}/api/livevideo/add`, data);
    }
}

export function getLiveVideos() {
    return dispatch => {
        return axios.get(`${BASE_URL}/api/livevideo/getall`);
    }
}

export function getSavedVideos(streamId) {
    return dispatch => {
        return axios.get(`${BASE_URL}/api/savedvideo/getall/${streamId}`);
    }
}

export function startRecording(streamId) {
    console.log("start recording")
    axios.get(`${BASE_URL}/api/livevideo/record/${streamId}`);
    
}

export function stopRecording(streamId) {
    return axios.get(`${BASE_URL}/api/livevideo/stoprecord/${streamId}`);
}

export function deleteStream(streamId) {
    return axios.delete(`${BASE_URL}/api/livevideo/${streamId}`);
}