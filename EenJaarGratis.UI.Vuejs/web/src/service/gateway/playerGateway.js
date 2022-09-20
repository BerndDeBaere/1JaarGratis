import axios from 'axios';

const api_root = process.env.VUE_APP_TITLE;
export default {
    async get() {

        try {
            let response = await axios.get(api_root + "/Player");
            return response.data;
        } catch (err) {
            console.error(err.response.data);
            return [];
        }
    },
    async delete(player) {
        try {
            await axios.delete(api_root + "/Player/" + {...player}.id);
        } catch (err) {
            console.error(err.response.data);
            return [];
        }
    },
    async post(player) {
        try {
            await axios.post(api_root + "/Player", player);
        } catch (err) {
            console.error(err.response.data);
            return [];
        }
    },
    async put(player) {
        try {
            await axios.put(api_root + "/Player", player);
        } catch (err) {
            console.error(err.response.data);
            return [];
        }
    },
    async getScoreboard(){
        try {
            let response = await axios.get(api_root + "/Player/Scoreboard");
            return response.data;
        } catch (err) {
            console.error(err.response.data);
            return [];
        }
    }
}