import axios from 'axios';
import jwtDecode from 'jwt-decode';

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