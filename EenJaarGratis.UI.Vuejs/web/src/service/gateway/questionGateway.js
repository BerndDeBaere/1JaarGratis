import axios from 'axios';
import {GatewayResponse} from "@/service/gateway/GatewayResponse";

const api_root = process.env.VUE_APP_TITLE;
export default {
    async get() {
        try {
            const response = await axios.get(api_root + "/Question");
            return new GatewayResponse(true, response.data)
        } catch (err) {
            return new GatewayResponse(false, err)
        }
    }, async delete(player) {
        try {
            const response = await axios.delete(api_root + "/Question/" + {...player}.id);
            return new GatewayResponse(true, response.data)
        } catch (err) {
            return new GatewayResponse(false, err)
        }
    }, async post(question) {
        try {
            const response = await axios.post(api_root + "/Question", question);
            return new GatewayResponse(true, response.data)
        } catch (err) {
            return new GatewayResponse(false, err)
        }
    }, async put(question) {
        try {
            const response = await axios.put(api_root + "/Question", question);
            return new GatewayResponse(true, response.data)
        } catch (err) {
            return new GatewayResponse(false, err)
        }
    }, async getQuestionGroups(question) {
        try {
            const response =  await axios.get(api_root + "/Question/" + question.id + "/QuestionGroup");
            return new GatewayResponse(true, response.data)
        } catch (err) {
            return new GatewayResponse(false, err)
        }
    }, async createQuestionGroups(question) {
        try {
            const response =  await axios.post(api_root + "/Question/" + question.id + "/QuestionGroup", {});
            return new GatewayResponse(true, response.data)
        } catch (err) {
            return new GatewayResponse(false, err)
        }
    }, async deleteQuestionGroups(question, questionGroup) {
        try {
            const response =  await axios.delete(api_root + "/Question/" + question.id + "/QuestionGroup/" + questionGroup.id);
            return new GatewayResponse(true, response.data)
        } catch (err) {
            return new GatewayResponse(false, err)
        }
    }, async postImportQuestions(csv){
        try {
            let data = {csv: csv};
            const response =  await axios.post(api_root + "/Question/Import", data);
            return new GatewayResponse(true, response.data)
        } catch (err) {
            return new GatewayResponse(false, err)
        }
    }
}