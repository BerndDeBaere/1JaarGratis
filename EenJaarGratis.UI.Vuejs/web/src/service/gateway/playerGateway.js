import axios from 'axios';

const api_root = process.env.VUE_APP_TITLE;
export default {
    async get(){
        return (await axios.get(api_root + "/Player")).data}
}