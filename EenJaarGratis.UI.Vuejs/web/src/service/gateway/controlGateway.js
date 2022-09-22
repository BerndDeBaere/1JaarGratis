import axios from 'axios';
import {GatewayResponse} from "@/service/gateway/GatewayResponse";

const api_root = process.env.VUE_APP_TITLE;
export default {
    async getReloadScoreboard() {
        try {
            await axios.get(api_root + "/Command/ReloadScoreboard");
            return new GatewayResponse(true, undefined)
        } catch (err) {
            return new GatewayResponse(false, err)
        }
    },
    async getStartTimer() {
        try {
            await axios.get(api_root + "/Command/StartTimer");
            return new GatewayResponse(true, undefined)
        } catch (err) {
            return new GatewayResponse(false, err)
        }
    }
}