import axios from 'axios';
import {GatewayResponse} from "@/service/gateway/GatewayResponse";

const api_root = process.env.VUE_APP_TITLE;
export default {
    async get() {
        try {
            const response = await axios.get(api_root + "/Player");
            return new GatewayResponse(true, response.data)
        } catch (err) {
            return new GatewayResponse(false, err)
        }
    }, async delete(player) {
        try {
            const response = await axios.delete(api_root + "/Player/" + {...player}.id);
            return new GatewayResponse(true, response.data)
        } catch (err) {
            return new GatewayResponse(false, err)
        }
    }, async post(player) {
        try {
            const response = await axios.post(api_root + "/Player", player);
            return new GatewayResponse(true, response.data)
        } catch (err) {
            return new GatewayResponse(false, err)
        }
    }, async put(player) {
        try {
            const response = await axios.put(api_root + "/Player", player);
            return new GatewayResponse(true, response.data)
        } catch (err) {
            return new GatewayResponse(false, err)
        }
    }, async getScoreboard(){
        try {
            const response = await axios.get(api_root + "/Player/Scoreboard");
            return new GatewayResponse(true, response.data)
        } catch (err) {
            return new GatewayResponse(false, err)
        }
    }, async postQuestionGroupsPlayer(questionGroup, player){
        try{
            const response = await axios.post(api_root + "/Player/" + player.id + "/QuestionGroup/" + questionGroup.id, {});
            return new GatewayResponse(true, response.data)
        }
        catch (err){
            return new GatewayResponse(false, err)
        }
    }, async deleteQuestionGroupsPlayer(questionGroup, player){
        try{
            const response = await axios.delete(api_root + "/Player/" + player.id + "/QuestionGroup/" + questionGroup.id, {});
            return new GatewayResponse(true, response.data)
        }
        catch (err){
            return new GatewayResponse(false, err)
        }
    }
}