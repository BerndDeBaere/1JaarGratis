import axios from 'axios';

const api_root = process.env.VUE_APP_TITLE;
export default {
    async get(){

        try{
            let response = await axios.get(api_root + "/Player");
            return response.data;
        }
        catch (err){
            console.error(err.response.data);
            return [];
        }
    },

    async post(name, code){
        try{
            let response = await axios.post(api_root + "/Player",
                {
                    name, code
                });
            return response.data;
        }
        catch (err){
            console.error(err.response.data);
            return [];
        }
    }
}