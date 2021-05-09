import axios from 'axios';
import jwtDecode from 'jwt-decode';

const BASE_URL = 'https://localhost:5001'

export function addLiveVideo(data) {
    return dispatch => {
        return axios.post(`${BASE_URL}/api/livevideo/add`, data);
    }
}